using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beehive : MonoBehaviour, IEntity
{
    // STATS
    public int ScanRadius;
    public int WorkTime;
    public int PollenCapacity;
    public int HoneyCapacity;
    public int PollenAmount;

    [HideInInspector]
    public float timer;
    [HideInInspector]
    public bool working;
    [HideInInspector]
    public bool flowMode;

    public void Awake() => Init();
    public void OnEnable() => GameManager.beehiveInit.AddListener(BeehiveInitialized);
    public void OnDisable() => GameManager.beehiveInit.AddListener(BeehiveInitialized);

    public List<Plant> plants;
    [SerializeField]
    private ParticleSystem hiveActiveP;
    [SerializeField]
    private ParticleSystem beesWorkingP;
    [SerializeField]
    private ParticleSystem honeyFlowingP;
    void Start() => Init();

    protected void Init()
    {
        plants = new List<Plant>();
        if(transform.position.y <= 3)
        {
            Destroy(gameObject);
        }
        GameManager.beehiveInit.Invoke(this);
    }

    public void DestroyHive()
    {
        Destroy(gameObject);
    }

    public void OnMouseOver()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Init();
            if (!working)
            {
                working = true;
                honeyFlowingP.Stop();
                timer = WorkTime;
                CollectHoney();
                beesWorkingP.Play();
            }
        }
    }

    // PARTIAl
    public void CollectHoney() { GameManager.honey += PollenAmount / GameManager.CostMultiplier; PollenAmount = 0; }

    public void Update()
    {
        if (working)
            timer -= Time.deltaTime;
        if(timer <= 0)
        {
            working = false;
            beesWorkingP.Stop();
            PollenAmount = plants.Count;
        }
        if (PollenAmount > 0)
            if (!honeyFlowingP.isPlaying)
                honeyFlowingP.Play();
    }

    public void BeehiveInitialized(Beehive hive) { }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 9f);
    }
}
