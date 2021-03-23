using System;
using System.Collections;
using System.Collections.Generic;

// Temporary only
// One type of entry info
// Entry Card with expired date listed
public class Info
{
    public DateTime expired { get; set; }

    private readonly InfoRandomizer infoRandomizer = new InfoRandomizer();

    public Info()
    {
        // Hardcoded from and to date
        DateTime from = DateTime.Today.AddDays(-3);
        DateTime to = DateTime.Today.AddDays(3);

        // Get randomize date
        this.expired = infoRandomizer.GetRandomDate(from, to);
    }
}
