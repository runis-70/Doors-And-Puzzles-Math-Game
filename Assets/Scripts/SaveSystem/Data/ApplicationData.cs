using System;
using System.Collections.Generic;

[Serializable]
public class ApplicationData
{
    public List<ReservationElementUIData> reservationElementUIData;

    public ApplicationData()
    {
        reservationElementUIData = new List<ReservationElementUIData>();
    }
}
