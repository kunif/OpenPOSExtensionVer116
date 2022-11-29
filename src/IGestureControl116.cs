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

    public struct GestureJoint
    {
        private string _id;
        private bool _range;
        public string JointId
        {
            get { return this._id; }
        }
        public bool Range
        {
            get { return this._range; }
        }
        public GestureJoint(string JointId, bool Range)
        {
            if (string.IsNullOrWhiteSpace(JointId))
            {
                throw new ArgumentException();
            }
            this._id = JointId;
            this._range = Range;
        }
        public bool Equals(GestureJoint joint)
        {
            if ((joint.JointId == this._id) && (joint.Range == this._range))
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj is GestureJoint)
            {
                return this.Equals((GestureJoint)obj);
            }
            return false;
        }
        public static bool Equals(GestureJoint a, GestureJoint b)
        {
            return a.Equals(b);
        }
        public static bool operator ==(GestureJoint a, object b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(GestureJoint a, object b)
        {
            return !a.Equals(b);
        }
        public override int GetHashCode()
        {
            return ((ValueType)(object)this).GetHashCode();
        }
    }
    public struct GesturePosition
    {
        private string _id;
        private int _position;
        public string JointId
        {
            get { return this._id; }
            set { this._id = value; }
        }
        public int Position
        {
            get { return this._position; }
            set { this.Position = value; }
        }
        public GesturePosition(string JointId, int Position)
        {
            if (string.IsNullOrWhiteSpace(JointId))
            {
                throw new ArgumentException();
            }
            this._id = JointId;
            this._position = Position;
        }
        public bool Equals(GesturePosition joint)
        {
            if ((joint.JointId == this._id) && (joint.Position == this._position))
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj is GesturePosition)
            {
                return this.Equals((GesturePosition)obj);
            }
            return false;
        }
        public static bool Equals(GesturePosition a, GesturePosition b)
        {
            return a.Equals(b);
        }
        public static bool operator ==(GesturePosition a, object b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(GesturePosition a, object b)
        {
            return !a.Equals(b);
        }
        public override int GetHashCode()
        {
            return ((ValueType)(object)this).GetHashCode();
        }
    }
    public struct GestureSpeed
    {
        private string _id;
        private int _speed;
        public string JointId
        {
            get { return this._id; }
            set { this._id = value; }
        }
        public int Speed
        {
            get { return this._speed; }
            set { this.Speed = value; }
        }
        public GestureSpeed(string JointId, int Speed)
        {
            if (string.IsNullOrWhiteSpace(JointId))
            {
                throw new ArgumentException();
            }
            this._id = JointId;
            this._speed = Speed;
        }
        public bool Equals(GestureSpeed joint)
        {
            if ((joint.JointId == this._id) && (joint.Speed == this._speed))
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj is GestureSpeed)
            {
                return this.Equals((GestureSpeed)obj);
            }
            return false;
        }
        public static bool Equals(GestureSpeed a, GestureSpeed b)
        {
            return a.Equals(b);
        }
        public static bool operator ==(GestureSpeed a, object b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(GestureSpeed a, object b)
        {
            return !a.Equals(b);
        }
        public override int GetHashCode()
        {
            return ((ValueType)(object)this).GetHashCode();
        }
    }
    public static class IGestureControl116Constants
    {
        public const int statusStartMotion = 11;
        public const int statusStopMotion = 12;
        public const int ExtendedErrorNoRoom = 201;
    }

    public interface IGestureControl116
    {
        string AutoMode { get; set; }
        string[] AutoModeList { get; }
        string CapAssociatedHardTotalsDevice { get; }
        bool CapMotion { get; }
        bool CapMotionCreation { get; }
        bool CapPose { get; }
        bool CapPoseCreation { get; }
        CapStorageType CapStorage { get; }
        GestureJoint[] JointList { get; }
        string[] MotionList { get; }
        bool PoseCreationMode { get; set; }
        string[] PoseList { get; }
        StorageType Storage { get; set; }
        void CreateMotion(string fileName, string[] poseList);
        void CreatePose(string fileName, int time);
        int GetPosition(string jointId);
        void SetPosition(IEnumerable<GesturePosition> positionList, int time, bool absolute);
        void SetSpeed(IEnumerable<GestureSpeed> speedList, int time);
        void StartMotion(string fileName);
        void StartPose(string fileName);
        void StopControl(int outputId);
    }
}