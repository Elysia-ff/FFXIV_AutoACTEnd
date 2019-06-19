namespace AutoACTEnd
{
    public static class Define
    {
        public enum Code
        {
            Idx = 0,
            Date = 1,
            Code = 2,
            Message = 4,

            Max,
        }

        public const string plugInLoaded = "PlugIn Started";
        public const string plugInUnloaded = "No Status";
        public const string matchFoundFormat = "{0} :: {1}";
        public const string dateFormat = "{0} {1}";

        public const char logSeparater = '|';
        public const string codeByMe = "00b9";
        public const string codeByAnother = "0239";
    }
}