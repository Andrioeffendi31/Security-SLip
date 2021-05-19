using System;
using System.Collections;
using System.Collections.Generic;

public class ApprovalSystem
{
    public bool checkFor(Character character, DateTime current, string database)
    {
        if (isExpired(current, character.GetCardExpiredDateTime()))
            return false;

        if (inDatabase(character.GetFullName(), database))
            return false;

        return true;
    }

    public bool inDatabase(string characterName, string databaseName)
    {
        if (!characterName.Equals(databaseName))
            return false;

        return true;
    }

    public bool isExpired(DateTime current, DateTime check) 
    {
        if (check.Date >= current.Date.Date) { return false; }
        return true;
    }
}
