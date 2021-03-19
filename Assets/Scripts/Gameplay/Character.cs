using System;
using System.Collections;
using System.Collections.Generic;

public class Character
{
    // Character info
    public string firstName { get; set; }
    public string middleName { get; set; }
    public string lastName { get; set; }

    public DateTime dob;

    public Character() { }

    public Character(string firstName, string middleName, string lastName, DateTime dob)
    {
        firstName = this.firstName;
        middleName = this.middleName;
        lastName = this.lastName;

        dob = this.dob;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Character's full name</returns>
    public string getName()
    {
        string fullName;

        // If middlename exists
        // Show only the 1st middle name character
        if (middleName != null)
        {
            fullName = firstName + " " + middleName[0] + ". " + lastName;
            return fullName;
        }

        fullName = firstName + " " + lastName;
        return fullName;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Character's date of birth</returns>
    public DateTime getDOB() { return dob; }
}
