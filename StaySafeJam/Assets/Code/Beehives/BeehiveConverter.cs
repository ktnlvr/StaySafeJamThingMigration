using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeehiveConverter : Beehive
{
    public int Honey = 0;

    public void Start() => GameManager.pollenToHoney.AddListener(PollenToHoney);

    private void PollenToHoney(BeehiveCollector converter, int amount)
    {
        amount = Mathf.Clamp(amount, 0, PollenCapacity + GameManager.ConverterPollenCapacity);
        Honey = Mathf.Clamp((int)amount / (int)GameManager.CostMultiplier, 0, HoneyCapacity);
    }
}
