using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Checkpoint2 : MonoBehaviour
{
    private Cars voiture;
    private bool checkpoint_valide;
    public List<float> tab;
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
        if (other.gameObject.tag == "Voiture"){
            checkpoint_valide = false;
            foreach(Vector3 chekpoint in voiture.list_checkpoint)
            {
                if(transform.position == chekpoint)
                {
                    checkpoint_valide = true;
                }
            }
            if (!checkpoint_valide)
            {
                voiture.position_checkpoint = transform.position;
                voiture.list_checkpoint.Add(transform.position);
                voiture.list_temps_checkpoint.Add(voiture.timer);
                voiture.RoueLibre = false;
                string m_Path = Application.dataPath;

                if (File.Exists(m_Path + @"\Save\load_checkpoints.txt"))
                {
                    using (StreamReader sr = new StreamReader(m_Path + @"\Save\load_checkpoints.txt"))
                    {

                        int count = 0;
                        string l1;
                        sr.ReadLine();
                        //float[] tab = new float[voiture.list_temps_checkpoint.Count];

                        while ((l1 = sr.ReadLine()) != null)
                        {
                            tab.Add(float.Parse(l1));
                            count++;
                        }
                        //voiture.DiffTime.text = count.ToString();

                        if (tab[voiture.list_temps_checkpoint.Count - 1] < voiture.list_temps_checkpoint[voiture.list_temps_checkpoint.Count - 1])
                        {
                            voiture.DiffTime.color = UnityEngine.Color.red;
                            float diff = voiture.list_temps_checkpoint[voiture.list_temps_checkpoint.Count-1] - tab[voiture.list_temps_checkpoint.Count - 1];
                            voiture.DiffTime.text = "+ " + diff.ToString();
                        }
                        else if (tab[voiture.list_temps_checkpoint.Count - 1] > voiture.list_temps_checkpoint[voiture.list_temps_checkpoint.Count - 1])
                        {
                            voiture.DiffTime.color = UnityEngine.Color.blue;
                            float diff =  tab[voiture.list_temps_checkpoint.Count - 1] - voiture.list_temps_checkpoint[voiture.list_temps_checkpoint.Count - 1];
                            voiture.DiffTime.text = "- " + diff.ToString();
                        }
                        else
                        {
                            voiture.DiffTime.color = UnityEngine.Color.grey;
                            float diff = voiture.list_temps_checkpoint[voiture.list_temps_checkpoint.Count - 1] - tab[voiture.list_temps_checkpoint.Count - 1];
                            voiture.DiffTime.text = "= " + diff.ToString();
                        }
                    }
                }
                else
                {
                    voiture.DiffTime.color = UnityEngine.Color.grey;
                    voiture.DiffTime.text = voiture.list_temps_checkpoint[voiture.list_temps_checkpoint.Count - 1].ToString();
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        voiture.DiffTime.color = UnityEngine.Color.grey;
        voiture.DiffTime.text = " ";
    }
}
