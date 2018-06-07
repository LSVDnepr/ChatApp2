using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.Locale
{
    public interface ILocaleStore:ILocaleData
    {
        void SetLocale(string localeCode);
    }
}
