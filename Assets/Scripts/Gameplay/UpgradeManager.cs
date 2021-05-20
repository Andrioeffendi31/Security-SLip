using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField]
    private UpgradeTooltip tooltip;

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
            case 1:
                price = 10;
                break;

            case 2:
                price = 20;
                break;

            case 3:
                price = 50;
                break;

            case 4:
                price = 75;
                break;

            case 5:
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
            case 1:
                price = 10;
                break;

            case 2:
                price = 20;
                break;

            case 3:
                price = 40;
                break;

            case 4:
                price = 50;
                break;

            case 5:
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
            case 1:
                price = 5;
                break;

            case 2:
                price = 10;
                break;

            case 3:
                price = 30;
                break;

            case 4:
                price = 75;
                break;

            case 5:
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
            case 1:
                price = 10;
                break;

            case 2:
                price = 20;
                break;

            case 3:
                price = 40;
                break;

            case 4:
                price = 50;
                break;

            case 5:
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
}
