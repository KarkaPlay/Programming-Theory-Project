using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsObserver : MonoBehaviour
{
    public static ShipsObserver Instance;

    public List<Starship> starships;

    private void Awake()
    {
        Instance = this;
        starships.AddRange(GetComponentsInChildren<Starship>());
    }
}
