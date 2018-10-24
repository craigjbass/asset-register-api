using System.Collections.Generic;

namespace asset_register_api.HomesEngland.Domain
{
    public class Asset
    {
        public string Address { get; set; }
        public string SchemeID { get; set; }
        public string AccountingYear { get; set; }
        
        public Dictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string> {
                {"Address", Address },
                {"SchemeID", SchemeID},
                {"AccountingYear", AccountingYear}
            };
        }
    }
}