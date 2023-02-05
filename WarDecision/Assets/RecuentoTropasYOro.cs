using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecuentoTropasYOro : MonoBehaviour
{
    public Text tropasRecuento;
    public Text oroRecuento;

    int tropas = 0;
    int oro = 0;

    // Start is called before the first frame update
    void Start()
    {
        tropasRecuento.text = (GameObject.FindWithTag("tropas")).GetComponent<Text>();
        oroRecuento.text = (GameObject.FindWithTag("oro")).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
