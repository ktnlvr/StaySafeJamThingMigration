using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Queen
{
    public string QueenName;
    public int WorkTime;
    public int PollenCapacity;
    public int ScanRadius;

    static List<string> Names = new List<string> { };


    static string QueenBeeName()
    {
        return "o";
    }

    public Queen(int WorkTime, int PollenCapacity, int ScanRadius)
    {
        this.QueenName = QueenBeeName();
        this.WorkTime = WorkTime;
        this.PollenCapacity = PollenCapacity;
        this.ScanRadius = ScanRadius;
    }

    public Queen(Queen a, Queen b)
    {
        this.QueenName = QueenBeeName();
        this.WorkTime = (a.WorkTime + b.WorkTime) * (int)Random.Range(0.6f, 1.6f);
        this.PollenCapacity = (a.PollenCapacity + b.PollenCapacity) * ((int)Random.Range(0.6f, 1.6f));
        this.ScanRadius = (a.ScanRadius + b.ScanRadius) * ((int)Random.Range(0.6f, 1.6f));
    }
}

