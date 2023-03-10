using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGround : MonoBehaviour
{
    //need a bool for moving left/right
    //need a way to hook up to players.y and a 
    public bool usesPlayerY = true;
    public bool movesHorizontly = false;
    public bool LeftOn_RightOff = false;
    public float horzSpeed = 1.0f;
    public float scale = 1;
    public float initialOffet = 0;
    Renderer render;
    public GameObject player;//get player object so that i can access the player script
    PlayerControl playVeloc;
    private void Awake()
    {
        render = gameObject.GetComponent<Renderer>();
        playVeloc = player.GetComponent<PlayerControl>();
    }
    void Update()
    {
        playVeloc = player.GetComponent<PlayerControl>();//update player.y
        Vector2 temp = new Vector2();//temp vector for multiple axis movemnet
        //vertical movement
        if (usesPlayerY)
        {
            temp.y = scale * -playVeloc.getPlayerY() + initialOffet;
        }
        else
        {
            temp.y = Time.time * scale + initialOffet;
        }
        //horizontal movement
        if (movesHorizontly)
        {
            if (LeftOn_RightOff)
            {
                temp.x = Time.time * horzSpeed;
            }
            else
            {
                temp.x = Time.time * -horzSpeed;
            }
        }
        render.material.mainTextureOffset = temp;
    }
}
