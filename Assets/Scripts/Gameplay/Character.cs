using System;
using System.Collections;
using System.Collections.Generic;

public class Character
{
    public string firstName { get; set; }

    public string middleName { get; set; }

    public string lastName { get; set; }
    
    public int gender { get; set; }
    
    public Info info { get; set; }

    public Character(string firstName, string middleName, string lastName, int gender, Info info)
    {
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
        this.gender = gender;
        this.info = info;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Character's full name</returns>
    public string GetFullName()
    {
        string fullName;
        fullName = $"{firstName} {middleName} {lastName}";
        return fullName;
    }
    
    public string GetCardID()
    {
        return info.card.cardID;
    }

    public DateTime GetCardExpiredDateTime()
    {
        return info.card.dateExpired;
    }
}
