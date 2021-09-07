using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LAB03_TextHandlingIoLab2
{
    class Solutions
    {
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
            throw new NotImplementedException();
        }

        internal string[] CollectEmailAddresses(string s)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Phone numbers
        internal bool IsPhoneNumber(string v)
        {
            throw new NotImplementedException();
        }

        internal string[] CollectPhoneNumbers(string text)
        {
            throw new NotImplementedException();
        }

        internal bool IsHungarianMobilePhoneNumber(string v)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region MusicBox
        internal bool IsInsideMusicBox(string text)
        {
            throw new NotImplementedException();
        }

        internal string[] CollectWhatsInsideMusicBox(string text)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<char> HightlightNotesInMusicBox(string text)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region PlusCode
        internal bool IsPlusCode(string text)
        {
            throw new NotImplementedException();
        }

        internal bool IsPlusCodeInBudapest(string text)
        {
            throw new NotImplementedException();
        }

        internal string[] CollectFullPlusCodes(string text)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Helper method to extract the substrings of a string which look like a date.
        /// </summary>
        /// <param name="text">The original string</param>
        /// <returns>IEnumerable of the "looks like a date" substrings.</returns>
        private IEnumerable<string> EnumerateDates(string text)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
