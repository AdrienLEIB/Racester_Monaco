using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private Cars voiture;
    private GameObject[] checkpoints;
    // Start is called before the first frame update
    void Start()
    {
        voiture = GameObject.FindGameObjectWithTag("Voiture").GetComponent<Cars>();
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Voiture")
        {
            if(voiture.list_checkpoint.Count == checkpoints.Length)
            {
                voiture.Speed = 0;
                voiture.position_checkpoint = transform.position;
            }
        }
    }
}
