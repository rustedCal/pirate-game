using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;//get player object so that i can access the player script
    PlayerControl playVeloc;
    Rigidbody2D rigid;
    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        playVeloc = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        playVeloc = player.GetComponent<PlayerControl>();//update player.y
        gameObject.transform.position = new Vector3(0.0f, playVeloc.getPlayerY(), -10.0f);
    }
}
