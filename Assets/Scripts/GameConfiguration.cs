using System.Collections;
using System.Collections.Generic;

public static class GameConfiguration
{
    public static bool DebugMode { get; set; } = false;
    public static int secondPerRealSecond { get; set; } = 15;

    public static void ResetToDefault()
    {
        DebugMode = false;
        secondPerRealSecond = 70;
    }
}
