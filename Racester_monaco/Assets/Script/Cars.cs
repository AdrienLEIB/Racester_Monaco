using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cars : MonoBehaviour
{
    public float test_v;
    public Text TxtSpeed;
    public Text TxtTime;
    public WheelCollider F_gauche; // roue avant G
    public WheelCollider F_right; // roue avant D
    public WheelCollider b_left; // roue arrière G
    public WheelCollider b_right; // roue arrière D
    
    public float Speed;
    public float Acceleration;
    public string Timer;
    public int minute;
    public float seconde;
    public float WheelAngleMax;
    public Vector3 position_checkpoint;
    public Vector3 position_start;
    public List<Vector3> list_checkpoint;
    public Rigidbody r;
    public float timer_acceleration;
    public bool RoueLibre;
    public StartPoint depart;

    
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        Acceleration = 50000000;
        WheelAngleMax = 50;
        r.centerOfMass = new Vector3(0f, -0.8f, 0.2f);
        position_checkpoint = transform.position;
        depart =  GameObject.FindGameObjectWithTag("StartPoint").GetComponent<StartPoint>();
        position_start = depart.transform.position;
        transform.position = position_start;
        test_v = depart.testc;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        minute = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
        seconde += Time.deltaTime;

        if (seconde > 60)
        {
            minute = minute + 1;
            seconde = seconde -60;
        }
        Timer = minute.ToString() +":" + seconde.ToString();
        Speed = r.velocity.magnitude * 3.6f; // Vitesse de l'objet exprimé en KM/H
        TxtSpeed.text = "Vitesse en KM/H : " + (int)Speed;
        TxtTime.text = "Temps(s) : " + Timer;

        if (!RoueLibre) {
            // Cette partie a été inspiré du tuto youtube : https://www.youtube.com/watch?v=9aFFNgQ1aRA
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z)) && Speed<100)
            {
                if (Speed == 0)
                {
                    r.AddForce(GetComponent<Transform>().forward * 300000);
                }
                b_left.brakeTorque = 0;
                b_right.brakeTorque = 0;
                b_left.motorTorque = Input.GetAxis("Vertical") * Acceleration;
                b_right.motorTorque = Input.GetAxis("Vertical") * Acceleration;
                /*
                timer_acceleration += Time.deltaTime;
                if(timer_acceleration > 10)
                {
                    timer_acceleration = 10;
                }
            
                Acceleration = timer_acceleration * 50000;
                r.AddForce(GetComponent<Transform>().forward * Acceleration); */

            }
            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
            {
                b_left.brakeTorque = 0;
                b_right.brakeTorque = 0;
                b_left.motorTorque = Input.GetAxis("Vertical") * Acceleration;
                b_right.motorTorque = Input.GetAxis("Vertical") * Acceleration;

            }
            if ((!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.Z)) && (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.S)) || Speed > 40)
            {
                if(!(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.Z)))
                {
                    b_left.motorTorque = 0;
                    b_right.motorTorque = 0;
                    b_left.brakeTorque = Acceleration;
                    b_right.brakeTorque = Acceleration;
                    //timer_acceleration = 15;
                }
                if(!(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.S)) && Speed < 60)
                {
                    b_left.motorTorque = 0;
                    b_right.motorTorque = 0;
                    b_left.brakeTorque = Mathf.Infinity ;
                    b_right.brakeTorque = Mathf.Infinity;
                }
            
            }
           if (Input.GetKey(KeyCode.Backspace))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.position = position_checkpoint;
                r.velocity = Vector3.zero;
            
            }
            if (Input.GetKey(KeyCode.Delete))
            {
            
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.position = position_start;
                minute = 0;
                seconde = 0;
                r.velocity = Vector3.zero;
            
            }
        }
        else
        {
            b_left.motorTorque = 0;
            b_right.motorTorque = 0;
            b_left.brakeTorque = Acceleration;
            b_right.brakeTorque = Acceleration;
        }
        F_gauche.steerAngle = Input.GetAxis("Horizontal") * WheelAngleMax;
        F_right.steerAngle = Input.GetAxis("Horizontal") * WheelAngleMax;
    }
}
