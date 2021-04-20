using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private Animator entrySlidingDoorAnim;

    [SerializeField]
    private Animator exitSlidingDoorAnim;

    public void EntryDoor()
    {
        entrySlidingDoorAnim.SetTrigger("TriggerDoor");
    }

    public void SecurityDoor()
    {
        exitSlidingDoorAnim.SetTrigger("TriggerDoor");
    }
}
