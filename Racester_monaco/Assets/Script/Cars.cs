using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cars : MonoBehaviour
{
    public Text TxtSpeed;
    public WheelCollider F_gauche; // roue avant G
    public WheelCollider F_right; // roue avant D
    public WheelCollider b_left; // roue arrière G
    public WheelCollider b_right; // roue arrière D

    public float Torque; 
    public float Speed;
    public int Brake;
    public float Acceleration;
    public float Timer;
    public float timer_acceleration;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        Speed = GetComponent<Rigidbody>().velocity.magnitude * 3.6f; // Vitesse de l'objet exprimé en KM/H
        TxtSpeed.text = "Vitesse en Km/h : " + (int)Speed;
        if (Input.GetKey(KeyCode.UpArrow) && Speed<60)
        {
            b_left.brakeTorque = 0;
            b_right.brakeTorque = 0;
            b_left.motorTorque = Input.GetAxis("Vertical") * Torque * Acceleration * Time.deltaTime;
            b_right.motorTorque = Input.GetAxis("Vertical") * Torque * Acceleration * Time.deltaTime;// GetAxis
            
        }
        if(!Input.GetKey(KeyCode.UpArrow) || Speed>60)
        {
            b_left.motorTorque = 0;
            b_right.motorTorque = 0;
            b_left.brakeTorque = Brake * Acceleration * Time.deltaTime;
            b_right.brakeTorque = Brake * Acceleration * Time.deltaTime;
        }
    }
}
