using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    public bool open;
    private float timer;
    public float up;
    public float og;

    private void Start()
    {
        up=transform.position.y+transform.localScale.y;
        og=transform.position.y;
    }
    public void Move()=>open = !open;

    public void Update()
    {
        if((open)?transform.position.y<up: transform.position.y > og) transform.position += new Vector3(0, open?.05f:-.05f, 0);
    }
}
