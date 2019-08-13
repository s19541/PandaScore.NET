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
        /// <summary>
        /// Gets an Item based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to an item.</param>
        /// <returns>An Item object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Item> GetItemAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "items", id, AccessToken));
            return await GetSingle<Item>(uri);
        }

        /// <summary>
        /// Gets the first Item that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <returns>A single Item object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Item> GetSingleItemAsync(ItemQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "items", options.GetQueryString(), AccessToken));
            return await GetSingleFromArray<Item>(uri);
        }
        
        /// <summary>
        /// Queries for a matching array of items.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <returns>An array containing all items that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Item[]> GetItemsAsync(ItemQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "items", options.GetQueryString(), AccessToken));
            return await GetMany<Item>(uri);
        }

        /// <summary>
        /// Iterator to get results lazily in a paginated form.
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="pageSize">How many results should be returned per iteration.</param>
        /// <returns>Arrays of query results.</returns>
        public IEnumerable<Item[]> GetItemsLazy(ItemQueryOptions options, int pageSize = 50)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&page[size]={3}&token={4}", Domain, "items", options.GetQueryString(), pageSize, AccessToken));
            var iterator = GetManyLazy<Item>(uri);
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
        #endregion

        #region Champions
        /// <summary>
        /// Gets a <c>Champion</c> based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a champion.</param>
        /// <returns>A <c>Champion</c> object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Champion> GetChampionAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "champions", id, AccessToken));
            return await GetSingle<Champion>(uri);
        }

        /// <summary>
        /// Gets the first champion that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <returns>A single champion object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Champion> GetSingleChampionAsync(ChampionQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "champions", options.GetQueryString(), AccessToken));
            return await GetSingleFromArray<Champion>(uri);
        }

        /// <summary>
        /// Queries for a matching array of champions.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <returns>An array containing all champions that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Champion[]> GetChampionsAsync(ChampionQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "champions", options.GetQueryString(), AccessToken));
            return await GetMany<Champion>(uri);
        }

        /// <summary>
        /// Iterator to get results lazily in a paginated form.
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="pageSize">How many results should be returned per iteration.</param>
        /// <returns>Arrays of query results.</returns>
        public IEnumerable<Champion[]> GetChampionsLazy(ChampionQueryOptions options, int pageSize = 50)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&page[size]={3}&token={4}", Domain, "champions", options.GetQueryString(), pageSize, AccessToken));
            var iterator = GetManyLazy<Champion>(uri);
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
        #endregion

        #region Matches
        public async Task<Match> GetMatch(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[id]={2}&token={3}", Domain, "matches", id, AccessToken));
            return await GetSingleFromArray<Match>(uri);
        }
        #endregion

        #region Series
        public async Task<Series> GetSeries(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[id]={2}&token={3}", Domain, "series", id, AccessToken));
            return await GetSingleFromArray<Series>(uri);
        }
        #endregion

        #region Games
        public async Task<Game> GetGame(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[id]={2}&token={3}", Domain, "games", id, AccessToken));
            return await GetSingleFromArray<Game>(uri);
        }
        #endregion

        #region Tournaments
        public async Task<Tournament> GetTournament(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[id]={2}&token={3}", Domain, "tournaments", id, AccessToken));
            return await GetSingleFromArray<Tournament>(uri);
        }
        #endregion

        #region Leagues
        public async Task<League> GetLeague(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[id]={2}&token={3}", Domain, "leagues", id, AccessToken));
            return await GetSingleFromArray<League>(uri);
        }
        #endregion

        #region Spells
        public async Task<Spell> GetSpellAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "spells", id, AccessToken));
            return await GetSingle<Spell>(uri);
        }
        #endregion

        #region Runes
        public async Task<Rune> GetRuneAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "runes", id, AccessToken));
            return await GetSingle<Rune>(uri);
        }
        #endregion

        #region Masteries
        public async Task<Mastery> GetMasteryAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "masteries", id, AccessToken));
            return await GetSingle<Mastery>(uri);
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

        async Task<T> GetSingleFromArray<T>(Uri uri) where T : class
        {
            var response = await client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"PandaScore request returned status code {response.StatusCode}");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var array = JArray.Parse(jsonString);
            if (array.Count > 0) return array[0].ToObject<T>();
            else return null;
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

        IEnumerator<T[]> GetManyLazy<T>(Uri uri)
        {
            var responseTask = Task.Run(() => client.GetAsync(uri));
            responseTask.Wait();
            var response = responseTask.Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"PandaScore request returned status code {response.StatusCode}");
            }

            int numberOfItems = int.Parse(
                response.Headers.GetValues("X-Total").First());

            int pageSize = int.Parse(
                response.Headers.GetValues("X-Per-Page").First());

            var jsonStringTask = Task.Run(() => response.Content.ReadAsStringAsync());
            jsonStringTask.Wait();
            string jsonString = jsonStringTask.Result;

            if (numberOfItems > pageSize)
            {
                string linkHeader = response.Headers.GetValues("Link").First();

                yield return JArray.Parse(jsonString).ToObject<T[]>();

                for (int i = pageSize; i < numberOfItems; i += pageSize)
                {
                    responseTask = Task.Run(() => client.GetAsync(GetNextPage(linkHeader)));
                    responseTask.Wait();
                    response = responseTask.Result;
                    linkHeader = response.Headers.GetValues("Link").First();
                    jsonStringTask = Task.Run(() => response.Content.ReadAsStringAsync());
                    jsonStringTask.Wait();
                    jsonString = jsonStringTask.Result;
                    yield return JArray.Parse(jsonString).ToObject<T[]>();
                }

            }

            else
            {
                yield return JArray.Parse(jsonString).ToObject<T[]>();
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
