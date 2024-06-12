using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wire_script : MonoBehaviour
{   static wire_script lastClick; 
    bool onMouseClick = false;
    void Update()
    {
        if (onMouseClick && lastClick== this)
        {
            HandleMovement();
        }

    }
    private void OnMouseDown()
    {   
        onMouseClick = true;
        lastClick = this;
    }
    private void HandleMovement()
    {
        int speed = 4;
        float y_move = 0;
        float x_move = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            y_move = 1.0f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            y_move = -1.0f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x_move = 1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x_move = -1.0f;
        }
        Vector3 direction = new Vector3(x_move, y_move, 0).normalized;

        transform.position += direction * Time.deltaTime * speed;

    }
}

