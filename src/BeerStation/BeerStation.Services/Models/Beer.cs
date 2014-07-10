﻿namespace BeerStation.Services.Models
{
    public class Beer
    {
        public int bid { get; set; }
        public string beer_name { get; set; }
        public string beer_label { get; set; }
        public double beer_abv { get; set; }
        public int beer_ibu { get; set; }
        public string beer_description { get; set; }
        public string created_at { get; set; }
        public string beer_style { get; set; }
        public int auth_rating { get; set; }
        public bool wish_list { get; set; }
        public int is_in_production { get; set; }
        public string beer_slug { get; set; }
        public int is_homebrew { get; set; }
        public int rating_count { get; set; }
        public double rating_score { get; set; }
        public Stats stats { get; set; }
        public Brewery brewery { get; set; }
        public Vintages vintages { get; set; }
    }
}