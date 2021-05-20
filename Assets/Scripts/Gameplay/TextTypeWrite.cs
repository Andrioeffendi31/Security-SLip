using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTypeWrite : MonoBehaviour
{
    [SerializeField]
	Text textToPrint;

	string text;
    
    public void SetText(string text)
    {
        this.text = text;
    }

    public void ShowText()
    {
		textToPrint.text = "";

		StartCoroutine("PrintText");
    }

    public void HideText()
    {
        text = textToPrint.text;

		StartCoroutine("DeleteText");
    }

	IEnumerator PrintText()
	{
		foreach (char c in text) 
		{
			textToPrint.text += c;
			yield return new WaitForSeconds (0.05f);
		}
	}

    IEnumerator DeleteText()
	{
        int i = text.Length;

		foreach (char c in text) 
		{
            string fullText = textToPrint.text;
            fullText.Remove(i);
			textToPrint.text = fullText;
            i--;
			yield return new WaitForSeconds (0.05f);
		}
	}
}
