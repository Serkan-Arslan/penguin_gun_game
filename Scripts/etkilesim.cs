using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class etkilesim : MonoBehaviour
{
    public Text text;

    static public List<GameObject> etkilesim_liste;
    // Start is called before the first frame update
    void Start()
    {
        etkilesim_liste = new List<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text="Skor:"+" "+etkilesim_liste.Count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        etkilesim_liste.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        etkilesim_liste.Remove(other.gameObject);
    }
}
