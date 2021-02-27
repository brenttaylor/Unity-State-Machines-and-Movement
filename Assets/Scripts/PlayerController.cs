using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float metersPerSecond = 10.0f;

    private Rigidbody2D rigidBody;
    private bool moveLeft = false;
    private bool moveRight = false;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        moveLeft = Input.GetButton("Left");
        moveRight = Input.GetButton("Right");
    }

    private void FixedUpdate() {
        float velocity = metersPerSecond * Time.deltaTime;
        Vector2 position = transform.position;

        if (moveLeft) position.x -= velocity;
        if (moveRight) position.x += velocity;
        
        rigidBody.MovePosition(position);
    }
}
