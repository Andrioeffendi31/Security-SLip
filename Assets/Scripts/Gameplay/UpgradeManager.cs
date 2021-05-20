using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField]
    private GameplayController gameplayController;
    
    [SerializeField]
    private UpgradeTooltip tooltip;

    [SerializeField]
    private Sprite upgradedIcon;

    [SerializeField]
    private Text fasterSearchTextLevel;

    [SerializeField]
    private GameObject[] fasterSearchStep;

    [SerializeField]
    private Text betterDecorationTextLevel;

    [SerializeField]
    private GameObject[] betterDecorationStep;

    [SerializeField]
    private Text scoreMultiplierTextLevel;

    [SerializeField]
    private GameObject[] scoreMultiplierStep;

    [SerializeField]
    private Text betterMusicTextLevel;

    [SerializeField]
    private GameObject[] betterMusicStep;

    [SerializeField]
    private GameObject[] decorationSets;

    private int price;

    private bool allowToBuy;

    void Start()
    {
        price = 0;
        allowToBuy = false;
    }

    public void onEnterHoverFaster()
    {
        switch (GameConfiguration.searchLevel)
        {
            case 0:
                price = 10;
                break;

            case 1:
                price = 20;
                break;

            case 2:
                price = 50;
                break;

            case 3:
                price = 75;
                break;

            case 4:
                price = 100;
                break;
        }

        tooltip.ShowTooltip(price);
        allowToBuy = true;
    }

    public void onEnterHoverDecoration()
    {
        switch (GameConfiguration.decorationLevel)
        {
            case 0:
                price = 10;
                break;

            case 1:
                price = 20;
                break;

            case 2:
                price = 40;
                break;

            case 3:
                price = 50;
                break;

            case 4:
                price = 75;
                break;
        }

        tooltip.ShowTooltip(price);
        allowToBuy = true;
    }

    public void onEnterHoverScoreMultiplier()
    {
        switch (GameConfiguration.scoreLevel)
        {
            case 0:
                price = 5;
                break;

            case 1:
                price = 10;
                break;

            case 2:
                price = 30;
                break;

            case 3:
                price = 75;
                break;

            case 4:
                price = 100;
                break;
        }

        tooltip.ShowTooltip(price);
        allowToBuy = true;
    }

    public void onEnterHoverBetterMusic()
    {
        switch (GameConfiguration.musicLevel)
        {
            case 0:
                price = 10;
                break;

            case 1:
                price = 20;
                break;

            case 2:
                price = 40;
                break;

            case 3:
                price = 50;
                break;

            case 4:
                price = 100;
                break;
        }

        tooltip.ShowTooltip(price);
        allowToBuy = true;
    }

    public void onExitHover()
    {
        tooltip.HideTooltip();
        allowToBuy = false;
    }

    public void onClickUpgradeFaster()
    {
        if (allowToBuy && gameplayController.RemoveScore(price))
        {
            switch (GameConfiguration.searchLevel)
            {
                // Upgrade to level 1
                case 0:
                    GameConfiguration.databaseSearchTime = 17;
                    break;

                // Upgrade to level 2
                case 1:
                    GameConfiguration.databaseSearchTime = 15;
                    break;

                // Upgrade to level 3
                case 2:
                    GameConfiguration.databaseSearchTime = 13;
                    break;

                // Upgrade to level 4
                case 3:
                    GameConfiguration.databaseSearchTime = 10;
                    break;

                // Upgrade to level 5
                case 4:
                    GameConfiguration.databaseSearchTime = 5;
                    break;

                // Level already maxed out
                case 5:
                    LevelMax();
                    return;
            }
            
            // Activated sprite accoring to the level
            fasterSearchStep[GameConfiguration.searchLevel].GetComponent<Image>().sprite = upgradedIcon;
            fasterSearchStep[GameConfiguration.searchLevel].SetActive(true);

            // Increment level
            GameConfiguration.searchLevel++;

            // Set level text accoring to the level
            fasterSearchTextLevel.text = $"Lv.{GameConfiguration.searchLevel}";

            onEnterHoverFaster();

            return;
        }

        // Not enough balance
        NotEnoughScore();
    }

    public void onClickUpgradeDecoration()
    {
        if (allowToBuy && gameplayController.RemoveScore(price))
        {
            switch (GameConfiguration.decorationLevel)
            {
                // Upgrade to level 1
                case 0:
                    decorationSets[0].SetActive(true);

                    GameConfiguration.maxPatientLevel += 5;
                    break;

                // Upgrade to level 2
                case 1:
                    decorationSets[1].SetActive(true);

                    GameConfiguration.maxPatientLevel += 5;
                    break;

                // Upgrade to level 3
                case 2:
                    decorationSets[1].SetActive(false);
                    decorationSets[2].SetActive(true);

                    GameConfiguration.maxPatientLevel += 5;
                    break;

                // Upgrade to level 4
                case 3:
                    decorationSets[3].SetActive(true);

                    GameConfiguration.minPatientLevel += 10;
                    break;

                // Upgrade to level 5
                case 4:
                    decorationSets[4].SetActive(true);

                    GameConfiguration.minPatientLevel += 10;
                    GameConfiguration.maxPatientLevel += 10;
                    break;

                // Level already maxed out
                case 5:
                    LevelMax();
                    return;
            }

            // Activated sprite accoring to the level
            betterDecorationStep[GameConfiguration.decorationLevel].GetComponent<Image>().sprite = upgradedIcon;
            betterDecorationStep[GameConfiguration.decorationLevel].SetActive(true);

            // Increment level
            GameConfiguration.decorationLevel++;

            // Set level text accoring to the level
            betterDecorationTextLevel.text = $"Lv.{GameConfiguration.decorationLevel}";

            onEnterHoverDecoration();

            return;
        }

        // Not enough balance
        NotEnoughScore();
    }

    public void onClickUpgradeScoreMultiplier()
    {
        if (allowToBuy && gameplayController.RemoveScore(price))
        {
            switch (GameConfiguration.scoreLevel)
            {
                // Upgrade to level 1
                case 0:
                    GameConfiguration.scoreMultiplier = 2;
                    break;

                // Upgrade to level 2
                case 1:
                    GameConfiguration.scoreMultiplier = 4;
                    break;

                // Upgrade to level 3
                case 2:
                    GameConfiguration.scoreMultiplier = 6;
                    break;

                // Upgrade to level 4
                case 3:
                    GameConfiguration.scoreMultiplier = 10;
                    break;

                // Upgrade to level 5
                case 4:
                    GameConfiguration.scoreMultiplier = 20;
                    break;

                // Level already maxed out
                case 5:
                    LevelMax();
                    return;
            }

            // Activated sprite accoring to the level
            scoreMultiplierStep[GameConfiguration.scoreLevel].GetComponent<Image>().sprite = upgradedIcon;
            scoreMultiplierStep[GameConfiguration.scoreLevel].SetActive(true);

            // Increment level
            GameConfiguration.scoreLevel++;

            // Set level text accoring to the level
            scoreMultiplierTextLevel.text = $"Lv.{GameConfiguration.scoreLevel}";

            onEnterHoverScoreMultiplier();

            return;
        }

        // Not enough balance
        NotEnoughScore();
    }

    public void onClickUpgradeBetterMusic()
    {
        if (allowToBuy && gameplayController.RemoveScore(price))
        {
            switch (GameConfiguration.musicLevel)
            {
                // Upgrade to level 1
                case 0:
                    GameConfiguration.maxPatientLevel += 5;
                    break;

                // Upgrade to level 2
                case 1:
                    GameConfiguration.maxPatientLevel += 5;
                    break;

                // Upgrade to level 3
                case 2:
                    GameConfiguration.maxPatientLevel += 5;
                    break;

                // Upgrade to level 4
                case 3:
                    GameConfiguration.minPatientLevel += 10;
                    break;

                // Upgrade to level 5
                case 4:
                    GameConfiguration.minPatientLevel += 10;
                    GameConfiguration.maxPatientLevel += 10;
                    break;

                // Level already maxed out
                case 5:
                    LevelMax();
                    return;
            }
            
            // Activated sprite accoring to the level
            betterMusicStep[GameConfiguration.musicLevel].GetComponent<Image>().sprite = upgradedIcon;
            betterMusicStep[GameConfiguration.musicLevel].SetActive(true);

            // Increment level
            GameConfiguration.musicLevel++;

            // Update current background music
            gameplayController.UpdateBGMAudio();

            // Set level text accoring to the level
            betterMusicTextLevel.text = $"Lv.{GameConfiguration.musicLevel}";

            onEnterHoverBetterMusic();

            return;
        }

        // Not enough balance
        NotEnoughScore();
    }

    public void NotEnoughScore()
    {
        // Show not enough score popup
        Debug.Log("NOT ENOUGH SCORE!");
    }

    public void LevelMax()
    {
        // Show level already maxed out
        Debug.Log("LEVEL ALREADY MAXED OUT!");
    }
}