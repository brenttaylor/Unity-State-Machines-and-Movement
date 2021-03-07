using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float metersPerSecond = 10.0f;

    private Rigidbody2D rigidBody;

    public enum States {
        IDLE,
        MOVING_LEFT,
        MOVING_RIGHT
    }

    public enum Events {
        LEFT_DOWN,
        LEFT_UP,
        RIGHT_DOWN,
        RIGHT_UP
    }

    private States currentState {
        get {
            return (States) Variables.Object(gameObject).Get("currentState");
        }
    }

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetButtonDown("Left")) TriggerEvent(Events.LEFT_DOWN);
        if (Input.GetButtonDown("Right")) TriggerEvent(Events.RIGHT_DOWN);
        if (Input.GetButtonUp("Left")) TriggerEvent(Events.LEFT_UP);
        if (Input.GetButtonUp("Right")) TriggerEvent(Events.RIGHT_UP);
    }

    private void FixedUpdate() {
        float velocity = metersPerSecond * Time.deltaTime;
        Vector2 position = transform.position;

        switch (currentState) {
            case States.MOVING_LEFT:
                position.x -= velocity;
                break;
            case States.MOVING_RIGHT:
                position.x += velocity;
                break;
            case States.IDLE:
                return;
        }
        
        rigidBody.MovePosition(position);
    }
    
    private void TriggerEvent(Events evt) {
                CustomEvent.Trigger(this.gameObject, evt.ToString());
    }
}
