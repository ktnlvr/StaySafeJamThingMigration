using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BeehiveCollector : Beehive
{
    float timer = 0;
    float cooldown = 5f;
    [SerializeField]
    ParticleSystem particles;
    int PollenCount = 0;
    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && PollenCount > 0)
            particles.gameObject.SetActive(true);
    }
    private void Start()
    {
        Init();
    }
    void Init()
    {
        /*
        Plant[] planties = FindObjectsOfType<Plant>();
        foreach(Plant plant in plants)
            if(Vector3.Distance(plant.transform.position, transform.position) < 10)
                plants.Add(plant);
                */
        GameManager.beehiveInit.Invoke(this);
    }

    private void OnMouseDown()
    {
        Debug.Log($"Interracting with collector {this}");
        if(timer <= 0)
        {
            timer = cooldown;
            foreach (Plant plant in plants)
                print(plant);
        }
    }
}
