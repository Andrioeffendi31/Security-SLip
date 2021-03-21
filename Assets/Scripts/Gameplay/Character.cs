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
}
