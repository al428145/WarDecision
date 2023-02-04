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
    int diferenciaTropas;
    int poderFranquista;
    int poderRepublicano;

    public GameObject andalucia;
    public GameObject castilla;
    public GameObject galicia;
    public GameObject paisvasco;
    public GameObject barcelona;
    public GameObject valencia;
    public GameObject madrid;

    private int turno = 1; // par = republicano, impar = franquista

    // Start is called before the first frame update
    void Start()
    {
        andalucia.SetActive(true);
        castilla.SetActive(false);
        galicia.SetActive(false);
        paisvasco.SetActive(false);
        barcelona.SetActive(false);
        valencia.SetActive(false);
        madrid.SetActive(false);
    }
        
    

    // Update is called once per frame
    void Update()
    {
        if (turno % 2 == 0) // turno republicano
        {

        }
        else // turno franquista
        {

        }


        if (tropasFranquistas == 0 || oroFranquista == 0 || territoriosRepublicanos == 7)
        {
            SceneManager.LoadScene("VictoriaRepublicana");
        }

        if (tropasRepublicanas == 0 || oroRepublicano == 0 || territoriosFranquistas == 7)
        {
            SceneManager.LoadScene("VictoriaFranquista");
        }
    }

    public void Batalla()
    {
        
    }
}
