using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
    [SerializeReference] private GameObject leftButton;
    [SerializeReference] private GameObject rightButton;
    void Update() {
        leftButton.SetActive(false);
        rightButton.SetActive(false);

        try {
            if (Input.GetButton("Left")) {
                leftButton.SetActive(true);
            }

            if (Input.GetButton("Right")) {
                rightButton.SetActive(true);
            }
        }
        catch (ArgumentException) {
        }
    }
}
