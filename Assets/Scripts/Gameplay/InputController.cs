using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private RaycastController raycast;
    [SerializeField] private GameObject computerUI;
    [SerializeField] private GameObject maleCard;
    [SerializeField] private GameObject femaleCard;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            string name = raycast.GetObjectOnRaycastName();

            if (name != null)
                switch (name)
                {
                    case "Approve":
                        if (gameManager.allowToChoose)
                        {
                            gameManager.allowToChoose = false;
                            gameManager.CheckInfo(true);
                        }
                        break;

                    case "Reject":
                        if (gameManager.allowToChoose)
                        {
                            gameManager.allowToChoose = false;
                            gameManager.CheckInfo(false);
                        }
                        break;

                    case "Computer":
                        Cursor.visible = true;
                        cameraController.allowMovement = false;
                        computerUI.SetActive(true);
                        break;

                    case "Entry Card":
                        if (gameManager.allowToChoose)
                        {
                            Cursor.visible = true;
                            cameraController.allowMovement = false;
                            if (gameManager.character.gender == 0)
                                maleCard.SetActive(true);
                            if (gameManager.character.gender == 1)
                                femaleCard.SetActive(true);
                        }
                        break;
                }
        }
    }

    public void CloseComputerUI()
    {
        Cursor.visible = false;
        cameraController.allowMovement = true;
        computerUI.SetActive(false);
    }

    public void CloseCardUI()
    {
        Cursor.visible = false;
        cameraController.allowMovement = true;
        maleCard.SetActive(false);
        femaleCard.SetActive(false);
    }
}
