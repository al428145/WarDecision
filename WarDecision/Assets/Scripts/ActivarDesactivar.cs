using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarDesactivar : MonoBehaviour
{
    public GameObject territorio;
    LogicaPeleaV2 numeroRandomEscogido;
    // Start is called before the first frame update
    void Start()
    {
        numeroRandomEscogido = FindObjectOfType<LogicaPeleaV2>();
        territorio.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
