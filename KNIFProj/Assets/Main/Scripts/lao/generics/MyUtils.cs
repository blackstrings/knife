using System.Globalization;

namespace LAO.Generic {

    public static class MyUtils {

        public static string toTitleCase(string str) {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }


    }
}