using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{

    public AudioSource music1;
    public AudioSource music2;
    public AudioSource music3;

    public bool musicLoop2;
    public bool musicLoop3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (music1.isPlaying == false && musicLoop2 == false && musicLoop3 == false)
        {

        }
    }

    
    



}
