using System;
using System.Collections;
using System.Collections.Generic;

public static class GameConfiguration
{
    public static bool DebugMode { get; set; }

    public static DateTime gameTime { get; set; }

    public static int millisecondPerRealMillisecond { get; set; }

    public static string startCardID { get; set; }

    public static int minCardID { get; set; }

    public static int maxCardID { get; set; }

    public static int generatedRangeCardDate { get; set; }

    public static int minPatientLevel { get; set; }

    public static int maxPatientLevel { get; set; }

    public static int searchLevel { get; set; }

    public static int decorationLevel { get; set; }

    public static int scoreLevel { get; set; }

    public static int musicLevel { get; set; }

    public static int databaseSearchTime { get; set; }

    public static int scoreMultiplier { get; set; }

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
        millisecondPerRealMillisecond = 10000;

        // Game Difficulty
        // Patient Level in seconds
        minPatientLevel = 30;
        maxPatientLevel = 60;
        databaseSearchTime = 20;

        // Upgrade perks
        searchLevel = 0;
        decorationLevel = 0;
        scoreLevel = 0;
        scoreMultiplier = 1;
        musicLevel = 0;
    }

    public static void ResetToDefault() { }

    public static void Stage1() { }

    public static void Stage2() { }

    public static void Stage3() { }
}
