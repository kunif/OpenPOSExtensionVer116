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
    using Microsoft.PointOfService;

    public static class ISoundRecorder116Constants
    {
        public const int statusStartSoundRecording = 11;
        public const int statusStopSoundRecording = 12;
        public const int ExtendedErrorNoRoom = 201;
    }

    public interface ISoundRecorder116
    {
        string CapAssociatedHardTotalsDevice { get; }
        bool CapChannel { get; }
        bool CapRecordingLevel { get; }
        bool CapSamplingRate { get; }
        bool CapSoundType { get; }
        CapStorageType CapStorage { get; }
        string Channel { get; set; }
        string[] ChannelList { get; }
        int RecordingLevel { get; set; }
        int RemainingRecordingTimeInSec { get; }
        string SamplingRate { get; set; }
        string[] SamplingRateList { get; }
        byte[] SoundData { get; }
        string SoundType { get; set; }
        string[] SoundTypeList { get; }
        StorageType Storage { get; set; }
        void StartRecording(string fileName, bool overWrite, int recordingTime);
        void StopRecording();
    }
}