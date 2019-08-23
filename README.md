# PandaScore.NET

This is a PandaScore API library for .NET.

Query options (other than game statistics) are implemented, with improvements coming soon.

Currently, you can make queries for League of Legends champions, items, summoner spells, runes, masteries, players, teams, matches, leagues, game series and tournaments.

## Getting Started

Simply build the project and use the resulting DLL, or get it from [NuGet](https://www.nuget.org/packages/PandaScore.NET/).

For now, only League of Legends is supported - all requests can be made through a PandaScoreLoLProvider instance. You will need to supply your PandaScore API token in the constructor.

Queries correspond to model objects, such as Champions, Items, Matches, etc.

Most methods on PandaScoreLoLProvider take a model-appropriate ...QueryOption parameter, such as ChampionQueryOption. Each of these classes contain the properties that you can use to make your queries. 
Current operations on these properties are:

* Filter: used to match a value exactly
* Search: matches results that contain the search term
* Range: used to give a range of acceptable values
* Sort: sort results in ascending order by a property
* SortDescending: sort results in descending order by a property

There are also counterparts to these to unset a query option.

For clarity, here's a simple example for a champion query:
```
var provider = new PandaScoreLoLProvider("your token here"); //create a provider object
var query = new ChampionQueryOptions(); //query options to be passed
//set various query options
query.Armor.Range(0,20);
query.Name.Search("dinger");
query.Hp.Sort();
//fetch the results using one of the methods on the provider
var results = await provider.GetChampionsAsync(query);
```

## Built With

* [Json.NET](https://www.newtonsoft.com/json) - To parse the PandaScore API results

## Authors

* **Tamás Bischof** - *Initial work* - [Tamás Bischof](http://www.bischoftamas.com)

See also the list of [contributors](https://github.com/tamasbischof/PandaScore.NET/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

Be aware that PandaScore has its own [terms of usage](https://pandascore.co/terms)! No responsibility is taken for breaching these by using this project.
