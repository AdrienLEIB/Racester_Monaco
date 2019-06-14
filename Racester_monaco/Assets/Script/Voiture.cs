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

    public float timer;
    public float timer_acceleration;
    public float timer_down;
    // Start is called before the first frame update
    void Start()
    {
        position_checkpoint = transform.position;
        position_start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Rigidbody r = GetComponent<Rigidbody>();
        if ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D)))
        {
            GetComponent<Transform>().Rotate(new Vector3(0, 1, 0));
            r.AddForce(GetComponent<Transform>().forward * (Speed));
        }
        else if ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.Q)))
        {
            GetComponent<Transform>().Rotate(new Vector3(0, -1, 0));
        }
        else if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.Z)))
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
            r.AddForce(GetComponent<Transform>().forward * Speed);
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
            r.AddForce(GetComponent<Transform>().forward * Speed);
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
