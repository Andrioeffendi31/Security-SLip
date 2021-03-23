using System;
using System.Collections;
using System.Collections.Generic;

public class ApprovalSystem
{
    public bool isExpired(DateTime current, DateTime check) 
    {
        if (check.Date >= current.Date.Date) { return false; }
        return true;
    }
}
