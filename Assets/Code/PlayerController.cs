/*
    Name: Nicholas Santos
    Date: 10/20/2020
    Desc: Movement
*/


using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float Speed = 200;
    public float AngularSpeed = 10;
    int jump = 0;
    public UnityEvent OnCollide = new UnityEvent();
    Rigidbody2D myRb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollide.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Setup variable to store how we should move
        Vector2 movement = new Vector2();

        //Check for input and use that to move
        movement.x = Input.GetAxisRaw("Horizontal");

        //Adjust the direction based on input
        myRb.AddForce(transform.right * movement.x * Speed * Time.deltaTime);

        if(Input.GetKey("space"))
        {
            //Adjust the speed based on input
            myRb.AddForce(transform.up * movement.y);
        }
    }
}
