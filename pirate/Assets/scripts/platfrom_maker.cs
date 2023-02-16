using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class platfrom_maker : MonoBehaviour
{
    //where to put the next plat
    public float offset = 2.5f;//x offset from 0 (-2.5,0,2.5)
    public float distanceBetween = 5.0f;//y offset between plats
    float nextplatY;
    //count of current active platforms
    public int maxActivePlat = 5;
    int platCount = 0;
    //what to make
    public GameObject platPrefab;
    void Start()
    {
        platCount = GameObject.FindGameObjectsWithTag("platform").Length;
        nextplatY = platCount * distanceBetween;
    }

    // Update is called once per frame
    void Update()
    {
        platCount = GameObject.FindGameObjectsWithTag("platform").Length;
        Debug.Log(platCount);
        if (platCount < maxActivePlat)
        {
            float randPosX;
            int temp = Random.Range(1, 4);
            if (temp == 1)
                randPosX = -offset;
            else if (temp == 2)
                randPosX = 0;
            else
                randPosX = offset;
            GameObject platObject = Instantiate(platPrefab, new Vector2(randPosX, nextplatY), Quaternion.identity);
            Debug.Log("tryed to make new plat");
            nextplatY += distanceBetween;
        }
    }
}
