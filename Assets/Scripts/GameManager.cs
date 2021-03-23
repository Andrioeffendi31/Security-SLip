using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlaying;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        
    }
}
