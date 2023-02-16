using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGround : MonoBehaviour
{
    public float speed = 0;
    Renderer render;
    private void Awake()
    {
        render = gameObject.GetComponent<Renderer>();
    }
    void Update()
    {
        render.material.mainTextureOffset = new Vector2(0.0f, Time.time * speed);
    }
}
