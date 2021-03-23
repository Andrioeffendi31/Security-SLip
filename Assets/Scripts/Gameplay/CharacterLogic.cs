using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLogic : MonoBehaviour
{
    public GameManager gameManager;
    Vector3[] point = {
        new Vector3(2.5f, 0, 3),
        new Vector3(-2, 0, 3),
        new Vector3(-2.25f, 0, -1.5f),
        new Vector3(-7.55f, 0, 3),
        new Vector3(-14, 0, 3)
    };
    private Animator characterAnim;
    private Animator entrySlidingDoorAnim;
    private Animator exitSlidingDoorAnim;
    private Rigidbody rb;
    int idxPoint = 0;

    private bool allowMovement;
    private bool path = true;
    private bool decision = false;

    public enum Gender
    {
        Male,
        Female
    };

    private readonly InfoRandomizer infoRandomizer = new InfoRandomizer();
    Character character;
    public Gender gender;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        characterAnim = GetComponent<Animator>();
        entrySlidingDoorAnim = GameObject.Find("Sliding Door (Entry)").GetComponent<Animator>();
        exitSlidingDoorAnim = GameObject.Find("Sliding Door (Security)").GetComponent<Animator>();

        // Open Door
        allowMovement = true;

        character = infoRandomizer.GetRandomizeCharacter((int)gender);

        gameManager.characterLogic = GetComponent<CharacterLogic>();
        gameManager.character = character;
        Debug.Log("Full Name : " + character.GetFullName());
        Debug.Log("Info Expired DateTime : " + character.info.expired);
    }

    private void Update()
    {
        if (allowMovement)
        {
            Vector3 movePosition;

            Vector3 posTarget = new Vector3(point[idxPoint].x, transform.position.y, point[idxPoint].z);
            movePosition = Vector3.MoveTowards(transform.position, posTarget, 3 * Time.deltaTime);

            rb.MovePosition(movePosition);

            Vector3 posPutaranTarget = posTarget - transform.position;
            transform.rotation = Quaternion.LookRotation(posPutaranTarget, Vector3.up);

            Vector3 posMusuh = new Vector3(transform.position.x, point[idxPoint].y, transform.position.z);

            // Animation
            characterAnim.SetBool("isWalking", true);

            if (Vector3.Distance(posMusuh, point[idxPoint]) < 0.1f)
            {
                switch (idxPoint)
                {
                    case 0:
                        // Rejected destroy this
                        if (!path)
                        {
                            entrySlidingDoorAnim.SetTrigger("TriggerDoor");
                            gameManager.characterGenerator.RandomCharacter();
                            Destroy(gameObject);
                        }
                        entrySlidingDoorAnim.SetTrigger("TriggerDoor");
                        break;

                    case 1:
                        // Close Door
                        entrySlidingDoorAnim.SetTrigger("TriggerDoor");
                        break;

                    case 2:
                        // Stop player movement until next command
                        characterAnim.SetBool("isWalking", false);
                        if (!decision)
                        {
                            gameManager.allowToChoose = true;
                            gameManager.ApplyInfo();
                        }
                        if (path) allowMovement = false;
                        break;

                    case 3:
                        // Stop player movement until next command
                        exitSlidingDoorAnim.SetTrigger("TriggerDoor");
                        break;

                    case 4:
                        // Close the door and destroy this
                        exitSlidingDoorAnim.SetTrigger("TriggerDoor");
                        gameManager.characterGenerator.RandomCharacter();
                        Destroy(gameObject);
                        break;
                }

                if (path) idxPoint += 1;
                else idxPoint -= 1;
            }
        }
    }
    
    public void AllowedToEntry(bool answer)
    {
        switch (answer)
        {
            case true:
                decision = true;
                allowMovement = true;
                break;

            case false:
                path = false;
                idxPoint -= 1;
                decision = true;
                allowMovement = true;
                break;
        }
    }

    IEnumerator delay(int seconds)
    {
        characterAnim.SetBool("isWalking", false);
        allowMovement = false;
        yield return new WaitForSeconds(seconds);
        allowMovement = true;
        characterAnim.SetBool("isWalking", true);
    }
}
