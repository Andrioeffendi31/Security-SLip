using System.Collections;
using System.Collections.Generic;

public class Data
{
    private InfoRandomizer infoRandomizer;

    public int key;

    public string cardID;

    public string firstName;

    public string middleName;

    public string lastName;

    public Data(int key, InfoRandomizer.DB_Male dbMale, InfoRandomizer.DB_Female dbFemale)
    {
        GameConfiguration.Initialize();
        infoRandomizer = new InfoRandomizer(dbMale, dbFemale);

        cardID = $"{infoRandomizer.GetRandomizeCardID(GameConfiguration.minCardID, GameConfiguration.maxCardID)}{key}";
        firstName = infoRandomizer.GetRandomizeFirstName(infoRandomizer.GetRandomizeGender());
        middleName = infoRandomizer.GetRandomizeMiddleName(infoRandomizer.GetRandomizeGender());
        lastName = infoRandomizer.GetRandomizeLastName(infoRandomizer.GetRandomizeGender());
    }
}