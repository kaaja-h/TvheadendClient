﻿namespace TvheadendClient.Data.Implementation
{
    public class DvrConfiguration:IDvrConfiguration
    {
        public string Id { get; internal set; }
        public string Name { get; internal set; }
        public string Comment { get; internal set; }
    }
}