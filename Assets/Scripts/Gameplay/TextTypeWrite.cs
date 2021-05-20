using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTypeWrite : MonoBehaviour
{
    private readonly int NOTIFICATION_TIME = 2;

    [SerializeField]
	Text textToPrint;

    [SerializeField]
    private Animator notificationAnimController;

	string text;
    
    public void SetText(string text)
    {
        gameObject.SetActive(true);
        this.text = text;
        notificationAnimController.SetTrigger("NotificationTrigger");
    }

    public void ShowText()
    {
		textToPrint.text = "";

        StopAllCoroutines();
		StartCoroutine("PrintText");
    }

    public void HideText()
    {
        text = textToPrint.text;

        StopAllCoroutines();
		StartCoroutine("DeleteText");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

	IEnumerator PrintText()
	{
		foreach (char c in text) 
		{
			textToPrint.text += c;
			yield return new WaitForSeconds(0.025f);
		}

        yield return new WaitForSeconds(NOTIFICATION_TIME);
        notificationAnimController.SetTrigger("NotificationTrigger");
	}

    IEnumerator DeleteText()
	{
        string fullText = textToPrint.text;
        int i = fullText.Length;

		foreach (char c in text) 
		{
            i--;
            fullText = fullText.Remove(i);
			textToPrint.text = fullText;
			yield return new WaitForSeconds(0.0025f);
		}
	}
}
