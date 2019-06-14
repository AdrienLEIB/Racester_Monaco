using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cars : MonoBehaviour
{
    public Text TxtSpeed;
    public Text TxtTime;
    public WheelCollider F_gauche; // roue avant G
    public WheelCollider F_right; // roue avant D
    public WheelCollider b_left; // roue arrière G
    public WheelCollider b_right; // roue arrière D

    public float Torque; 
    public float Speed;
    public int Brake;
    public float Acceleration;
    public float Timer;
    public float WheelAngleMax;
    public Vector3 position_checkpoint;
    private Vector3 position_start;
    public List<Vector3> list_checkpoint;
    

    // Start is called before the first frame update
    void Start()
    {
        Torque = 200000;
        Acceleration = 5;
        Brake = 200000;
        WheelAngleMax = 50;
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0f, -0.9f, 0.2f);
        position_checkpoint = transform.position;
        position_start = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        Speed = GetComponent<Rigidbody>().velocity.magnitude * 3.6f; // Vitesse de l'objet exprimé en KM/H
        TxtSpeed.text = "Vitesse en KM/H : " + (int)Speed;
        TxtTime.text = "Temps(s) : " + (int)Timer;
        if ((Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.Z)) && Speed<60)
        {
            b_left.brakeTorque = 0;
            b_right.brakeTorque = 0;
            b_left.motorTorque = Input.GetAxis("Vertical") * Torque * Acceleration * Time.deltaTime;
            b_right.motorTorque = Input.GetAxis("Vertical") * Torque * Acceleration * Time.deltaTime;// GetAxis
            
        }
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && Speed<20)
        {
            b_left.brakeTorque = 0;
            b_right.brakeTorque = 0;
            b_left.motorTorque = Input.GetAxis("Vertical") * Torque * Acceleration;
            b_right.motorTorque = Input.GetAxis("Vertical") * Torque * Acceleration;

        }
        if (!(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z)) && !(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            if(!(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z)))
            {
                b_left.motorTorque = 0;
                b_right.motorTorque = 0;
                b_left.brakeTorque = Brake * Acceleration * Time.deltaTime;
                b_right.brakeTorque = Brake * Acceleration * Time.deltaTime;
            }
            if(!(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
            {
                b_left.motorTorque = 0;
                b_right.motorTorque = 0;
                b_left.brakeTorque = Mathf.Infinity ;
                b_right.brakeTorque = Mathf.Infinity;
            }

        }
       if (Input.GetKey(KeyCode.Backspace))
        {
            transform.position = position_checkpoint;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 0;
            rotationVector.x = 0;
            rotationVector.y = 0;
        }
        if (Input.GetKey(KeyCode.Delete))
        {
            transform.position = position_start;
            Timer = 0;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 0;
            rotationVector.x = 0;
            rotationVector.y = 0;
        }

        F_gauche.steerAngle = Input.GetAxis("Horizontal") * WheelAngleMax;
        F_right.steerAngle = Input.GetAxis("Horizontal") * WheelAngleMax;
    }
}
