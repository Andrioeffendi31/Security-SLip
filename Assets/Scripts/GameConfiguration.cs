using System;
using System.Collections;
using System.Collections.Generic;

public static class GameConfiguration
{
    public static bool DebugMode { get; set; }

    public static DateTime gameTime { get; set; }

    public static int secondPerRealSecond { get; set; }

    public static string startCardID { get; set; }

    public static int minCardID { get; set; }

    public static int maxCardID { get; set; }

    public static int generatedRangeCardDate { get; set; }

    /// <summary>
    /// Main game configuration
    /// </summary>
    public static void Initialize()
    {
        startCardID = "310771";
        minCardID = 50;
        maxCardID = 1337;
        generatedRangeCardDate = 5;

        DebugMode = true;
        
        // year month day hour minute second
        gameTime = new DateTime(2021, 3, 20, 7, 0, 0);
        secondPerRealSecond = 15;
    }

    public static void ResetToDefault() { }
}
