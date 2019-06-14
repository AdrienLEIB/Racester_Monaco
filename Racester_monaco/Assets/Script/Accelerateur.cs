using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerateur : MonoBehaviour
{
    private Voiture voiture;

    // Start is called before the first frame update
    void Start()
    {
        voiture = GameObject.FindGameObjectWithTag("Voiture").GetComponent<Voiture>();
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
            other.gameObject.GetComponent<Rigidbody>().AddForce(other.GetComponent<Transform>().forward * 200);
        }
    }
}
