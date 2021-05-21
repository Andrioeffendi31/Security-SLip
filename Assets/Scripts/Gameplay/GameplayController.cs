using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    private readonly string PAUSE_WARNING = "What do you think you are doing?! Keep WORKING!!!";
    private readonly string ONE_STRIKE = "I'm warning you! (1 Strikes)";
    private readonly string TWO_STRIKE = "Are you challenging me!? (2 Strikes)";
    private readonly string THREE_STRIKE = "1 More mistake and your D.E.A.D!";

    private readonly InfoRandomizer infoRandomizer = new InfoRandomizer();

    [SerializeField]
    private CardController cardController;

    [SerializeField]
    private NameComputer nameComputer;

    [SerializeField]
    private ApprovalSystem ApprovalSystem = new ApprovalSystem();

    [SerializeField]
    private Text scoreText;
    
    [SerializeField]
    private Text upgradeBalance;

    [SerializeField]
    private ClockSystem clockSystem;

    [SerializeField]
    private CharacterGenerator characterGenerator;

    [SerializeField]
    private GameObject DirectionalLight;

    [SerializeField]
    private Material skyboxMaterial;

    [SerializeField]
    private TextTypeWrite pauseText;

    [SerializeField]
    private TextTypeWrite notificationStrikeOne;

    [SerializeField]
    private TextTypeWrite notificationStrikeTwo;

    [SerializeField]
    private TextTypeWrite notificationStrikeThree;

    private Color fogDayColor;

    private Color fogNightColor;

    private AudioManager audioManager;

    private GameObject character;

    private CharacterLogic characterLogic;

    private Character characterInfo;

    private GameManager gameManager;

    public bool allowToChoose { get; set; }

    private int score;

    private int overallScore;

    private int minPatientLevelDrop;

    private int maxPatientLevelDrop;

    private int penaltyCount;

    private bool statusNotificationBubble;

    private bool tryToPauseOnce;

    private void Start()
    {
        Init();
    }
    
    private void Update()
    {
        // Light system
        LightDirection();

        GameClock();

        // // Game Over
        // if (clockSystem.GetCurrentDateTime().Hour >= 8)
        //     gameManager.GoToMainMenu();
    }

    private void GameClock()
    {
        GameConfiguration.gameTime = clockSystem.GetCurrentDateTime();
    }

    private void LightDirection()
    {
        DateTime theTime = clockSystem.GetCurrentDateTime();
        float seconds = (theTime.Hour * 3600) + (theTime.Minute * 60) + theTime.Second;

        // Change sun position
        DirectionalLight.transform.localRotation = Quaternion.Euler((seconds * 0.0041667f) - 90, -60, 0);

        // Blend skybox material
        float blendTime = (-(seconds * seconds) / 1866240000) + (seconds / 21600);
        skyboxMaterial.SetFloat("_BlendCubemaps", blendTime);

        // Rotate skybox
        skyboxMaterial.SetFloat("_Rotation", (seconds / 90060) * 360);

        // Blend fog color
        RenderSettings.fogColor = Color.Lerp(fogNightColor, fogDayColor, blendTime);
    }

    private void Init()
    {
        // Set skybox material
        RenderSettings.skybox = skyboxMaterial;

        // Set fog color
        fogDayColor = new Color32(202, 237, 250, 255);
        fogNightColor = new Color32(0, 0, 0,255);

        // Attach to Game Manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.StartGame(this);

        // Default value
        minPatientLevelDrop = 0;
        maxPatientLevelDrop = 0;

        score = 0;

        penaltyCount = 0;
        tryToPauseOnce = false;

        scoreText.text = score.ToString();
        upgradeBalance.text = $"Score: {score.ToString()}";
        allowToChoose = false;
        
        // Set Game Time and start the clock
        clockSystem.SetStartDateTime(GameConfiguration.gameTime);
        clockSystem.StartClock();

        // Spawn the first character
        SpawnCharacter();

        // Debug start game time
        if (GameConfiguration.DebugMode)
            Debug.Log("Start DateTime: " + clockSystem.GetCurrentDateTime());

        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();

        UpdateBGMAudio();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
        upgradeBalance.text = $"Score: {score.ToString()}";
    }

    private void AdjustDifficulty()
    {
        // Game difficulty curved
        // For every 20 score
        if ((overallScore % 20) == 0 && maxPatientLevelDrop != 5)
        {
            GameConfiguration.maxPatientLevel -= 5;
            maxPatientLevelDrop++;
        }

        if ((overallScore % 40) == 0 && minPatientLevelDrop != 5)
        {
            GameConfiguration.minPatientLevel -= 5;
            minPatientLevelDrop++;
        }
    }

    public void UpdateBGMAudio()
    {
        audioManager.PlayBgmGamePlay();
    }

    public void SpawnCharacter()
    {
        characterGenerator.Create();
    }

    public void AddScore()
    {
        overallScore = overallScore + (1 * GameConfiguration.scoreMultiplier);
        score = score + (1 * GameConfiguration.scoreMultiplier);
        UpdateScoreUI();
        AdjustDifficulty();
    }

    public bool RemoveScore(int value)
    {
        if (score < value)
            return false;

        score = score - value;

        UpdateScoreUI();
        return true;
    }

    public void SetInfo(GameObject character)
    {
        this.character = character;
        characterLogic = character.GetComponent<CharacterLogic>();
        characterInfo = characterLogic.characterInfo;

        // Male = 0, Female = 1
        if (characterInfo.gender == 0)
        {
            cardController.SetGender(0);
            cardController.SetFullName(characterInfo.GetFullName());
            cardController.SetCardID(characterInfo.GetCardID());
            cardController.SetExpiredDate(characterInfo.GetCardExpiredDateTime().ToString("dd/MM/yyyy"));
        } 
        else
        if (characterInfo.gender == 1)
        {
            cardController.SetGender(1);
            cardController.SetFullName(characterInfo.GetFullName());
            cardController.SetCardID(characterInfo.GetCardID());
            cardController.SetExpiredDate(characterInfo.GetCardExpiredDateTime().ToString("dd/MM/yyyy"));
        }
        
        // Randomize if the character data should inject to database
        if (infoRandomizer.ShouldInjectToDatabase())
        {
            nameComputer.data_realID = characterInfo.GetCardID();
            nameComputer.data_realName = characterInfo.GetFullName();
            Debug.Log("INJECTED TO DATABASE");
        }      
    }

    public void GiveCard()
    {
        cardController.PutUserCardInDesk();
    }

    public void CheckInfo(bool userDecision)
    {
        // False if failed to meet the requirements
        bool status = ApprovalSystem.checkFor(characterInfo, clockSystem.GetCurrentDateTime(), nameComputer.data_realName);

        switch (userDecision)
        {
            case true:
                characterLogic.AllowedToEntry(true);
                nameComputer.ResetRealData();
                if (!status)
                {
                    Debug.Log("WRONG DECISION");
                    CheckPenalty();
                    penaltyCount++;
                    return;
                }
                break;

            case false:
                characterLogic.AllowedToEntry(false);
                nameComputer.ResetRealData();
                if (status)
                {
                    Debug.Log("WRONG DECISION");
                    CheckPenalty();
                    penaltyCount++;
                    return;
                }
                break;
        }

        // Add score
        Debug.Log("CORRECT DECISION");
        AddScore();
    }

    public void PauseGame()
    {
        if (!tryToPauseOnce)
        {
            tryToPauseOnce = true;
            pauseText.SetText(PAUSE_WARNING);
            
            return;
        }

        CheckPenalty();
        penaltyCount++;
    }

    private void CheckPenalty()
    {
        switch (penaltyCount)
        {
            case 0:
                notificationStrikeOne.SetText(ONE_STRIKE);
                break;

            case 1:
                notificationStrikeTwo.SetText(TWO_STRIKE);
                break;

            case 2:
                notificationStrikeThree.SetText(THREE_STRIKE);
                break;

            case 3:
                // Game over
                GameOver();
                break;

        }
    }

    private void GameOver()
    {
        gameManager.EndGame(score);
    }
}