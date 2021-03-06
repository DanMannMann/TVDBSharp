﻿using System;
using System.Configuration;
using System.Linq;
using TVDBSharp;
using TVDBSharp.Models.Enums;

namespace Examples
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Your own API key
            var tvdb = new TVDB(ConfigurationManager.AppSettings["apikey"]);

            // Retrieve and display Game of Thrones
            //GetSpecificShow(tvdb);

            // Retrieve and display Game of Thrones s04e01
            //GetSpecificEpisode(tvdb);

            // Retrieve and display episode titles for Game of Thrones season 2
            //GetEpisodeTitlesForSeason(tvdb);

            // Search for Battlestar Galactica on tvdb
            //SearchShow(tvdb);

            // Get updates of the last 24 hours
            GetUpdates(tvdb);

            Console.ReadKey();
        }

        private static void GetSpecificShow(TVDB tvdb)
        {
            Console.WriteLine("Game of Thrones");
            var got = tvdb.GetShow(121361);
            DisplayShowDetails.Print(got);
            Console.WriteLine("-----------");
        }

        private static void GetSpecificEpisode(TVDB tvdb)
        {
            Console.WriteLine("Game of Thrones s04e01");
            var episode = tvdb.GetEpisode(4721938);
            DisplayEpisodeDetails.Print(episode);
            Console.WriteLine("-----------");
        }

        private static void GetEpisodeTitlesForSeason(TVDB tvdb)
        {
            Console.WriteLine("Episodes of Game of Thrones season 2");
            var show = tvdb.GetShow(121361);
            var season2Episodes = show.Episodes.Where(ep => ep.SeasonNumber == 2).ToList();
            DisplayEpisodeTitles.Print(season2Episodes);
            Console.WriteLine("-----------");
        }

        private static void SearchShow(TVDB tvdb)
        {
            Console.WriteLine("Search for Battlestar Galactica on tvdb");
            var searchResults = tvdb.Search("Battlestar Galactica");
            DisplaySearchResult.Print(searchResults);
            Console.WriteLine("-----------");
        }

        private static void GetUpdates(TVDB tvdb)
        {
            var updates = tvdb.GetUpdates(Interval.Day);
            Console.WriteLine("Updates during the last 24 hours on thetvdb, since {0}", updates.Timestamp);
            DisplayUpdates.Print(updates);
        }
    }
}