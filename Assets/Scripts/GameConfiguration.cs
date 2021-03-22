using System.Collections;
using System.Collections.Generic;

public static class GameConfiguration
{
    public static bool DebugMode { get; set; }
    public static int secondPerRealSecond { get; set; } = 70;

    public static void ResetToDefault()
    {
        DebugMode = false;
        secondPerRealSecond = 70;
    }
}
