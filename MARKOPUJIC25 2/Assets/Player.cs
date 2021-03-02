using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AnimationModule;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed, 0);
        }
    }
}
