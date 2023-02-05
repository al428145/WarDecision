using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject republicanosUI;
    public GameObject franquistasUI;
    public GameObject recursosRepublicanos;
    public GameObject recursosFranquistas;
    public GameObject bolaFranquista1;
    public GameObject bolaFranquista2;
    public GameObject bolaRepublicana1;
    public GameObject bolaRepublicana2;

    public Text textoOroFranquista;
    public Text textoTropasFranquistas;
    public Text textoOroRepublicano;
    public Text textoTropasRepublicanas;

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

        textoOroFranquista.text = oroFranquista.ToString();
        textoOroRepublicano.text = oroRepublicano.ToString();
        textoTropasFranquistas.text = tropasFranquistas.ToString();
        textoTropasRepublicanas.text = tropasRepublicanas.ToString();
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

        if (turno % 2 == 0) // turno republicano
        {
            republicanosUI.SetActive(true);
            franquistasUI.SetActive(false);
            recursosRepublicanos.SetActive(true);
            recursosFranquistas.SetActive(false);
            bolaFranquista1.SetActive(false);
            bolaFranquista2.SetActive(false);
            bolaRepublicana1.SetActive(true);
            bolaRepublicana2.SetActive(true);
        }
        else // turno franquista
        {
            republicanosUI.SetActive(false);
            franquistasUI.SetActive(true);
            recursosRepublicanos.SetActive(false);
            recursosFranquistas.SetActive(true);
            bolaFranquista1.SetActive(true);
            bolaFranquista2.SetActive(true);
            bolaRepublicana1.SetActive(false);
            bolaRepublicana2.SetActive(false);


        }
    }

    public void Batalla()
    {

    }
}
