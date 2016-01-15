﻿using UrlShortener.Core.Interfaces;

namespace UrlShortener.Core.Objects
{
    public class ShortUrlSettings : IShortUrlSettings
    {
        public string HomepageUrl { get; set; }
        public string VanityUrl { get; set; }
        public string ExternalUrl { get; set; }
    }
}
