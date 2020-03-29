using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BeehiveCollector : Beehive
{
    byte Status = 0; // 0 - idle, 1 - collecting, 2 - full with honey
    [Space(10)]
    float timer = 0;
    [SerializeField]
    ParticleSystem particlesBeesWorking;
    [SerializeField]
    ParticleSystem particlesHoneyFlowing;
    int PollenCount = 0;
    bool active = false;
    public void Update()
    {
        timer -= Time.deltaTime;
    }

    private void OnMouseDown()
    {
        PollenCount = 0;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(PollenCount == 0)
            {
                Status = 1;
            }
        }
        switch (Status)
        {
            default:
            case 1:
                return;
        }
    }
}
