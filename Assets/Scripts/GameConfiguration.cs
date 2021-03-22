using System.Collections;
using System.Collections.Generic;

public static class GameConfiguration
{
    public static bool DebugMode { get; set; }

    public static void ResetToDefault()
    {
        DebugMode = false;
    }
}
