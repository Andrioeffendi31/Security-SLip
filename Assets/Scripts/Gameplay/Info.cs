using System;
using System.Collections;
using System.Collections.Generic;

// Temporary only
// One type of entry info
// Entry Card with expired date listed
public class Info
{
    public DateTime expired { get; set; }
    public Character character { get; set; }

    private readonly InfoRandomizer infoRandomizer = new InfoRandomizer();

    public Info()
    {
        // Generate character
        character = infoRandomizer.GetRandomizeCharacter();

        // Hardcoded from and to date
        DateTime from = DateTime.Today.AddDays(-3);
        DateTime to = DateTime.Today.AddDays(3);

        // Get randomize date
        this.expired = infoRandomizer.GetRandomDate(from, to);
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
        if (character.middleName != null)
        {
            fullName = character.firstName + " " + character.middleName[0] + ". " + character.lastName;
            return fullName;
        }

        fullName = character.firstName + " " + character.lastName;
        return fullName;
    }
}
