using System.Collections.Generic;

namespace asset_register_api.HomesEngland.Domain
{
    public class Asset
    {
        public string Name { get; set; }

        public Dictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string> {{"Name", Name}};
        }
    }
}