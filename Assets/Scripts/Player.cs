using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 lastTouchPlace;
    public float speed;
    public float forwardSpeed;

    public static Player main;
    void Awake()
    {
        main = this;
        rb = GetComponent<Rigidbody>();
        lastTouchPlace = Camera.main.WorldToScreenPoint(this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsIdle() && Input.GetMouseButtonDown(0))
             GameManager.main.ChangeGameState(GameStates.Playing);

        if (GameManager.IsPlaying())
        {
            if (GameManager.IsNotOnUI() && Input.GetMouseButton(0))
                MoveHorizontally();
            MoveForward();
        }
    }

    void MoveHorizontally()
    {
        if (lastTouchPlace == Input.mousePosition)
            return;
        
        Vector3 dir  = new Vector3(((Input.mousePosition - lastTouchPlace).x), 0,0).normalized;
        
        Debug.Log(dir);
        if(Mathf.Abs((transform.position + dir * speed * Time.deltaTime).x) < 1.65f)
            rb.MovePosition(transform.position + dir*speed*Time.deltaTime);
        //transform.position += Vector3.Lerp(transform.position, dir, 5f *  Time.deltaTime);
        lastTouchPlace = Input.mousePosition;

    }

    private void MoveForward()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        //rb.AddForce(Vector3.down * 100);
        Debug.Log(rb.velocity);
        
        //rb.MovePosition(transform.position + Vector3.forward * forwardSpeed * Time.deltaTime);
    }
    
    public void StopRB()
    {
        rb.velocity = Vector3.zero;
    }
    public void ResetPosition()
    {
        transform.position = LevelManager.main.currentLevel.levelEnd.transform.position;
    }
}
