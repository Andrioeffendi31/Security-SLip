using System;
using System.Collections;
using System.Collections.Generic;

public class Character
{
    private readonly InfoRandomizer infoRandomizer = new InfoRandomizer();

    // Character info
    public string firstName { get; set; }
    public string middleName { get; set; }
    public string lastName { get; set; }
    public int gender { get; set; }

    public Info info;

    public Character(int gender)
    {
        this.firstName = infoRandomizer.GetRandomizeFirstName();
        this.middleName = infoRandomizer.GetRandomizeMiddleName();
        this.lastName = infoRandomizer.GetRandomizeLastName();
        this.gender = gender;

        info = new Info();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Character's full name</returns>
    public string GetFullName()
    {
        string fullName;

        // If middlename exists
        // Show only the 1st middle name character
        if (middleName != null)
        {
            fullName = firstName + " " + middleName[0] + ". \n" + lastName;
            return fullName;
        }

        fullName = firstName + " " + lastName;
        return fullName;
    }

    public DateTime GetInfoExpiredDateTime()
    {
        return info.expired;
    }
}
