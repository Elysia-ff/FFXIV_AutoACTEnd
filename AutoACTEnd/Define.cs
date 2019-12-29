using System.Collections.Generic;

namespace AutoACTEnd
{
    public static class Define
    {
        public const string plugInLoaded = "PlugIn Started";
        public const string plugInUnloaded = "No Status";
        public const string matchFoundFormat = "{0} :: {1}";
        public const string dateFormat = "{0} {1}";

        public const char logSeparater = '|';
        public const string codeByMe = "00b9";
        public const string codeByParty = "0139";
        public const string codeByAlliance = "0239";

        public static Dictionary<string, string> wipeCodes = new Dictionary<string, string>()
        {
            {"40000001", "Initial commence"},
            {"40000006", "Recommence"},
            //{"80000004", "Lockout time adjust"},
            {"40000010", "Wipe 1"},
            //{"40000012", "Wipe 2"}
        };
    }
}