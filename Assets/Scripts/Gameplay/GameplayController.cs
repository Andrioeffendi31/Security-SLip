using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    private readonly InfoRandomizer infoRandomizer = new InfoRandomizer();

    [SerializeField]
    private CardController cardController;

    [SerializeField]
    private ApprovalSystem ApprovalSystem = new ApprovalSystem();

    [SerializeField]
    private Image scoreProgressBar;

    [SerializeField]
    private ClockSystem clockSystem;

    [SerializeField]
    private CharacterGenerator characterGenerator;

    private GameObject character;

    private CharacterLogic characterLogic;

    private Character characterInfo;

    private GameManager gameManager;

    public bool allowToChoose { get; set; }

    private int score;

    private void Start()
    {
        Init();
    }
    
    private void Update()
    {
        // Game Over
        if (clockSystem.GetCurrentDateTime().Hour >= 8)
            gameManager.GoToMainMenu();
    }

    private void Init()
    {
        // Attach to Game Manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.StartGame(this);

        score = 0;
        scoreProgressBar.fillAmount = 0;
        allowToChoose = false;
        
        // Set Game Time and start the clock
        clockSystem.SetStartDateTime(2021, 3, 23, 7, 0, 0);
        clockSystem.StartClock();

        // Spawn the first character
        SpawnCharacter();

        // Debug start game time
        if (GameConfiguration.DebugMode)
            Debug.Log("Start DateTime: " + clockSystem.GetCurrentDateTime());
    }

    private void UpdateProgressBar()
    {
        scoreProgressBar.fillAmount = (float) score / 10;
    }

    public void SpawnCharacter()
    {
        characterGenerator.Create();
    }

    public void AddScore()
    {
        score++;
        UpdateProgressBar();
    }

    public void RemoveScore()
    {
        score--;
        UpdateProgressBar();
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
            cardController.SetExpiredDate(characterInfo.info.expired.ToString("dd/MM/yyyy"));
        } else
        if (characterInfo.gender == 1)
        {
            cardController.SetGender(1);
            cardController.SetFullName(characterInfo.GetFullName());
            cardController.SetExpiredDate(characterInfo.info.expired.ToString("dd/MM/yyyy"));
        }
    }

    public void GiveCard()
    {
        cardController.PutUserCardInDesk();
    }

    public void CheckInfo(bool userDecision)
    {
        bool status = ApprovalSystem.isExpired(clockSystem.GetCurrentDateTime(), characterInfo.GetInfoExpiredDateTime());

        switch (userDecision)
        {
            case true:
                characterLogic.AllowedToEntry(true);
                cardController.RemoveUserCardFromDesk();
                if (status)
                {
                    Debug.Log("WRONG DECISION");
                    return;
                }
                break;

            case false:
                characterLogic.AllowedToEntry(false);
                cardController.RemoveUserCardFromDesk();
                if (!status)
                {
                    Debug.Log("WRONG DECISION");
                    return;
                }
                break;
        }

        // Add score
        Debug.Log("CORRECT DECISION");
        AddScore();
    }
}
