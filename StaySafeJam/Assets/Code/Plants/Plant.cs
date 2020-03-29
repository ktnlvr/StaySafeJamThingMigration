using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour, IEntity
{
    public void Start() => GameManager.beehiveInit.AddListener(BeehiveInitialized);
    public void BeehiveInitialized(Beehive hive) { if (Vector3.Distance(transform.position, hive.transform.position) < GameManager.DefaultScanRadius + hive.ScanRadius) { hive.plants.Add(this); print("AAAA"); } }
}
