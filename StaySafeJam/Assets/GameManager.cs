using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class GameManager
{
    public static int Level;
    public static int CostMultiplier { get { return (int)(Level) / (int)3 + 1; } }

    // UPGRADEABLES
    public static int ConverterPollenCapacity = 12 * 6;
    public static int DefaultScanRadius = 3;

    public static BeehiveInit beehiveInit = new BeehiveInit();
    public static CallConvertation pollenToHoney = new CallConvertation();
    static uint _money;

    static public int Money
    {
        get
        {
            return (int)_money;
        }
        set
        {
            _money = (uint)Mathf.Abs(value);
        }
    }
}

public class BeehiveInit : UnityEvent<Beehive> { }
public class CallConvertation : UnityEvent<BeehiveCollector, int> { }