using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTdd.AuthModule
{
    public class ErrorTexts
    {
        private string _ruText;
        private string _enText;

        public ErrorTexts(string ruText, string enText)
        {
            this._ruText = ruText;
            this._enText = enText;
        }

        public string GetText(LocalesSupported locale)
        {
            switch (locale)
            {
                case LocalesSupported.Ru:
                    return _ruText;
                case LocalesSupported.En:
                    return _enText;
                default:
                    throw new ArgumentException("Unsupported Locale "+locale);
            }
        }
    }
}
