using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerateur : MonoBehaviour
{
    private Cars voiture;
    public float test;
    // Start is called before the first frame update
    void Start()
    {
        voiture = GameObject.FindGameObjectWithTag("Voiture").GetComponent<Cars>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        //test = 15;
        if (other.gameObject.tag == "Voiture")
        {
            test = 150;
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(-GetComponent<Transform>().forward * 650000);
            }
            else
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(GetComponent<Transform>().forward * 650000);
            }
                
        }
    }
}
