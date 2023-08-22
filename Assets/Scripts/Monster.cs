using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public float speed;
    private Rigidbody2D _myBody;

    private void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _myBody.velocity = new Vector2(speed, _myBody.velocity.y);
    }
}
