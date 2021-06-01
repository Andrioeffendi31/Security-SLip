using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLogic : MonoBehaviour
{
    private readonly int SPEED = 1;

    private readonly Color PATIENT_HIGH_COLOR = new Color32(112, 191, 68, 255);

    private readonly Color PATIENT_LOW_COLOR = new Color32(191, 68, 77, 255);
    
    [SerializeField]
    private Animator characterAnim;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private Image patientLevelBG;

    [SerializeField]
    private Image patientLevelProgress;

    // Character hardcoded path
    private Vector3[] point = {
        new Vector3(2.5f, 0, 3),
        new Vector3(-2, 0, 3),
        new Vector3(-2.25f, 0, -1.5f),
        new Vector3(-7.55f, 0, 3),
        new Vector3(-14, 0, 3)
    };

    private GameplayController gameplayController;

    private CardController cardController;

    private DoorController doorController;

    public Character characterInfo;

    private int patientLevel;

    private int currentPatientLevel;

    private bool allowMovement;

    private int idxPoint;

    private bool path;

    private bool decision;

    private void Start()
    {
        idxPoint = 0;
        path = true;
        decision = false;

        if (GameConfiguration.DebugMode)
        {
            Debug.Log("Card ID   : " + characterInfo.GetCardID());
            Debug.Log("Full Name : " + characterInfo.GetFullName());
            Debug.Log("Info Expired DateTime : " + characterInfo.GetCardExpiredDateTime());
        }
    }

    public void Init(int patientLevel)
    {
        allowMovement = true;
        this.patientLevel = patientLevel;
        this.currentPatientLevel = patientLevel;

        patientLevelBG.color = PATIENT_HIGH_COLOR;
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void LateUpdate()
    {
        canvas.transform.LookAt(mainCamera.transform);
    }

    private void MoveCharacter()
    {
        if (allowMovement)
        {
            Vector3 movePosition;

            Vector3 posTarget = new Vector3(point[idxPoint].x, transform.position.y, point[idxPoint].z);
            movePosition = Vector3.MoveTowards(transform.position, posTarget, SPEED * Time.deltaTime);

            rb.MovePosition(movePosition);

            Vector3 targetRot = posTarget - transform.position;
            transform.rotation = Quaternion.LookRotation(targetRot, Vector3.up);

            Vector3 targetPoint = new Vector3(transform.position.x, point[idxPoint].y, transform.position.z);

            // Animation
            characterAnim.SetBool("isWalking", true);

            if (Vector3.Distance(targetPoint, point[idxPoint]) < 0.1f)
            {
                CheckActionForPoint();
            }
        }
    }

    private void CheckActionForPoint()
    {
        switch (idxPoint)
        {
            // Player start location and end location when rejected
            case 0:
                // Rejected destroy this
                if (!path)
                {
                    doorController.EntryDoor();
                    gameplayController.SpawnCharacter();
                    Destroy(gameObject);
                }
                doorController.EntryDoor();
                break;

            case 1:
                // Close Door
                doorController.EntryDoor();
                break;

            case 2:
                // Stop player movement until next command
                characterAnim.SetBool("isWalking", false);
                if (!decision)
                {
                    gameplayController.allowToChoose = true;
                    gameplayController.GiveCard();
                    StartCoroutine(patientClock());
                }
                if (path) allowMovement = false;
                break;

            case 3:
                // Stop player movement until next command
                doorController.SecurityDoor();
                break;

            case 4:
                // Close the door and destroy this
                doorController.SecurityDoor();
                gameplayController.SpawnCharacter();
                Destroy(gameObject);
                break;
        }
        if (path) idxPoint += 1;
        else idxPoint -= 1;
    }

    private IEnumerator patientClock()
    {
        yield return new WaitForSeconds(1);

        currentPatientLevel--;
        Debug.Log($"Patient Level: { currentPatientLevel }");

        float fillAmount = ((float) currentPatientLevel / patientLevel);

        patientLevelProgress.fillAmount = fillAmount;
        patientLevelBG.color = Color.Lerp(PATIENT_LOW_COLOR, PATIENT_HIGH_COLOR, fillAmount);

        if (currentPatientLevel != 0)
        {
            StartCoroutine(patientClock());
        }

        if (currentPatientLevel == 0)
        {
            AllowedToEntry(false);
            gameplayController.AddPenalty();
        }
    }

    public void ApplyInfo(Character character)
    {
        this.characterInfo = character;
    }

    public void Attach(GameplayController gameplayController, CardController cardController, DoorController doorController, Camera mainCamera)
    {
        this.gameplayController = gameplayController;
        this.cardController = cardController;
        this.doorController = doorController;
        this.mainCamera = mainCamera;
    }
    
    public void AllowedToEntry(bool answer)
    {
        switch (answer)
        {
            case true:
                decision = true;
                allowMovement = true;

                cardController.RemoveUserCardFromDesk();
                StopAllCoroutines();

                break;

            case false:
                path = false;
                idxPoint -= 1;
                decision = true;
                allowMovement = true;

                cardController.RemoveUserCardFromDesk();
                StopAllCoroutines();

                break;
        }
    }
}
