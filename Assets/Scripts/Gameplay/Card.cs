using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string firstName { get; set; }

    public string middleName { get; set; }

    public string lastName { get; set; }
    
    public int gender { get; set; }

    public string cardID { get; set; }

    public DateTime dateCreated { get; set; }

    public DateTime dateExpired { get; set; }

    public Card(string firstName, string middleName, string lastName, int gender, string cardID, DateTime dateCreated, DateTime dateExpired)
    {
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
        this.gender = gender;
        this.cardID = cardID;
        this.dateCreated = dateCreated;
        this.dateExpired = dateExpired;
    }
}
