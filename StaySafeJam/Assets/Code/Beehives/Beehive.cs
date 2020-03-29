using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beehive : MonoBehaviour, IEntity
{
    // STATS
    public float ScanRadius = 3;
    public float WorkTime;
    public int PollenCapacity;
    public int HoneyCapacity;
    public int PollenAmount;

    [HideInInspector]
    public float timer;
    [HideInInspector]
    public bool working;
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
    void Start()
    {
        Init();
        Randomize();
    }

    public void Randomize()
    {
        ScanRadius = Random.Range(0.8f, 2);
        WorkTime = Random.Range(8f, 15f);
        PollenCapacity = Random.Range(10, 64);
        HoneyCapacity = Random.Range(3, 15);
    }

    protected void Init()
    {
        if(transform.position.y <= 3)
        {
            GameManager.honey += 4;
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
    public void CollectHoney() { GameManager.honey += PollenAmount / GameManager.CostMultiplier; PollenAmount = 0; GameManager.Level++; GameManager.honeyUpd.Invoke(); }

    public void Update()
    {
        if (working)
            timer -= Time.deltaTime;
        if(timer <= 0)
        {
            working = false;
            PollenAmount = plants.Count;
            if(flowMode)
            {
                CollectHoney();
                working = true;
            }
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

    //private IEnumerator AudioInEase()
    //{
    //    float duration = 3f;
    //    while(duration > 0)
    //    {
    //        duration -= Time.deltaTime;
    //        buzzSource.volume = (1 - (duration / 3f)) * 0.5f;
    //        yield return null;
    //    }
    //}
    //private IEnumerator AudioOutEase()
    //{
    //    float duration = 1f;
    //    while (duration > 0)
    //    {
    //        duration -= Time.deltaTime;
    //        buzzSource.volume = (duration / 1f) * 0.5f;
    //        yield return null;
    //    }
    //}
}
