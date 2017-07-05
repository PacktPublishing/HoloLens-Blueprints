using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Building
{
    public string BuildingName;
    public string Id;
    public string Address;
    public List<Wing> Wings;
}
