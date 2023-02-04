using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaPeleaV2 : MonoBehaviour
{
    // Recordamos conversión: 1 soldado cuesta 0.25 de oro
    public int tropasFranquistas = 20000;
    public int tropasRepublicanas = 22000;
    public int oroFranquista = 1500;
    public int oroRepublicano = 1300;
    public int territoriosFranquistas = 0;
    public int territoriosRepublicanos = 0;
    public int diferenciaTropas;
    int poderFranquista;
    int poderRepublicano;


    public void Batalla (seleccionTropasRepublicanas, seleccionTropasFranquistas)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (tropasFranquistas == 0 || oroFranquista == 0 || territoriosRepublicanos == 7)
        {
            SceneManager.LoadScene("VictoriaRepublicana");
        }

        if (tropasRepublicanas == 0 || oroRepublicano == 0 || territoriosFranquistas == 7)
        {
            SceneManager.LoadScene("VictoriaFranquista");
        }
    }
}
