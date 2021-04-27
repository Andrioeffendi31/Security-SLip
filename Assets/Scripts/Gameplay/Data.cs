using System.Collections;
using System.Collections.Generic;

public class Data
{
    private readonly InfoRandomizer infoRandomizer = new InfoRandomizer();

    public int key;

    public string cardID;

    public string firstName;

    public string middleName;

    public string lastName;

    public Data()
    {
        cardID = $"{infoRandomizer.GetRandomizeCardID(GameConfiguration.minCardID, GameConfiguration.maxCardID)}{key}";
        firstName = infoRandomizer.GetRandomizeFirstName(infoRandomizer.GetRandomizeGender());
        middleName = infoRandomizer.GetRandomizeMiddleName(infoRandomizer.GetRandomizeGender());
        lastName = infoRandomizer.GetRandomizeLastName(infoRandomizer.GetRandomizeGender());
    }
}