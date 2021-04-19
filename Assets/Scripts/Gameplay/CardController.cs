using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    private readonly Color TEXT_MALE_COLOR = new Color32(56, 66, 118, 255);
    private readonly Color TEXT_FEMALE_COLOR = new Color32(215, 68, 89, 255);

    [SerializeField]
    private GameObject entryCard;

    [SerializeField]
    private GameObject maleBG;

    [SerializeField]
    private GameObject femaleBG;

    [SerializeField]
    private Text fullName;

    [SerializeField]
    private Text labelGender;

    [SerializeField]
    private Text gender;

    [SerializeField]
    private Text expiredDate;

    public void PutUserCardInDesk()
    {
        entryCard.SetActive(true);
    }

    public void RemoveUserCardFromDesk()
    {
        entryCard.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetGender(int gender)
    {
        femaleBG.SetActive(false);
        maleBG.SetActive(false);
        
        switch(gender)
        {
            case 0:
                this.gender.text = "Male";
                this.gender.color = TEXT_MALE_COLOR;
                this.labelGender.color = TEXT_MALE_COLOR;
                this.fullName.color = TEXT_MALE_COLOR;
                this.expiredDate.color = TEXT_MALE_COLOR;
                
                maleBG.SetActive(true);
                break;

            case 1:
                this.gender.text = "Female";
                this.gender.color = TEXT_FEMALE_COLOR;
                this.labelGender.color = TEXT_FEMALE_COLOR;
                this.fullName.color = TEXT_FEMALE_COLOR;
                this.expiredDate.color = TEXT_FEMALE_COLOR;

                femaleBG.SetActive(true);
                break;
        }
    }

    public void SetFullName(string fullName)
    {
        this.fullName.text = fullName;
    }

    public void SetExpiredDate(string expiredDate)
    {
        this.expiredDate.text = expiredDate;
    }
}
