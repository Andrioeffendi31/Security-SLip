using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class InfoRandomizer
{
    [Serializable]
    public class DB_Male
    {
        public string[] firstName;
        public string[] middleName;
        public string[] lastName;
    }

    [Serializable]
    public class DB_Female
    {
        public string[] firstName;
        public string[] middleName;
        public string[] lastName;
    }

    public DB_Male dbMale;
    public DB_Female dbFemale;

    public InfoRandomizer() { }

    public InfoRandomizer(DB_Male dbMale, DB_Female dbFemale)
    {
        this.dbMale = dbMale;
        this.dbFemale = dbFemale;
    }

    public string GetRandomizeFirstName(int genderType)
    {
        switch(genderType)
        {
            // Male
            case 0:
                return dbMale.firstName[RandomNumber(0, dbMale.firstName.Length)];

            // Female
            case 1:
                return dbFemale.firstName[RandomNumber(0, dbFemale.firstName.Length)];
        }

        return null;
    }

    public string GetRandomizeMiddleName(int genderType)
    {
        switch(genderType)
        {
            // Male
            case 0:
                return dbMale.middleName[RandomNumber(0, dbMale.middleName.Length)];

            // Female
            case 1:
                return dbFemale.middleName[RandomNumber(0, dbFemale.middleName.Length)];
        }

        return null;
    }

    public string GetRandomizeLastName(int genderType)
    {
        switch(genderType)
        {
            // Male
            case 0:
                return dbMale.lastName[RandomNumber(0, dbMale.lastName.Length)];

            // Female
            case 1:
                return dbFemale.lastName[RandomNumber(0, dbFemale.lastName.Length)];
        }

        return null;
    }
    
    public int GetRandomizeGender()
    {
        return RandomNumber(0, 2);
    }

    public string GetRandomizeCardID(int min, int max)
    {
        return $"{GameConfiguration.startCardID}{RandomNumber(min, max)}";
    }

    public int RandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }

    public DateTime GetRandomDate(DateTime dateTimeFrom, DateTime dateTimeTo)
    {
        int range = (dateTimeTo - dateTimeFrom).Days;
        return dateTimeFrom.AddDays(Random.Range(0, range));
    }
}