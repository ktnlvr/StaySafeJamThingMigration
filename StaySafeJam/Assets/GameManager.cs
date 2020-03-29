using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class GameManager
{
    public static Queen[] queens;
    public static int Level;
    public static int CostMultiplier { get { return (int)(Level) / (int)8 + 1; } }

    // UPGRADEABLES
    public static int ConverterPollenCapacity = 12 * 6;
    public static int DefaultScanRadius = 3;

    public static BeehiveInit beehiveInit = new BeehiveInit();
    public static UnityEvent honeyUpd = new UnityEvent();
    static uint _honey = 8;

    static public int honey
    {
        get
        {
            return (int)_honey;
        }
        set
        {
            honeyUpd.Invoke();
            _honey = (uint)Mathf.Abs(value);
        }
    }
}

public class BeehiveInit : UnityEvent<Beehive> { }