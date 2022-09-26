# Additional features of UnifiedPOS version 1.16 to be added to POS for.NET 1.14.1

This is an extended DLL that supports interfaces and definitions to add additional features of UnifiedPOS version 1.16 to POS for.NET 1.14.1.  

- Added Pattern related property/methods, multiple lights on method to Lights device.  
- Added battery status report in seconds related properties of PosPower device.  
- Added RCSD(Retail Communication Service Devices) related interfaces.  


## Development/Execuion environment

To develop and run this program, service object, or application, you need:

- Visual Studio 2022 or Visual Studio Community 2022  version 17.3.4 (development only)  
- .NET framework 4.8  
- Microsoft Point of Service for .NET v1.14.1 (POS for.NET) : https://www.microsoft.com/en-us/download/details.aspx?id=55758  

## Install/Uninstall

Since the following batch files are prepared, please execute them as an administrator.

- RegisterExt116.bat
- UnregisterExt116.bat


## Interface

"116" is added to the interface name, existing Enum, and property name for identification.

- for existing devices
  - Enum definition
    - LightPatterns : added

  - interface definition
    - ILights116
      - CapPattern property added.
      - Added SwitchOnPattern,SwitchOffPattern,SwitchOnMultiple methods.
    - IPosPower116
      - battery status report in seconds related properties added.

- for new devices
  - Enum definition
    - CapStorageType
    - StorageType
    - MonitoringModeType
    - DisplayModeType
    - LoadStatusType
    - VideoCaptureModeType

  - struct definition
    - GestureJoint
    - GesturePosition
    - GestureSpeed
    - IndividualIdName
    - VoiceWord
    - VoicePattern

  - statusupdate etc. constants definition
    - IDeviceMonitor116Constants
    - IGestureControl116Constants
    - IGraphicDisplay116Constants
    - ISoundPlayer116Constants
    - ISoundRecorder116Constants
    - ISpeechSynthesis116Constants
    - IVideoCapture116Constants
    - IVoiceRecognition116Constants

  - interface definition
    - IDeviceMonitor116
    - IGestureControl116
    - IGraphicDisplay116
    - IIndividualRecognition116
    - ISoundPlayer116
    - ISoundRecorder116
    - ISpeechSynthesis116
    - IVideoCapture116
    - IVoiceRecognition116


## Example of use

- When developing service objects and applications that use them.

  - Add "OpenPOS.Extension.Ver116" to the project reference (found below).
    "C:\\Windows\\Microsoft.NET\\assembly\\GAC_MSIL\\OpenPOS.Extension.Ver116\\v4.0_1.16.0.0__ad2c9a67c3439201\\OpenPOS.Extension.Ver116.dll"
  - Add "using OpenPOS.Extension;" to the source code.

- Class definition in service object implementation

  - When using OPOS, add "using OpenPOS.Devices;" to the source code.
  - When developing a service object, inherit the corresponding device class and add the interface for version 1.16.

Example code:


    [ServiceObject(DeviceType.Lights, "OpenPOS 1.16 Lights", "OPOS Lights CCO Interop", 1, 16)]
    public class OpenPOSLights : Lights, ILights116, ILegacyControlObject, IDisposable
    {
        ...
    }

- Application Examples

  - Check whether the interface of OpenPOS.Extension.Ver116 is included and then call the method of UnifoedPOS 1.16.  

Example code:


    // The object is declared in Lights litsObj1
    
    try
    {
        if (litsObj1 is ILights116)
        {
            if ((((ILights116) litsObj1).CapPattern & LightPatterns.Custom1) == LightPatterns.Custom1)
            {
                try
                {
                    ((ILights116) litsObj1).SwitchOnPattern(LightPatterns.Custom1, LightAlarms.Medium);
                }
                catch(UPOSException ue)
                {
                }
            }
        }
    }
    catch(Exception ae)
    {
    }


## Known issues

Currently known issues are as follows.

- The actual operation using the service object, OPOS and device has not been confirmed.  

## License

Licensed under the [zlib License](./LICENSE).
