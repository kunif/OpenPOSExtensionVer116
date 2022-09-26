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
    public struct IndividualIdName
    {
        private string _id;
        private string _name;
        public string Id
        {
            get { return this._id; }
        }
        public string Name
        {
            get { return this._name; }
        }
        public IndividualIdName(string Id, string Name)
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                throw new ArgumentException();
            }
            this._id = Id;
            this._name = Name;
        }
        public bool Equals(IndividualIdName joint)
        {
            if ((joint.Id == this._id) && (joint.Name == this._name))
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj is IndividualIdName)
            {
                return this.Equals((IndividualIdName)obj);
            }
            return false;
        }
        public static bool Equals(IndividualIdName a, IndividualIdName b)
        {
            return a.Equals(b);
        }
        public static bool operator ==(IndividualIdName a, object b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(IndividualIdName a, object b)
        {
            return !a.Equals(b);
        }
        public override int GetHashCode()
        {
            return ((ValueType)(object)this).GetHashCode();
        }
    }

    public interface IIndividualRecognition116
    {
        IndividualIdName[] CapIndividualList { get; }
        string[] IndividualIDs { get; }
        string IndividualRecognitionFilter { get; set; }
        string IndividualRecognitionInformation { get; }
    }
}