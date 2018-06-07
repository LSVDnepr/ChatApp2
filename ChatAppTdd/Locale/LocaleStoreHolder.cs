using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.Locale
{
    public static class LocaleStoreHolder
    {
        public static ILocaleStore localize = new LocaleStore();
    }
}
