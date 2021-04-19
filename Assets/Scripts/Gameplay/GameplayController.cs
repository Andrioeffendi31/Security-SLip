using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
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

    private GameManager gameManager;

    public Character character;

    public CharacterLogic characterLogic;

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

        // Debug start game time
        if (GameConfiguration.DebugMode)
            Debug.Log("Start DateTime: " + clockSystem.GetCurrentDateTime());
    }

    private void UpdateProgressBar()
    {
        scoreProgressBar.fillAmount = (float) score / 10;
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

    public void ApplyInfo()
    {
        // Male = 0, Female = 1
        if (character.gender == 0)
        {
            cardController.SetGender(0);
            cardController.SetFullName(character.GetFullName());
            cardController.SetExpiredDate(character.info.expired.ToString("dd/MM/yyyy"));
        } else
        if (character.gender == 1)
        {
            cardController.SetGender(1);
            cardController.SetFullName(character.GetFullName());
            cardController.SetExpiredDate(character.info.expired.ToString("dd/MM/yyyy"));
        }

        cardController.PutUserCardInDesk();
    }

    public void CheckInfo(bool userDecision)
    {
        bool status = ApprovalSystem.isExpired(clockSystem.GetCurrentDateTime(), character.GetInfoExpiredDateTime());

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
