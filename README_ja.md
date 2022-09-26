# POS for.NET 1.14.1 に付加する UnifiedPOS version 1.16 の追加機能

これは UnifiedPOS version 1.16 の追加機能を POS for.NET 1.14.1 に付加するためのインタフェースや定義をサポートした拡張DLLです。  

- Lightsデバイスへパターン点灯/消灯,複数同時点灯機能を追加  
- PosPowerデバイスへ秒単位のバッテリー状態通知関連プロパティ追加  
- RCSD(リテイルコミュニケーションサービスデバイス)関連インタフェース追加  


## 開発/実行環境

このプログラムやサービスオブジェクト、アプリケーションの開発および実行には以下が必要です。

- Visual Studio 2022またはVisual Studio Community 2022 version 17.3.4 (開発のみ)  
- .NET framework 4.8  
- Microsoft Point of Service for .NET v1.14.1 (POS for.NET) : https://www.microsoft.com/en-us/download/details.aspx?id=55758  


## インストール/アンインストール

以下のバッチファイルを用意しているので、それを管理者として実行してください。

- RegisterExt116.bat
- UnregisterExt116.bat


## インタフェース

インタフェース名や既存のEnum,プロパティ名に、識別のために"116"を付加しています。

- 既存デバイスへの機能拡張
  - Enum定義
    - LightPatterns : 追加

  - インタフェース定義
    - ILights116
      - CapPatternプロパティ追加
      - SwitchOnPattern,SwitchOffPattern,SwitchOnMultipleメソッド追加
    - IPosPower116
      - 秒単位のバッテリー状態通知関連プロパティ追加

- 新デバイスの各種定義
  - Enum定義
    - CapStorageType
    - StorageType
    - MonitoringModeType
    - DisplayModeType
    - LoadStatusType
    - VideoCaptureModeType

  - struct定義
    - GestureJoint
    - GesturePosition
    - GestureSpeed
    - IndividualIdName
    - VoiceWord
    - VoicePattern

  - statusupdate等定数定義
    - IDeviceMonitor116Constants
    - IGestureControl116Constants
    - IGraphicDisplay116Constants
    - ISoundPlayer116Constants
    - ISoundRecorder116Constants
    - ISpeechSynthesis116Constants
    - IVideoCapture116Constants
    - IVoiceRecognition116Constants

  - インタフェース定義
    - IDeviceMonitor116
    - IGestureControl116
    - IGraphicDisplay116
    - IIndividualRecognition116
    - ISoundPlayer116
    - ISoundRecorder116
    - ISpeechSynthesis116
    - IVideoCapture116
    - IVoiceRecognition116


## 使用例

- サービスオブジェクト開発時、およびそれを利用するアプリケーション開発時

  - プロジェクトの参照に"OpenPOS.Extension.Ver116"を追加する(以下にある)
    "C:\\Windows\\Microsoft.NET\\assembly\\GAC_MSIL\\OpenPOS.Extension.Ver116\\v4.0_1.16.0.0__ad2c9a67c3439201\\OpenPOS.Extension.Ver116.dll"
  - ソースコードに"using OpenPOS.Extension;"を追加する

- サービスオブジェクト実装時のクラス定義

  - OPOSを呼び出す場合はソースコードに"using OpenPOS.Devices;"を追加する
  - サービスオブジェクトを開発する際は、該当デバイスクラスを継承すると共に、version 1.16用のインタフェースも追加する

コード例:

    [ServiceObject(DeviceType.Lights, "OpenPOS 1.16 Lights", "OPOS Lights CCO Interop", 1, 16)]
    public class OpenPOSLights : Lights, ILights116, ILegacyControlObject, IDisposable
    {
        ...
    }

- アプリケーションでの使用例

  - OpenPOS.Extension.Ver116のインターフェースを含んでいるかを確認してから UnifoedPOS 1.16 のメソッドを呼び出す  

コード例:


    // オブジェクトが Lights litsObj1 で宣言されている
    
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


## 既知の課題   

既知の課題は以下になります。

- 実際のサービスオブジェクト、OPOSやデバイスを使った動作確認は行っていません。  

## ライセンス

[zlib License](./LICENSE) の下でライセンスされています。
