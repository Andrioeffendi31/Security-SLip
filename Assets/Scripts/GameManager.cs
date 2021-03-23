using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ClockSystem clockSystem;
    private ApprovalSystem ApprovalSystem = new ApprovalSystem();

    public CharacterGenerator characterGenerator;
    public CharacterLogic characterLogic;
    public Character character;
    public bool isPlaying;
    public bool allowToChoose;

    public int score = 0;
    public Image scoreProgressBar;

    public GameObject entryCard;
    public Text maleCard_fullName;
    public Text maleCard_expiredDate;
    public Text femaleCard_fullName;
    public Text femaleCard_expiredDate;

    private void Awake()
    {
        // DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        clockSystem.SetStartDateTime(2021, 3, 23, 7, 0, 0);
        Debug.Log("Current DateTime : " + clockSystem.GetCurrentDateTime());
        allowToChoose = false;
        scoreProgressBar.fillAmount = 0;
    }

    private void Update()
    {
        if (clockSystem.GetCurrentDateTime().Hour >= 8)
            // Game Over
            SceneManager.LoadScene("MainMenu");
    }

    public void ApplyInfo()
    {
        entryCard.SetActive(true);
        // Male = 0, Female = 1
        if (character.gender == 0)
        {
            maleCard_fullName.text = character.GetFullName();
            maleCard_expiredDate.text = character.info.expired.ToString("dd/MM/yyyy");
        } else
        if (character.gender == 1)
        {
            femaleCard_fullName.text = character.GetFullName();
            femaleCard_expiredDate.text = character.info.expired.ToString("dd/MM/yyyy");
        }
    }

    public void CheckInfo(bool userDecision)
    {
        bool status = ApprovalSystem.isExpired(clockSystem.GetCurrentDateTime(), character.GetInfoExpiredDateTime());

        switch (userDecision)
        {
            case true:
                characterLogic.AllowedToEntry(true);
                entryCard.SetActive(false);
                if (status)
                {
                    Debug.Log("WRONG DECISION");
                    return;
                }
                break;

            case false:
                characterLogic.AllowedToEntry(false);
                entryCard.SetActive(false);
                if (!status)
                {
                    Debug.Log("WRONG DECISION");
                    return;
                }
                break;
        }

        // Add score
        Debug.Log("CORRECT DECISION");
        score++;
        scoreProgressBar.fillAmount = (float) score / 10;
    }
}
