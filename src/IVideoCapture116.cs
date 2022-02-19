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
    public enum VideoCaptureModeType
    {
        Photo = 1,
        Video
    }
    public static class IVideoCapture116Constants
    {
        public const int statusStartPhoto = 11;
        public const int statusEndPhoto = 12;
        public const int statusStartVideo = 21;
        public const int statusStopVideo = 22;
        public const int ExtendedErrorNoRoom = 201;
    }

    public interface IVideoCapture116
    {
        bool AutoExposure { get; set; }
        bool AutoFocus { get; set; }
        bool AutoGain { get; set; }
        bool AutoWhiteBalance { get; set; }
        int Brightness { get; set; }
        string CapAssociatedHardTotalsDevice { get; }
        bool CapAutoExposure { get; }
        bool CapAutoFocus { get; }
        bool CapAutoGain { get; }
        bool CapAutoWhiteBalance { get; }
        bool CapBrightness { get; }
        bool CapContrast { get; }
        bool CapExposure { get; }
        bool CapGain { get; }
        bool CapHorizontalFlip { get; }
        bool CapHue { get; }
        bool CapPhoto { get; }
        bool CapPhotoColorSpace { get; }
        bool CapPhotoFrameRate { get; }
        bool CapPhotoResolution { get; }
        bool CapPhotoType { get; }
        bool CapSaturation { get; }
        CapStorageType CapStorage { get; }
        bool CapVerticalFlip { get; }
        bool CapVideo { get; }
        bool CapVideoColorSpace { get; }
        bool CapVideoFrameRate { get; }
        bool CapVideoResolution { get; }
        bool CapVideoType { get; }
        int Contrast { get; set; }
        int Exposure { get; set; }
        int Gain { get; set; }
        bool HorizontalFlip { get; set; }
        int Hue { get; set; }
        string PhotoColorSpace { get; set; }
        string[] PhotoColorSpaceList { get; }
        int PhotoFrameRate { get; set; }
        int PhotoMaxFrameRate { get; }
        string PhotoResolution { get; set; }
        string[] PhotoResolutionList { get; }
        string PhotoType { get; set; }
        string[] PhotoTypeList { get; }
        int RemainingRecordingTimeInSec { get; }
        int Saturation { get; set; }
        StorageType Storage { get; set; }
        bool VerticalFlip { get; set; }
        VideoCaptureModeType VideoCaptureMode { get; set; }
        string VideoColorSpace { get; set; }
        string[] VideoColorSpaceList { get; }
        int VideoFrameRate { get; set; }
        int VideoMaxFrameRate { get; }
        string VideoResolution { get; set; }
        string[] VideoResolutionList { get; }
        string VideoType { get; set; }
        string[] VideoTypeList { get; }

        void StartVideo(string fileName, bool overWrite, int recordingTime);
        void StopVideo();
        void TakePhoto(string fileName, bool overWrite, int timeout);

    }
}