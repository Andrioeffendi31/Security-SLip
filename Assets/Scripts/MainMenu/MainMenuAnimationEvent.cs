using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimationEvent : MonoBehaviour
{
    [SerializeField]
    private MainMenuBtn mainMenu;

    public void AnimationComplete()
    {
        mainMenu.animationComplete = true;
    }
}
