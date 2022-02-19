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
    public enum DisplayModeType
    {
        Hidden = 1,
        ImageFit,
        ImageFill,
        ImageCenter,
        VideoNormal,
        VideoFull,
        Web
    }

    public enum LoadStatusType
    {
        Start = 1,
        Finish,
        Cancel
    }

    public static class GraphicDisplay116Constants
    {
        public const int statusStartImageLoad = 11;
        public const int statusEndImageLoad = 12;
        public const int statusStartLoadWebPage = 21;
        public const int statusFinishLoadWebPage = 22;
        public const int statusCancelLoadWebPage = 23;
        public const int statusStartPlayVideo = 31;
        public const int statusStopPlayVideo = 32;
        public const int ExtendedErrorNoRoom = 201;
    }

    public interface IGraphicDisplay116
    {
        int Brightness { get; set; }
        string CapAssociatedHardTotalsDevice { get; }
        bool CapBrightness { get; }
        bool CapImageType { get; }
        CapStorageType CapStorage { get; }
        bool CapURLBack { get; }
        bool CapURLForward { get; }
        bool CapVideoType { get; }
        bool CapVolume { get; }
        DisplayModeType DisplayMode { get; set; }
        string ImageType { get; set; }
        string[] ImageTypeList { get; }
        LoadStatusType LoadStatus { get; }
        StorageType Storage { get; set; }
        string URL { get; }
        string VideoType { get; set; }
        string[] VideoTypeList { get; }
        int Volume { get; set; }
        void CancelURLLoading();
        void GoURLBack();
        void GoURLForward();
        void LoadImage(string fileName);
        void LoadURL(string url);
        void PlayVideo(string fileName, bool loop);
        void StopVideo();
        void UpdateURLPage();
    }
}