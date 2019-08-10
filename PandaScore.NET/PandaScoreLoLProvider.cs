using Newtonsoft.Json.Linq;
using PandaScore.NET.LoL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PandaScore.NET
{
    /// <summary>
    /// The main entry point into the API. Use to make requests from PandaScore.
    /// </summary>
    public class PandaScoreLoLProvider
    {
        private readonly string AccessToken;
        private readonly string Domain = "https://api.pandascore.co/lol/";
        HttpClient client = new HttpClient();

        /// <param name="accessToken">Your PandaScore Access Token.</param>
        public PandaScoreLoLProvider(string accessToken)
        {
            AccessToken = accessToken;
        }

        #region PublicInterface

        #region Players
        public async Task<Player> GetPlayerAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[id]={2}&token={3}", Domain, "players", id, AccessToken));
            return await GetSingleFromArray<Player>(uri);
        }

        public async Task<Player> GetPlayerAsync(string name)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[name]={2}&token={3}", Domain, "players", name, AccessToken));
            return await GetSingleFromArray<Player>(uri);
        }

        public async Task<Player[]> GetPlayersAsync(PlayerRole role)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?page[size]=100&filter[role]={2}&token={3}", Domain, "players", role, AccessToken));
            return await GetMany<Player>(uri);
        }
        #endregion

        #region Teams
        public async Task<Team> GetTeamAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/?filter[id]={2}&token={3}", Domain, "teams", id, AccessToken));
            return await GetSingleFromArray<Team>(uri);
        } 
        #endregion

        #region Items
        public async Task<Item> GetItemAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "items", id, AccessToken));
            return await GetSingle<Item>(uri);
        }
        #endregion

        #region Champions
        public async Task<Champion> GetChampionAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "champions", id, AccessToken));
            return await GetSingle<Champion>(uri);
        }
        #endregion

        #region Matches
        public async Task<Match> GetMatch(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[id]={2}&token={3}", Domain, "matches", id, AccessToken));
            return await GetSingleFromArray<Match>(uri);
        }
        #endregion

        #endregion

        #region Helpers
        async Task<T> GetSingle<T>(Uri uri)
        {
            var response = await client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"PandaScore request returned status code {response.StatusCode}");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            return JObject.Parse(jsonString).ToObject<T>();
        }

        async Task<T> GetSingleFromArray<T>(Uri uri)
        {
            var response = await client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"PandaScore request returned status code {response.StatusCode}");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            return JArray.Parse(jsonString)[0].ToObject<T>();
        }

        async Task<T[]> GetMany<T>(Uri uri)
        {
            var response = await client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"PandaScore request returned status code {response.StatusCode}");
            }

            int numberOfItems = int.Parse(
                response.Headers.GetValues("X-Total").First());

            int pageSize = int.Parse(
                response.Headers.GetValues("X-Per-Page").First());

            string jsonString = await response.Content.ReadAsStringAsync();

            if (numberOfItems > pageSize)
            {
                string linkHeader = response.Headers.GetValues("Link").First();
                List<T> result = new List<T>();
                result.AddRange(JArray.Parse(jsonString).ToObject<T[]>());

                for (int i = pageSize; i < numberOfItems; i += pageSize)
                {
                    response = await client.GetAsync(GetNextPage(linkHeader));
                    linkHeader = response.Headers.GetValues("Link").First();
                    jsonString = await response.Content.ReadAsStringAsync();
                    result.AddRange(JArray.Parse(jsonString).ToObject<T[]>());
                }

                return result.ToArray();
            }

            else
            {
                return JArray.Parse(jsonString).ToObject<T[]>();
            }
        }

        Uri GetNextPage(string header)
        {
            foreach (var substring in header.Split(','))
            {
                var pageLink = new PaginationLink(substring);
                if (pageLink.Type == PaginationLinkType.Next) return pageLink.Uri;
            }

            return null;
        } 
        #endregion
    }
}
