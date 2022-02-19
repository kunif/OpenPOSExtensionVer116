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

    [Flags]
    public enum LightPatterns
    {
        NoPattern = 0,
        Custom1 = 0x00000001,
        Custom2 = 0x00000002,
        Custom3 = 0x00000004,
        Custom4 = 0x00000008,
        Custom5 = 0x00000010,
        Custom6 = 0x00000020,
        Custom7 = 0x00000040,
        Custom8 = 0x00000080,
        Custom9 = 0x00000100,
        Custom10 = 0x00000200,
        Custom11 = 0x00000400,
        Custom12 = 0x00000800,
        Custom13 = 0x00001000,
        Custom14 = 0x00002000,
        Custom15 = 0x00004000,
        Custom16 = 0x00008000,
        Custom17 = 0x00010000,
        Custom18 = 0x00020000,
        Custom19 = 0x00040000,
        Custom20 = 0x00080000,
        Custom21 = 0x00100000,
        Custom22 = 0x00200000,
        Custom23 = 0x00400000,
        Custom24 = 0x00800000,
        Custom25 = 0x01000000,
        Custom26 = 0x02000000,
        Custom27 = 0x04000000,
        Custom28 = 0x08000000,
        Custom29 = 0x10000000,
        Custom30 = 0x20000000,
        Custom31 = 0x40000000,
        Custom32 = -2147483648
    }

    public interface ILights116
    {
        LightPatterns CapPattern { get; }
        void SwitchOnPattern(LightPatterns pattern, LightAlarms alarm);
        void SwitchOffPattern();
        void SwitchOnMultiple(IEnumerable<int> lightNumbers, int blinkOnCycle, int blinkOffCycle, LightColors color, LightAlarms alarm);
    }
}