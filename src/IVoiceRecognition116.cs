/* ILights116.cs UnifiedPOS Lights Extension Interface for POS for.NET 1.14.1
  version 1.16.0.0 January 19th, 2022

  Copyright (C) 2022 Kunio Fukuchi

  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. This notice may not be removed or altered from any source distribution.

  Kunio Fukuchi

*/

namespace OpenPOS.Extension
{
    using System;
    using System.Collections.Generic;

    public struct VoiceWord
    {
        private string _id;
        private string[] _word;
        public string GroupId
        {
            get { return this._id; }
        }
        public string[] Word
        {
            get { return this._word; }
        }
        public VoiceWord(string GroupId, string[] Word)
        {
            if (string.IsNullOrWhiteSpace(GroupId))
            {
                throw new ArgumentException();
            }
            this._id = GroupId;
            this._word = Word;
        }
        public bool Equals(VoiceWord word)
        {
            if ((word.GroupId == this._id) && (word.Word == this._word))
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj is VoiceWord)
            {
                return this.Equals((VoiceWord)obj);
            }
            return false;
        }
        public static bool Equals(VoiceWord a, VoiceWord b)
        {
            return a.Equals(b);
        }
        public static bool operator ==(VoiceWord a, object b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(VoiceWord a, object b)
        {
            return !a.Equals(b);
        }
        public override int GetHashCode()
        {
            return ((ValueType)(object)this).GetHashCode();
        }
    }
    public struct VoicePattern
    {
        private string _id;
        private string _pattern;
        public string PatternId
        {
            get { return this._id; }
            set { this._id = value; }
        }
        public string Pattern
        {
            get { return this._pattern; }
            set { this.Pattern = value; }
        }
        public VoicePattern(string PatternId, string Pattern)
        {
            if (string.IsNullOrWhiteSpace(PatternId))
            {
                throw new ArgumentException();
            }
            this._id = PatternId;
            this._pattern = Pattern;
        }
        public bool Equals(VoicePattern pattern)
        {
            if ((pattern.PatternId == this._id) && (pattern.Pattern == this._pattern))
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj is VoicePattern)
            {
                return this.Equals((VoicePattern)obj);
            }
            return false;
        }
        public static bool Equals(VoicePattern a, VoicePattern b)
        {
            return a.Equals(b);
        }
        public static bool operator ==(VoicePattern a, object b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(VoicePattern a, object b)
        {
            return !a.Equals(b);
        }
        public override int GetHashCode()
        {
            return ((ValueType)(object)this).GetHashCode();
        }
    }
    public enum HearingResultType
    {
        Free = 11,
        Sentence = 21,
        Word = 31,
        YesNo_Yes = 41,
        YesNo_No = 42,
        YesNo_Cancel = 43
    }

    public enum HearingStatusType
    {
        None = 0,
        Free = 10,
        Sentence = 20,
        Word = 30,
        YesNo = 40,
    }

    public static class IVoiceRecognition116Constants
    {
        public const int statusStopHearing = 0;
        public const int statusStartHearingFree = 10;
        public const int statusStartHearingSentence = 20;
        public const int statusStartHearingWord = 30;
        public const int statusStartHearingYesNo = 40;
    }

    public interface IVoiceRecognition116
    {
        bool CapLanguage { get; }
        string HearingDataPattern { get; }
        string HearingDataWord { get; }
        VoiceWord[] HearingDataWordList { get; }
        HearingResultType HearingResult { get; }
        HearingStatusType HearingStatus { get; }
        string[] LanguageList { get; }
        void StartHearingFree(string language);
        void StartHearingSentence(string language, IEnumerable<VoiceWord> wordList, IEnumerable<VoicePattern> patternList);
        void StartHearingWord(string language, IEnumerable<string> wordList);
        void StartHearingYesNo(string language);
        void StopHearing();
    }
}