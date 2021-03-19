using System;
using System.Collections;
using System.Collections.Generic;

public class InfoRandomizer
{
    // Random Generator
    private readonly Random _generator = new Random();

    // Temporary, will change to read from file
    string[] listOfFirstName = {
        "Nikki", "Bill", "Patrick", "Daniel", "Alex"
    };
    string[] listOfMiddleName = {
        "Hines", "Huff", "Matt", "Ence"
    };
    string[] listOfLastName = {
        "Benson", "Sears", "Coffey", "Everett", "Grant"
    };

    public InfoRandomizer() {}

    public Character getRandomizeCharacter()
    {
        Character generated = new Character();

        // Generate character full name
        generated.firstName = listOfFirstName[RandomNumber(0, listOfFirstName.Length)];
        generated.middleName = listOfMiddleName[RandomNumber(0, listOfMiddleName.Length)];
        generated.lastName = listOfLastName[RandomNumber(0, listOfLastName.Length)];

        string dob = "" + RandomNumber(1, 28) + "/" + RandomNumber(1, 12) + "/" + RandomNumber(1986, 2003);
        generated.dob = DateTime.ParseExact(dob, "dd/MM/yyyy", null);

        return generated;
    }

    public int RandomNumber(int min, int max) { return _generator.Next(min, max); }

}
