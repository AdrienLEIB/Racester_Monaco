using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class End : MonoBehaviour
{
    private Cars voiture;
    private GameObject[] checkpoints;
    public List<float> tab;
    private bool new_load;
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
        string m_Path = Application.dataPath;

        if (other.gameObject.tag == "Voiture")
        {
            new_load = false;

            if(voiture.list_checkpoint.Count == checkpoints.Length)
            {
                voiture.position_checkpoint = transform.position;
                voiture.list_temps_checkpoint.Add(voiture.timer);
                
                if(File.Exists(m_Path+ @"\Save\load_checkpoints.txt"))
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
                        
                        if(tab[voiture.list_temps_checkpoint.Count-1] < voiture.list_temps_checkpoint[voiture.list_temps_checkpoint.Count - 1])
                        {
                            voiture.DiffTime.color = UnityEngine.Color.red;
                            //float diff = voiture.list_temps_checkpoint[voiture.list_temps_checkpoint.Count] - tab[1];

                            voiture.DiffTime.text = voiture.list_temps_checkpoint[voiture.list_temps_checkpoint.Count - 1].ToString();
                            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        }
                        else if (tab[voiture.list_temps_checkpoint.Count - 1] > voiture.list_temps_checkpoint[voiture.list_temps_checkpoint.Count - 1])
                        {
                            voiture.DiffTime.color = UnityEngine.Color.blue;
                            voiture.DiffTime.text = voiture.list_temps_checkpoint[voiture.list_temps_checkpoint.Count - 1].ToString();
                            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                            new_load = true;
                        }
                        else
                        {
                            voiture.DiffTime.color = UnityEngine.Color.grey;
                            voiture.DiffTime.text = voiture.list_temps_checkpoint[voiture.list_temps_checkpoint.Count - 1].ToString();
                            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        }
                    }
                }
                else
                {
                    new_load = true;
                    voiture.DiffTime.color = UnityEngine.Color.grey;
                    voiture.DiffTime.text = voiture.list_temps_checkpoint[voiture.list_temps_checkpoint.Count - 1].ToString();
                    other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }


            }
        }
        if (new_load)
        {
            using (StreamWriter sw = new StreamWriter(m_Path + @"\Save\load_temps.txt", false))
            {
                sw.WriteLine();
                sw.WriteLine(voiture.minute);
                sw.WriteLine(voiture.seconde);
            }
            using (StreamWriter sw = new StreamWriter(m_Path + @"\Save\load_checkpoints.txt", false))
            {
                sw.WriteLine();
                foreach (float chekpoint in voiture.list_temps_checkpoint)
                {
                    sw.WriteLine(chekpoint);
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
