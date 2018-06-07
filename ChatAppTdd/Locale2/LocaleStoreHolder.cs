using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.Locale2
{
    public static class LocaleStoreHolder
    {
        public static ILocaleStore localize = new LocaleStore();
    }
}
