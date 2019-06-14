using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : Voiture
{
    public GameObject InTrigger = new GameObject();
    public float Power;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //position_checkpoint = transform.position;
        Debug.Log("Une voiture est entré dans le check");
        //InTrigger.GetComponent<Rigidbody>().AddForce((g.transform.position - transform.position) * Power);
        InTrigger.GetComponent<Voiture>().position_checkpoint = transform.position;
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}

