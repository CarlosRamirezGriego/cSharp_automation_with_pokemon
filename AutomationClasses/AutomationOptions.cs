using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationClasses
{
    public static class AutomationOptions
    {
        public static object ExpectedMatchingElement { get; set; }

        public enum TestBrowser
        {
            CHROME,
            FIREFOX
        }

        public enum SearchMethod
        {
            ID,
            CSS,
            LINK,
            PARTIALLINK,
            NAME,
            CLASS,
            TAGNAME,
            XPATH
        }

        public enum ExpectedMatchingElements
        {
            NONE,
            ONE,
            MANY
        }

    }
}
