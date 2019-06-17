using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rouelibre : MonoBehaviour
{
    private Cars voiture;
    private bool checkpoint_valide;
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
        if (other.gameObject.tag == "Voiture")
        {

            voiture.RoueLibre = true;
        }
    }
}
