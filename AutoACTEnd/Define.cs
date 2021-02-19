using System.Collections.Generic;

namespace AutoACTEnd
{
    public static class Define
    {
        public static readonly string plugInLoaded = "PlugIn Started";
        public static readonly string plugInUnloaded = "No Status";
        public static readonly string matchFoundFormat = "{0} :: {1}";
        public static readonly string dateFormat = "{0} {1}";

        public static readonly char logSeparater = '|';
        public static readonly string codeByMe = "00b9";
        public static readonly string codeByParty = "0139";
        public static readonly string codeByAlliance = "0239";

        public static readonly Dictionary<string, string> wipeCodes = new Dictionary<string, string>()
        {
            {"40000001", "Initial commence"},
            {"40000006", "Recommence"},
            //{"80000004", "Lockout time adjust"},
            {"40000010", "Wipe 1"},
            //{"40000012", "Wipe 2"}
        };
    }
}