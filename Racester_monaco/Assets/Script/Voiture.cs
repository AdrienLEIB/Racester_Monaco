using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voiture : MonoBehaviour
{
    public float Speed;
    public Vector3 position_checkpoint;
    private Vector3 position_start;
    public List<Vector3> list_checkpoint;
    public WheelCollider F_gauche; // roue avant G
    public WheelCollider F_right; // roue avant D
    public WheelCollider b_left; // roue arrière G
    public WheelCollider b_right; // roue arrière D
    public float timer;
    public float timer_acceleration;
    public float timer_down;
    // Start is called before the first frame update
    void Start()
    {
        position_checkpoint = transform.position;
        position_start = transform.position;
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0f, -0.9f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Rigidbody r = GetComponent<Rigidbody>();
        F_gauche.steerAngle = Input.GetAxis("Horizontal") * 50;
        F_right.steerAngle = Input.GetAxis("Horizontal") * 50;
        if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.Z)))
        {
            //peed = 1;
            timer_acceleration += Time.deltaTime;
            if (Speed < 20)
            {
                Speed = timer_acceleration * 20;
            }
            else
            {
                Speed = 20;
            }
            r.AddForce(GetComponent<Transform>().forward * Speed *1500);
        }
        else if ((Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.S)))
        {
            if (Speed > 1)
            {
                if(timer_acceleration>0)
                {
                    timer_acceleration -= Time.deltaTime;
                    Speed = timer_acceleration * 1/5;
                }
                else
                {
                    timer_acceleration = 0;
                    Speed = -20;
                }
                
                r.AddForce(GetComponent<Transform>().forward * Speed);
            }
            else
            {
                timer_acceleration = 0;
                Speed = -20;
            }
            r.AddForce(GetComponent<Transform>().forward * Speed *1500);
        }
 /*       else if (Input.GetKeyDown(KeyCode.Space))
        {
            r.AddForce(new Vector3(0, 500, 0));
        }*/
        else if (Input.GetKey(KeyCode.Backspace))
        {
            transform.position = position_checkpoint;
            Speed = 0;
            timer_acceleration = 0;
            r.velocity = Vector3.zero;
        }
        else if (Input.GetKey(KeyCode.Delete))
        {
            transform.position = position_start;
            timer = 0;
            r.velocity = Vector3.zero;
        }
        else if(true)
        {
            
            if (Speed > 0) {
                timer_acceleration -= Time.deltaTime;
                Speed = timer_acceleration * 10;
                //r.AddForce(GetComponent<Transform>().forward * Speed);
            }
            else
            {
                Speed = 0;
                timer_acceleration = 0;
            }
        }
    }
} 
