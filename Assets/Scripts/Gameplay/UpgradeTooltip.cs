using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTooltip : MonoBehaviour
{
    private Vector3 offset = new Vector3(185, 30, 0);

    [SerializeField]
    private Text text;

    private bool isShowing;

    private void Start()
    {
        isShowing = false;
    }

    private void LateUpdate()
    {
        transform.position = (Input.mousePosition + offset);
    }

    public void ShowTooltip(int price)
    {
        isShowing = true;
        gameObject.SetActive(true);
        text.text = $"Cost: {price} Score";
    }

    public void ShowTooltip()
    {
        isShowing = true;
        gameObject.SetActive(true);
        text.text = $"Max Level!";
    }

    public void HideTooltip()
    {
        isShowing = false;
        gameObject.SetActive(false);
    }
}
