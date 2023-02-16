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
        platCount = GameObject.FindGameObjectsWithTag("platform").Length;//update plat count
        Debug.Log(platCount);
        if (platCount < maxActivePlat)//if plats are less than how many we want active at a time, them make more
        {
            float randPosX;//random offset
            int temp = Random.Range(1, 4);
            if (temp == 1)//if else statements for the random offset (-2.5,0,2.5)
                randPosX = -offset;
            else if (temp == 2)
                randPosX = 0;
            else
                randPosX = offset;
            //create a new plat at the random x offset and the next y position for the platforms
            GameObject platObject = Instantiate(platPrefab, new Vector2(randPosX, nextplatY), Quaternion.identity);
            Debug.Log("tryed to make new plat");
            nextplatY += distanceBetween;//ad to the y offset so that they dont satack ontop of eachother
        }
    }
}
