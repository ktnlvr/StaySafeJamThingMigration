using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beehive : MonoBehaviour, IEntity
{
    public void Awake() => Init();
    public void OnEnable() => GameManager.beehiveInit.AddListener(BeehiveInitialized);
    public void OnDisable() => GameManager.beehiveInit.AddListener(BeehiveInitialized);

    public List<IEntity> Entities;
    public List<Plant> plants;
    public List<BeehiveConverter> converters = new List<BeehiveConverter> { };
    public List<BeehiveCollector> collectors = new List<BeehiveCollector> { };
    void Init()
    {
        GameManager.beehiveInit.Invoke(this);
    }

    public void DestroyHive()
    {
        Destroy(this.gameObject);
    }

    public void BeehiveInitialized(Beehive hive) { }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 9f);
    }
}
