using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoxelGen : MonoBehaviour
{
    public float freq = 1f;
    public float amp = 20f;
    public GameObject CurrentBlockType;
    public GameObject Water;
    public GameObject[] Flowers;
    public GameObject[] trees;
    public List<GameObject> bloacks = new List<GameObject>();
    public List<Vector3> blockTransform = new List<Vector3>();
    public Material Autum;
    public Material Winter;
    
    public Material Grass;


   
    public void Start()
    {
        
        GenerateTerrain();
    }
    
    void GenerateTerrain()
    {
        float xSeed = Random.Range(0,1000);
        float zSeed = Random.Range(0,1000);

        float cols = 64f;
        float rows = 64f;

        for(float x = xSeed; x < cols + xSeed; x++)
        {
            
            for (float z = zSeed; z < rows + zSeed; z++)
            {
                float y = Mathf.PerlinNoise(x/(cols * freq), z/(rows * freq)) * amp;

                blockTransform.Add(new Vector3(x, y, z));
                GameObject InsBlock = GameObject.Instantiate(CurrentBlockType);
                InsBlock.transform.position = new Vector3(x - xSeed, y, z - zSeed);
                bloacks.Add(InsBlock);

                if (y < 3)
                {
                    blockTransform.Add(new Vector3(x, 3, z));
                    GameObject InsBlockW = GameObject.Instantiate(Water);
                    InsBlockW.transform.position = new Vector3(x - xSeed, 3, z - zSeed);
                } else
                {
                    float flower = Mathf.PerlinNoise(y * 10 - (int)y, y * 24 - (int)y) * 10;
                    float tree = Mathf.PerlinNoise(y * 4 - (int)y, y * 7 - (int)y) * 10;
                    

                    if (flower > 4 && flower < 6)
                    {
                        GameObject FlowerGO = Flowers[Random.Range(0, 3)];
                        GameObject Flower = Instantiate(FlowerGO);
                        Flower.transform.position = new Vector3(InsBlock.transform.position.x, InsBlock.transform.position.y + 1, InsBlock.transform.position.z);
                        Flower.transform.rotation = Quaternion.Euler(0,Random.Range(0,359),0);
                    } else if(flower > 6)
                    {
                        GameObject FlowerGO = Flowers[Random.Range(3, 7)];
                        GameObject Flower = Instantiate(FlowerGO);
                        Flower.transform.position = new Vector3(InsBlock.transform.position.x - 0.45f, InsBlock.transform.position.y + 0.5f, InsBlock.transform.position.z - 0.45f);
                    }
                    if (tree > 8) {

                        GameObject treeGO = trees[Random.Range(0, trees.Length - 1)];
                        GameObject Tree = Instantiate(treeGO);
                        Tree.transform.position = new Vector3(InsBlock.transform.position.x, InsBlock.transform.position.y + 0.4f, InsBlock.transform.position.z- 0.2f);
                    }
                }
            }
        }
        /*
        int index = 0;
        for (float x = 0; x < cols; x++)
        {
            for (float z = 0; z < rows; z++)
            {
                GameObject InsBlock = GameObject.Instantiate(CurrentBlockType);
                InsBlock.transform.position = blockTransform[index];
                for (int i = 0; i < 5; i++)
                {
                    // return for how many sides are next to and where
                }
                bloacks.Add(InsBlock);
                index++;
            }
        }
        */
    }

    void KillTerrain ()
    {
        for (int i = bloacks.Count - 1; bloacks.Count > 0; i--)
        {
            Destroy(bloacks[i]);
            bloacks.RemoveAt(i);
        }
        GenerateTerrain();
    }
    
    void ToAutum()
    {
        Camera.main.GetComponent<Camera>().backgroundColor = new Color(183,130,4);
        for (int i = bloacks.Count - 1; bloacks.Count > 0; i--)
        {
            bloacks[i].GetComponent<MeshRenderer>().material = Autum;
        }
    }
    void ToWinter()
    {
        for (int i = bloacks.Count - 1; bloacks.Count > 0; i--)
        {
            bloacks[i].GetComponent<MeshRenderer>().material = Winter;
        }
    }
    void ToSpring()
    {
        for (int i = bloacks.Count - 1; bloacks.Count > 0; i--)
        {
            bloacks[i].GetComponent<MeshRenderer>().material = Grass;
        }
    }

}
