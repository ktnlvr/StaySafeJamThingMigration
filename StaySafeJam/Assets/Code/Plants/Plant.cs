using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour, IEntity
{
    public int amount = 1;
    public void Start()
    {
        GameManager.beehiveInit.AddListener(BeehiveInitialized);
    }
    public void BeehiveInitialized(Beehive hive) { if (Vector3.Distance(transform.position, hive.transform.position) < 10) { hive.plants.Add(this); print("AAAA"); } }
}
