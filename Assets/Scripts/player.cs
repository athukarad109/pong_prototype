using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    
    [SerializeField] float speed = 15f;
    Vector2 speedVector;

    private float startPosX;
    private float startPosY;
    private bool isHeld = false;

    void Start()
    {
        speedVector = new Vector2(speed, 0f);
    }

    
    void Update()
    {
        move();
        moveWithMouse();
    }

    void move()
    {
        float x = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(speedVector.x * x, transform.position.y * speedVector.y, 0) * Time.deltaTime;

        transform.Translate(movement);

    }


    private void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            isHeld = true;
        }


    }

    private void OnMouseUp()
    {
        isHeld = false;
    }

    void moveWithMouse()
    {
        if (isHeld)
        {
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, -3.5f, 0);

        }
    }

}
