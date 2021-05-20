using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private GameplayController gameplayController;

    [SerializeField]
    private CameraController cameraController;

    [SerializeField]
    private RaycastController raycast;

    [SerializeField]
    private GameObject computerUI;

    [SerializeField]
    private GameObject databaseUI;

    [SerializeField]
    private GameObject upgradeUI;

    [SerializeField]
    private CardController cardController;

    void Update()
    {
        CheckForInput();
    }

    private void CheckForInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            string name = raycast.GetObjectOnRaycastName();

            switch (name)
            {
                case "Approve":
                    Approve();
                    break;

                case "Reject":
                    Reject();
                    break;

                case "Computer":
                    OpenComputerGUI();
                    break;

                case "Entry Card":
                    OpenCardUI();
                    break;
            }
        }
    }

    private void Approve()
    {
        if (gameplayController.allowToChoose)
        {
            gameplayController.allowToChoose = false;
            gameplayController.CheckInfo(true);
        }
    }

    private void Reject()
    {
        if (gameplayController.allowToChoose)
        {
            gameplayController.allowToChoose = false;
            gameplayController.CheckInfo(false);
        }
    }

    private void OpenComputerGUI()
    {
        cameraController.DisableCameraMovement();
        computerUI.SetActive(true);
    }

    public void CloseComputerUI()
    {
        cameraController.EnableCameraMovement();
        computerUI.SetActive(false);
    }

    public void OpenDatabaseUI()
    {
        databaseUI.SetActive(true);
    }

    public void CloseDatabaseUI()
    {
        databaseUI.SetActive(false);
    }

    public void OpenUpgradeUI()
    {
        upgradeUI.SetActive(true);
    }

    public void CloseUpgradeUI()
    {
        upgradeUI.SetActive(false);
    }

    private void OpenCardUI()
    {
        if (gameplayController.allowToChoose)
        {
            cameraController.DisableCameraMovement();
            cardController.Show();
        }
    }

    public void CloseCardUI()
    {
        cameraController.EnableCameraMovement();
        cardController.Hide();
    }
}
