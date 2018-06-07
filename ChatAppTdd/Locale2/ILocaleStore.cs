using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.Locale2
{
    public interface ILocaleStore:ILocaleData
    {
        void SetLocale(string localeCode);
    }
}
