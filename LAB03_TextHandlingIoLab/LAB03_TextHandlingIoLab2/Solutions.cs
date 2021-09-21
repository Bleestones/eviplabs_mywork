using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LAB03_TextHandlingIoLab2
{
    class Solutions
    {
        private string emailRegex = @"[a-z.]+\@[a-z.]+[a-z]+";
        private string phoneRegex = @"\+\d-(\d{3})+-(\d{3})+-(\d{4})+|(\+36|06)(\d{8,9}|-\d{2}-\d{3}-\d{4})";
        private string phoneHungaryRegex = @"(\+36|06)(\d{2})(\d{7})|(\+36|06)(\d{2})-(\d{3})-(\d{4})";
        private string musicboxRegex = @"([a-zA-Zóőáéüö]+)?(dó|ré|mi|fá|szó|lá|ti)([a-zA-zóőáéüö]+)?";
        private string pluscodeRegex = @"(([23456789C][23456789CFGHJMPQRV][23456789CFGHJMPQRVWX]{6}\+[23456789CFGHJMPQRVWX]{2,3}))";
        private string pluscodeBudapestRegex = @"([23456789CFGHJMPQRVWX]{4}\+[23456789CFGHJMPQRVWX]{2,3})( [a-zA-z]+)";
        private string dateRegex = @"([0-9]){4}[-|\/](0[1-9]|1[0-2])[-|\/](0[1-9]|[12][0-9]|3[01])";

        #region Examples and helper
        internal bool MatchingExample()
        {
            var regex = new Regex(@"<.+>");
            Match m = regex.Match(@"<valami>");
            return m.Success;   // returns true
        }

        internal string[] CollectingMatchesExample()
        {
            // Returns "valami", "még valami" (anything except ">" between "<" and ">".
            return Collect(@"<valami> és <még valami>", @"<[^>]+>").ToArray();
        }

        private IEnumerable<string> Collect(string text, string regex)
        {
            var re = new Regex(regex);
            var matches = re.Matches(text);
            foreach (Match match in matches)
                yield return match.Captures[0].Value;
        }
        #endregion

        #region Email
        internal bool IsEmailAddress(string v)
        {
            var regex = new Regex(emailRegex);
            Match m = regex.Match(v);
            return m.Success;
        }

        internal string[] CollectEmailAddresses(string s)
        {
            return Collect(s, emailRegex).ToArray();
        }
        #endregion

        #region Phone numbers
        internal bool IsPhoneNumber(string v)
        {
            var regex = new Regex(phoneRegex);
            Match m = regex.Match(v);
            return m.Success;
        }

        internal string[] CollectPhoneNumbers(string text)
        {
            return Collect(text, phoneRegex).ToArray();
        }

        internal bool IsHungarianMobilePhoneNumber(string v)
        {
            var regex = new Regex(phoneHungaryRegex);
            Match m = regex.Match(v);
            return m.Success;
        }
        #endregion

        #region MusicBox
        internal bool IsInsideMusicBox(string text)
        {
            var regex = new Regex(musicboxRegex);
            Match m = regex.Match(text);
            return m.Success;
        }

        internal string[] CollectWhatsInsideMusicBox(string text)
        {
            return Collect(text, musicboxRegex).ToArray();
        }

        internal IEnumerable<char> HightlightNotesInMusicBox(string text)
        {
            var regex = new Regex(musicboxRegex);
            //Ilyet nem is vettünk. Mit is jelent a delegate? Belső változó?
            // https://www.dotnetperls.com/regex-replace segített!!!
            return Regex.Replace(text, regex.ToString(), delegate (Match match)
            {
                return $"{match.Groups[1]}*{match.Groups[2]}*{match.Groups[3]}";
            });
        }
        #endregion

        #region PlusCode
        internal bool IsPlusCode(string text)
        {
            var regex = new Regex(pluscodeRegex);
            Match m = regex.Match(text);
            return m.Success;
        }

        internal bool IsPlusCodeInBudapest(string text)
        {
            var regex = new Regex(pluscodeBudapestRegex);
            Match m = regex.Match(text);
            return m.Success;
        }

        internal string[] CollectFullPlusCodes(string text)
        {
            return Collect(text, pluscodeRegex).ToArray();
        }

        #endregion

        #region Date
        /// <summary>
        /// Helper method to extract dates (as strings) from a string.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        internal string[] CollectDates(string text)
        {
            return EnumerateDates(text).ToArray();
        }

        /// <summary>
        /// Helper method to extract the substrings of a string which look like a date.
        /// </summary>
        /// <param name="text">The original string</param>
        /// <returns>IEnumerable of the "looks like a date" substrings.</returns>
        private IEnumerable<string> EnumerateDates(string text)
        {
            var regex = new Regex(dateRegex);
            var matches = regex.Matches(text);
            foreach (Match match in matches)
                yield return match.Captures[0].Value;
        }
        #endregion

    }
}
