using Newtonsoft.Json.Linq;
using PandaScoreNET.LoL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PandaScoreNET
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

        /// <summary>
        /// Gets a player based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to an player.</param>
        /// <returns>A Player object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Player GetPlayer(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[id]={2}&token={3}", Domain, "players", id, AccessToken));
            var task = Task.Run(() => GetSingleFromArray<Player>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets a player based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to an player.</param>
        /// <returns>A Player object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Player> GetPlayerAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[id]={2}&token={3}", Domain, "players", id, AccessToken));
            return await GetSingleFromArray<Player>(uri);
        }


        /// <summary>
        /// Gets the first player that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <returns>A single Player object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Player GetSinglePlayer(PlayerQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "players", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetSingleFromArray<Player>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets the first player that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <returns>A single Player object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Player> GetSinglePlayerAsync(PlayerQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "players", options.GetQueryString(), AccessToken));
            return await GetSingleFromArray<Player>(uri);
        }


        /// <summary>
        /// Queries for a matching array of players.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <returns>An array containing all players that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Player[] GetPlayers(PlayerQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "players", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetMany<Player>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Queries for a matching array of players.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <returns>An array containing all players that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Player[]> GetPlayersAsync(PlayerQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "players", options.GetQueryString(), AccessToken));
            return await GetMany<Player>(uri);
        }

        /// <summary>
        /// Iterator to get results lazily in a paginated form.
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="pageSize">How many results should be returned per iteration.</param>
        /// <returns>Arrays of query results.</returns>
        public IEnumerable<Player[]> GetPlayersLazy(PlayerQueryOptions options, int pageSize = 50) //haha
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&page[size]={3}&token={4}", Domain, "players", options.GetQueryString(), pageSize, AccessToken));
            var iterator = GetManyLazy<Player>(uri);
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
        #endregion

        #region Teams
        /// <summary>
        /// Gets a team based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a team.</param>
        /// <returns>A Team object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Team GetTeam(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[id]={2}&token={3}", Domain, "teams", id, AccessToken));
            var task = Task.Run(() => GetSingleFromArray<Team>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets a team based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a team.</param>
        /// <returns>A Team object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Team> GetTeamAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[id]={2}&token={3}", Domain, "teams", id, AccessToken));
            return await GetSingleFromArray<Team>(uri);
        }

        /// <summary>
        /// Gets the first team that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <returns>A single Team object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Team GetSingleTeam(TeamQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "teams", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetSingleFromArray<Team>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets the first team that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <returns>A single Team object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Team> GetSingleTeamAsync(TeamQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "teams", options.GetQueryString(), AccessToken));
            return await GetSingleFromArray<Team>(uri);
        }

        /// <summary>
        /// Queries for a matching array of teams.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <returns>An array containing all teams that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Team[] GetTeams(TeamQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "teams", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetMany<Team>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Queries for a matching array of teams.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <returns>An array containing all teams that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Team[]> GetTeamsAsync(TeamQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "teams", options.GetQueryString(), AccessToken));
            return await GetMany<Team>(uri);
        }

        /// <summary>
        /// Iterator to get results lazily in a paginated form.
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="pageSize">How many results should be returned per iteration.</param>
        /// <returns>Arrays of query results.</returns>
        public IEnumerable<Team[]> GetTeamsLazy(TeamQueryOptions options, int pageSize = 50)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&page[size]={3}&token={4}", Domain, "teams", options.GetQueryString(), pageSize, AccessToken));
            var iterator = GetManyLazy<Team>(uri);
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
        #endregion

        #region Items
        /// <summary>
        /// Gets an Item based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to an item.</param>
        /// <returns>An Item object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Item GetItem(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "items", id, AccessToken));
            var task = Task.Run(() => GetSingle<Item>(uri));
            task.Wait();
            return task.Result;
        }

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
        public Item GetSingleItem(ItemQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "items", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetSingleFromArray<Item>(uri));
            task.Wait();
            return task.Result;
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
        public Item[] GetItems(ItemQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "items", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetMany<Item>(uri));
            task.Wait();
            return task.Result;
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
        public Champion GetChampion(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "champions", id, AccessToken));
            var task = Task.Run(() => GetSingle<Champion>(uri));
            task.Wait();
            return task.Result;
        }

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
        public Champion GetSingleChampion(ChampionQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "champions", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetSingleFromArray<Champion>(uri));
            task.Wait();
            return task.Result;
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
        public Champion[] GetChampions(ChampionQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "champions", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetMany<Champion>(uri));
            task.Wait();
            return task.Result;
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
        /// <summary>
        /// Gets a match based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a match.</param>
        /// <param name="category">Completion status of the match to be queried. Defaults to All.</param>
        /// <returns>A match object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Match GetMatch(int id, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?filter[id]={3}&token={4}", Domain, "matches", GetTournamentDomainString(status), id, AccessToken));
            var task = Task.Run(() => GetSingleFromArray<Match>(uri));
            task.Wait();
            return task.Result;
        }
        
        /// <summary>
        /// Gets a match based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a match.</param>
        /// <param name="category">Completion status of the match to be queried. Defaults to All.</param>
        /// <returns>A match object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Match> GetMatchAsync(int id, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?filter[id]={3}&token={4}", Domain, "matches", GetTournamentDomainString(status), id, AccessToken));
            return await GetSingleFromArray<Match>(uri);
        }

        /// <summary>
        /// Gets the first match that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="category">Completion status of the match to be queried. Defaults to All.</param>
        /// <returns>A single Match object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Match GetSingleMatch(MatchQueryOptions options, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&token={4}", Domain, "match", GetTournamentDomainString(status), options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetSingleFromArray<Match>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets the first match that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="category">Completion status of the match to be queried. Defaults to All.</param>
        /// <returns>A single Match object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Match> GetSingleMatchAsync(MatchQueryOptions options, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&token={4}", Domain, "match", GetTournamentDomainString(status), options.GetQueryString(), AccessToken));
            return await GetSingleFromArray<Match>(uri);
        }

        /// <summary>
        /// Queries for a matching array of game matches.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <param name="category">Completion status of the matches to be queried. Defaults to All.</param>
        /// <returns>An array containing all series that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Match[] GetMatches(MatchQueryOptions options, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&token={4}", Domain, "matches", GetTournamentDomainString(status), options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetMany<Match>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Queries for a matching array of game matches.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <param name="category">Completion status of the matches to be queried. Defaults to All.</param>
        /// <returns>An array containing all series that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Match[]> GetMatchesAsync(MatchQueryOptions options, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&token={4}", Domain, "matches", GetTournamentDomainString(status), options.GetQueryString(), AccessToken));
            return await GetMany<Match>(uri);
        }

        /// <summary>
        /// Iterator to get results lazily in a paginated form.
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="category">Completion status of the matches to be queried. Defaults to All.</param>
        /// <param name="pageSize">How many results should be returned per iteration.</param>
        /// <returns>Arrays of query results.</returns>
        public IEnumerable<Match[]> GetMatchesLazy(MatchQueryOptions options, int pageSize = 50, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&page[size]={4}&token={5}", Domain, "matches", GetTournamentDomainString(status), options.GetQueryString(), pageSize, AccessToken));
            var iterator = GetManyLazy<Match>(uri);
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
        #endregion

        #region Series
        /// <summary>
        /// Gets a series based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a series.</param>
        /// <param name="category">Completion status of the series to be queried. Defaults to All.</param>
        /// <returns>A Series object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Series GetSingleSeries(int id, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?filter[id]={3}&token={4}", Domain, "series", GetTournamentDomainString(status), id, AccessToken));
            var task = Task.Run(() => GetSingleFromArray<Series>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets a series based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a series.</param>
        /// <param name="category">Completion status of the series to be queried. Defaults to All.</param>
        /// <returns>A Series object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Series> GetSingleSeriesAsync(int id, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?filter[id]={3}&token={4}", Domain, "series", GetTournamentDomainString(status), id, AccessToken));
            return await GetSingleFromArray<Series>(uri);
        }

        /// <summary>
        /// Gets the first series that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="category">Completion status of the series to be queried. Defaults to All.</param>
        /// <returns>A single Series object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Series GetSingleSeries(SeriesQueryOptions options, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&token={4}", Domain, "series", GetTournamentDomainString(status), options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetSingleFromArray<Series>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets the first series that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="category">Completion status of the series to be queried. Defaults to All.</param>
        /// <returns>A single Series object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Series> GetSingleSeriesAsync(SeriesQueryOptions options, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&token={4}", Domain, "series", GetTournamentDomainString(status), options.GetQueryString(), AccessToken));
            return await GetSingleFromArray<Series>(uri);
        }

        /// <summary>
        /// Queries for a matching array of series.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <param name="category">Completion status of the series to be queried. Defaults to All.</param>
        /// <returns>An array containing all series that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Series[] GetSeries(SeriesQueryOptions options, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&token={4}", Domain, "series", GetTournamentDomainString(status), options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetMany<Series>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Queries for a matching array of series.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <param name="category">Completion status of the series to be queried. Defaults to All.</param>
        /// <returns>An array containing all series that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Series[]> GetSeriesAsync(SeriesQueryOptions options, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&token={4}", Domain, "series", GetTournamentDomainString(status), options.GetQueryString(), AccessToken));
            return await GetMany<Series>(uri);
        }

        /// <summary>
        /// Iterator to get results lazily in a paginated form.
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="category">Completion status of the series to be queried. Defaults to All.</param>
        /// <param name="pageSize">How many results should be returned per iteration.</param>
        /// <returns>Arrays of query results.</returns>
        public IEnumerable<Series[]> GetSeriesLazy(SeriesQueryOptions options, int pageSize = 50, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&page[size]={4}&token={5}", Domain, "series", GetTournamentDomainString(status), options.GetQueryString(), pageSize, AccessToken));
            var iterator = GetManyLazy<Series>(uri);
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
        #endregion

        #region Games
        public async Task<Game> GetGameAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[id]={2}&token={3}", Domain, "games", id, AccessToken));
            return await GetSingleFromArray<Game>(uri);
        }
        #endregion

        #region Tournaments
        /// <summary>
        /// Gets a tournament based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a tournament.</param>
        /// <param name="category">Completion status of the tournament to be queried. Defaults to All.</param>
        /// <returns>A Tournament object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Tournament GetTournament(int id, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?filter[id]={3}&token={4}", Domain, "tournaments", GetTournamentDomainString(status), id, AccessToken));
            var task = Task.Run(() => GetSingleFromArray<Tournament>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets a tournament based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a tournament.</param>
        /// <param name="category">Completion status of the tournament to be queried. Defaults to All.</param>
        /// <returns>A Tournament object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Tournament> GetTournamentAsync(int id, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?filter[id]={3}&token={4}", Domain, "tournaments", GetTournamentDomainString(status), id, AccessToken));
            return await GetSingleFromArray<Tournament>(uri);
        }

        /// <summary>
        /// Gets the first tournament that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="category">Completion status of the tournaments to be queried. Defaults to All.</param>
        /// <returns>A single Tournament object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Tournament GetSingleTournament(TournamentQueryOptions options, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&token={4}", Domain, "tournaments", GetTournamentDomainString(status), options.GetQueryString(), AccessToken));
            var task = Task.Run(() =>  GetSingleFromArray<Tournament>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets the first tournament that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="category">Completion status of the tournaments to be queried. Defaults to All.</param>
        /// <returns>A single Tournament object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Tournament> GetSingleTournamentAsync(TournamentQueryOptions options, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&token={4}", Domain, "tournaments", GetTournamentDomainString(status), options.GetQueryString(), AccessToken));
            return await GetSingleFromArray<Tournament>(uri);
        }

        /// <summary>
        /// Queries for a matching array of tournaments.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <param name="category">Completion status of the tournaments to be queried. Defaults to All.</param>
        /// <returns>An array containing all tournaments that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Tournament[] GetTournaments(TournamentQueryOptions options, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&token={4}", Domain, "tournaments", GetTournamentDomainString(status), options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetMany<Tournament>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Queries for a matching array of tournaments.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <param name="category">Completion status of the tournaments to be queried. Defaults to All.</param>
        /// <returns>An array containing all tournaments that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Tournament[]> GetTournamentsAsync(TournamentQueryOptions options, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&token={4}", Domain, "tournaments", GetTournamentDomainString(status), options.GetQueryString(), AccessToken));
            return await GetMany<Tournament>(uri);
        }

        /// <summary>
        /// Iterator to get results lazily in a paginated form.
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="category">Completion status of the tournaments to be queried. Defaults to All.</param>
        /// <param name="pageSize">How many results should be returned per iteration.</param>
        /// <returns>Arrays of query results.</returns>
        public IEnumerable<Tournament[]> GetTournamentsLazy(TournamentQueryOptions options, int pageSize = 50, GameCollectionStatus status = GameCollectionStatus.All)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?{3}&page[size]={4}&token={5}", Domain, "tournaments", GetTournamentDomainString(status), options.GetQueryString(), pageSize, AccessToken));
            var iterator = GetManyLazy<Tournament>(uri);
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
        #endregion

        #region Leagues
        /// <summary>
        /// Gets a league based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a league.</param>
        /// <returns>A League object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public League GetLeague(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[id]={2}&token={3}", Domain, "leagues", id, AccessToken));
            var task = Task.Run(() =>  GetSingleFromArray<League>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets a league based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a league.</param>
        /// <returns>A League object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<League> GetLeagueAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?filter[id]={2}&token={3}", Domain, "leagues", id, AccessToken));
            return await GetSingleFromArray<League>(uri);
        }

        /// <summary>
        /// Gets the first league that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <returns>A single League object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public League GetSingleLeague(LeagueQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "leagues", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetSingleFromArray<League>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets the first league that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <returns>A single League object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<League> GetSingleLeagueAsync(LeagueQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "leagues", options.GetQueryString(), AccessToken));
            return await GetSingleFromArray<League>(uri);
        }

        /// <summary>
        /// Queries for a matching array of leagues.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <returns>An array containing all leagues that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public League[] GetLeagues(LeagueQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "leagues", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetMany<League>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Queries for a matching array of leagues.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <returns>An array containing all leagues that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<League[]> GetLeaguesAsync(LeagueQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "leagues", options.GetQueryString(), AccessToken));
            return await GetMany<League>(uri);
        }

        /// <summary>
        /// Iterator to get results lazily in a paginated form.
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="pageSize">How many results should be returned per iteration.</param>
        /// <returns>Arrays of query results.</returns>
        public IEnumerable<League[]> GetLeaguesLazy(LeagueQueryOptions options, int pageSize = 50)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&page[size]={3}&token={4}", Domain, "leagues", options.GetQueryString(), pageSize, AccessToken));
            var iterator = GetManyLazy<League>(uri);
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
        #endregion

        #region Runes
        /// <summary>
        /// Gets a rune based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a rune.</param>
        /// <returns>A Rune object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Rune GetRune(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "runes", id, AccessToken));
            var task = Task.Run(() => GetSingle<Rune>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets a rune based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a rune.</param>
        /// <returns>A Rune object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Rune> GetRuneAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "runes", id, AccessToken));
            return await GetSingle<Rune>(uri);
        }

        /// <summary>
        /// Gets the first rune that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <returns>A single Rune object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Rune GetSingleRune(RuneQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "runes", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetSingleFromArray<Rune>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets the first rune that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <returns>A single Rune object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Rune> GetSingleRuneAsync(RuneQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "runes", options.GetQueryString(), AccessToken));
            return await GetSingleFromArray<Rune>(uri);
        }

        /// <summary>
        /// Queries for a matching array of runes.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <returns>An array containing all runes that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Rune[] GetRunes(RuneQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "runes", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetMany<Rune>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Queries for a matching array of runes.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <returns>An array containing all runes that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Rune[]> GetRunesAsync(RuneQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "runes", options.GetQueryString(), AccessToken));
            return await GetMany<Rune>(uri);
        }

        /// <summary>
        /// Iterator to get results lazily in a paginated form.
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="pageSize">How many results should be returned per iteration.</param>
        /// <returns>Arrays of query results.</returns>
        public IEnumerable<Rune[]> GetRunesLazy(RuneQueryOptions options, int pageSize = 50)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&page[size]={3}&token={4}", Domain, "runes", options.GetQueryString(), pageSize, AccessToken));
            var iterator = GetManyLazy<Rune>(uri);
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
        #endregion

        #region Spells
        /// <summary>
        /// Gets a spell based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a spell.</param>
        /// <returns>A Spell object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Spell GetSpell(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "spells", id, AccessToken));
            var task = Task.Run(() => GetSingle<Spell>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets a spell based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a spell.</param>
        /// <returns>A Spell object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Spell> GetSpellAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "spells", id, AccessToken));
            return await GetSingle<Spell>(uri);
        }

        /// <summary>
        /// Gets the first spell that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <returns>A single Spell object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Spell GetSingleSpell(SpellQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "spells", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetSingleFromArray<Spell>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets the first spell that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <returns>A single Spell object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Spell> GetSingleSpellAsync(SpellQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "spells", options.GetQueryString(), AccessToken));
            return await GetSingleFromArray<Spell>(uri);
        }

        /// <summary>
        /// Queries for a matching array of spells.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <returns>An array containing all spells that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Spell[] GetSpells(SpellQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "spells", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetMany<Spell>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Queries for a matching array of spells.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <returns>An array containing all spells that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Spell[]> GetSpellsAsync(SpellQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "spells", options.GetQueryString(), AccessToken));
            return await GetMany<Spell>(uri);
        }

        /// <summary>
        /// Iterator to get results lazily in a paginated form.
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="pageSize">How many results should be returned per iteration.</param>
        /// <returns>Arrays of query results.</returns>
        public IEnumerable<Spell[]> GetSpellLazy(SpellQueryOptions options, int pageSize = 50)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&page[size]={3}&token={4}", Domain, "spells", options.GetQueryString(), pageSize, AccessToken));
            var iterator = GetManyLazy<Spell>(uri);
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
        #endregion

        #region Masteries    
        /// <summary>
        /// Gets a Mastery based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a mastery.</param>
        /// <returns>A Mastery object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Mastery GetMastery(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "masteries", id, AccessToken));
            var task = Task.Run(() => GetSingle<Mastery>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets a Mastery based on its numeric ID.
        /// </summary>
        /// <param name="id">A numeric ID belonging to a mastery.</param>
        /// <returns>A Mastery object with the specified ID.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Mastery> GetMasteryAsync(int id)
        {
            var uri = new Uri(string.Format(@"{0}/{1}/{2}?token={3}", Domain, "masteries", id, AccessToken));
            return await GetSingle<Mastery>(uri);
        }

        /// <summary>
        /// Gets the first mastery that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <returns>A single Mastery object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Mastery GetSingleMastery(MasteryQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "masteries", options.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetSingleFromArray<Mastery>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets the first mastery that matches the query options. Even if there is more than one matching result, only the first will be returned!
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <returns>A single Mastery object, matching the search options, or null, if no matches are found.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Mastery> GetSingleMasteryAsync(MasteryQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "masteries", options.GetQueryString(), AccessToken));
            return await GetSingleFromArray<Mastery>(uri);
        }

        /// <summary>
        /// Queries for a matching array of masteries.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <returns>An array containing all masteries that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public Mastery[] GetMasteries(MasteryQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "masteries", options?.GetQueryString(), AccessToken));
            var task = Task.Run(() => GetMany<Mastery>(uri));
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Queries for a matching array of masteries.
        /// </summary>
        /// <param name="options">Query options object configured with the search settings.</param>
        /// <returns>An array containing all masteries that match the search options.</returns>
        /// <exception cref="HttpRequestException">Thrown when the request is not successful.</exception>
        public async Task<Mastery[]> GetMasteriesAsync(MasteryQueryOptions options)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&token={3}", Domain, "masteries", options?.GetQueryString(), AccessToken));
            return await GetMany<Mastery>(uri);
        }

        /// <summary>
        /// Iterator to get results lazily in a paginated form.
        /// </summary>
        /// <param name="options">Query options object configured with the query settings.</param>
        /// <param name="pageSize">How many results should be returned per iteration.</param>
        /// <returns>Arrays of query results.</returns>
        public IEnumerable<Mastery[]> GetItemsLazy(MasteryQueryOptions options, int pageSize = 50)
        {
            var uri = new Uri(string.Format(@"{0}/{1}?{2}&page[size]={3}&token={4}", Domain, "masteries", options.GetQueryString(), pageSize, AccessToken));
            var iterator = GetManyLazy<Mastery>(uri);
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
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

        string GetTournamentDomainString(GameCollectionStatus category)
        {
            switch (category)
            {
                case GameCollectionStatus.All:
                    return "";
                case GameCollectionStatus.Past:
                    return @"\past";
                case GameCollectionStatus.Running:
                    return @"\running";
                case GameCollectionStatus.Upcoming:
                    return @"\upcoming";
            }
            return "";
        }
        #endregion
    }

    public enum GameCollectionStatus
    {
        All,
        Past,
        Running,
        Upcoming,
    }
}
