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
    public int oroFranquista = 2500;
    public int oroRepublicano = 2300;
    public int territoriosFranquistas = 0;
    public int territoriosRepublicanos = 0;

    public GameObject andalucia;
    public GameObject castilla;
    public GameObject galicia;
    public GameObject paisvasco;
    public GameObject barcelona;
    public GameObject valencia;
    public GameObject madrid;
    public GameObject mapaNormal;
    public GameObject republicanosUI;
    public GameObject franquistasUI;
    //public GameObject recursosRepublicanos;
    //public GameObject recursosFranquistas;
    //public GameObject bolaFranquista1;
    //public GameObject bolaFranquista2;
    //public GameObject bolaRepublicana1;
    //public GameObject bolaRepublicana2;

    public Slider sliderFranquistasDesplegados;
    public Slider sliderRepublicanosDesplegados;

    public Text textoOroFranquista;
    public Text textoTropasFranquistas;
    public Text textoOroRepublicano;
    public Text textoTropasRepublicanas;
    public Text franquistasDesplegados;
    public Text republicanosDesplegados;

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
        mapaNormal.SetActive(false);

        textoOroFranquista.text = oroFranquista.ToString();
        textoOroRepublicano.text = oroRepublicano.ToString();
        textoTropasFranquistas.text = tropasFranquistas.ToString();
        textoTropasRepublicanas.text = tropasRepublicanas.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        float maxTropasFranquistas = (float)oroFranquista / 0.25f;
        float maxTropasRepublicanas = (float)oroRepublicano / 0.25f;

        if (maxTropasFranquistas > tropasFranquistas)
        {
            maxTropasFranquistas = tropasFranquistas;
        }

        if (maxTropasRepublicanas > tropasRepublicanas)
        {
            maxTropasRepublicanas = tropasRepublicanas;
        }

        if (tropasFranquistas == 0 || oroFranquista == 0 || territoriosRepublicanos == 4)
        {
            SceneManager.LoadScene("VictoriaRepublicana");
        }

        if (tropasRepublicanas == 0 || oroRepublicano == 0 || territoriosFranquistas == 4)
        {
            SceneManager.LoadScene("VictoriaFranquista");
        }


        if (turno % 2 == 0) // turno republicano
        {
            republicanosUI.SetActive(true);
            franquistasUI.SetActive(false);
            //recursosRepublicanos.SetActive(true);
            //recursosFranquistas.SetActive(false);
            //bolaFranquista1.SetActive(false);
            //bolaFranquista2.SetActive(false);
            //bolaRepublicana1.SetActive(true);
            //bolaRepublicana2.SetActive(true);

            sliderRepublicanosDesplegados.maxValue = (int)maxTropasRepublicanas;
            int valorSliderRepublicano = (int)sliderRepublicanosDesplegados.value;

            republicanosDesplegados.text = "Número de tropas desplegadas: " + valorSliderRepublicano.ToString();
        }
        else // turno franquista
        {
            republicanosUI.SetActive(false);
            franquistasUI.SetActive(true);
            //recursosRepublicanos.SetActive(false);
            //recursosFranquistas.SetActive(true);
            //bolaFranquista1.SetActive(true);
            //bolaFranquista2.SetActive(true);
            //bolaRepublicana1.SetActive(false);
            //bolaRepublicana2.SetActive(false);

            oroFranquista += (territoriosFranquistas * 500);
            oroRepublicano += (territoriosRepublicanos * 500);


            sliderFranquistasDesplegados.maxValue = (int)maxTropasFranquistas;
            int valorSliderFranquista = (int)sliderFranquistasDesplegados.value;

            franquistasDesplegados.text = "Número de tropas desplegadas: " + valorSliderFranquista.ToString();
        }
    }


    public void AvanzarTurno(int valorSliderFranquista, int valorSliderRepublicano)
    {
        turno += 1;
        if (turno == 3)
        {
            int diceRollFranquista = Random.Range(1, 7);
            int poderFranquista = valorSliderFranquista * diceRollFranquista;

            int diceRollRepublicano = Random.Range(1, 7);
            int poderRepublicano = valorSliderRepublicano * diceRollRepublicano;

            if (poderFranquista - poderRepublicano > 0) // gana franquista
            {
                territoriosFranquistas += 1;

                if (poderFranquista - poderRepublicano >= 10000) // victoria aplastante
                {
                    tropasFranquistas -= (int)(0.2f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.75f * valorSliderRepublicano);
                }
                else
                {
                    tropasFranquistas -= (int)(0.4f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.5f * valorSliderRepublicano);
                }
            }
            else
            {
                territoriosRepublicanos += 1; // gana republicano

                if (poderRepublicano - poderFranquista >= 10000) // victoria aplastante
                {
                    tropasFranquistas -= (int)(0.75f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.2f * valorSliderRepublicano);
                }
                else
                {
                    tropasFranquistas -= (int)(0.5f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.4f * valorSliderRepublicano);
                }
                
            }

            andalucia.SetActive(false);
            castilla.SetActive(true);
            galicia.SetActive(false);
            paisvasco.SetActive(false);
            barcelona.SetActive(false);
            valencia.SetActive(false);
            madrid.SetActive(false);
            mapaNormal.SetActive(false);
        }
        if (turno == 5)
        {
            int diceRollFranquista = Random.Range(1, 7);
            int poderFranquista = valorSliderFranquista * diceRollFranquista;

            int diceRollRepublicano = Random.Range(1, 7);
            int poderRepublicano = valorSliderRepublicano * diceRollRepublicano;

            if (poderFranquista - poderRepublicano > 0) // gana franquista
            {
                territoriosFranquistas += 1;

                if (poderFranquista - poderRepublicano >= 10000) // victoria aplastante
                {
                    tropasFranquistas -= (int)(0.2f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.75f * valorSliderRepublicano);
                }
                else
                {
                    tropasFranquistas -= (int)(0.4f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.5f * valorSliderRepublicano);
                }
            }
            else
            {
                territoriosRepublicanos += 1; // gana republicano

                if (poderRepublicano - poderFranquista >= 10000) // victoria aplastante
                {
                    tropasFranquistas -= (int)(0.75f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.2f * valorSliderRepublicano);
                }
                else
                {
                    tropasFranquistas -= (int)(0.5f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.4f * valorSliderRepublicano);
                }

            }

            andalucia.SetActive(false);
            castilla.SetActive(false);
            galicia.SetActive(true);
            paisvasco.SetActive(false);
            barcelona.SetActive(false);
            valencia.SetActive(false);
            madrid.SetActive(false);
            mapaNormal.SetActive(false);
        }
        if (turno == 7)
        {
            int diceRollFranquista = Random.Range(1, 7);
            int poderFranquista = valorSliderFranquista * diceRollFranquista;

            int diceRollRepublicano = Random.Range(1, 7);
            int poderRepublicano = valorSliderRepublicano * diceRollRepublicano;

            if (poderFranquista - poderRepublicano > 0) // gana franquista
            {
                territoriosFranquistas += 1;

                if (poderFranquista - poderRepublicano >= 10000) // victoria aplastante
                {
                    tropasFranquistas -= (int)(0.2f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.75f * valorSliderRepublicano);
                }
                else
                {
                    tropasFranquistas -= (int)(0.4f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.5f * valorSliderRepublicano);
                }
            }
            else
            {
                territoriosRepublicanos += 1; // gana republicano

                if (poderRepublicano - poderFranquista >= 10000) // victoria aplastante
                {
                    tropasFranquistas -= (int)(0.75f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.2f * valorSliderRepublicano);
                }
                else
                {
                    tropasFranquistas -= (int)(0.5f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.4f * valorSliderRepublicano);
                }

            }

            andalucia.SetActive(false);
            castilla.SetActive(false);
            galicia.SetActive(false);
            paisvasco.SetActive(true);
            barcelona.SetActive(false);
            valencia.SetActive(false);
            madrid.SetActive(false);
            mapaNormal.SetActive(false);
        }
        if (turno == 9)
        {
            int diceRollFranquista = Random.Range(1, 7);
            int poderFranquista = valorSliderFranquista * diceRollFranquista;

            int diceRollRepublicano = Random.Range(1, 7);
            int poderRepublicano = valorSliderRepublicano * diceRollRepublicano;

            if (poderFranquista - poderRepublicano > 0) // gana franquista
            {
                territoriosFranquistas += 1;

                if (poderFranquista - poderRepublicano >= 10000) // victoria aplastante
                {
                    tropasFranquistas -= (int)(0.2f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.75f * valorSliderRepublicano);
                }
                else
                {
                    tropasFranquistas -= (int)(0.4f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.5f * valorSliderRepublicano);
                }
            }
            else
            {
                territoriosRepublicanos += 1; // gana republicano

                if (poderRepublicano - poderFranquista >= 10000) // victoria aplastante
                {
                    tropasFranquistas -= (int)(0.75f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.2f * valorSliderRepublicano);
                }
                else
                {
                    tropasFranquistas -= (int)(0.5f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.4f * valorSliderRepublicano);
                }

            }

            andalucia.SetActive(false);
            castilla.SetActive(false);
            galicia.SetActive(false);
            paisvasco.SetActive(false);
            barcelona.SetActive(true);
            valencia.SetActive(false);
            madrid.SetActive(false);
            mapaNormal.SetActive(false);
        }
        if (turno == 11)
        {
            int diceRollFranquista = Random.Range(1, 7);
            int poderFranquista = valorSliderFranquista * diceRollFranquista;

            int diceRollRepublicano = Random.Range(1, 7);
            int poderRepublicano = valorSliderRepublicano * diceRollRepublicano;

            if (poderFranquista - poderRepublicano > 0) // gana franquista
            {
                territoriosFranquistas += 1;

                if (poderFranquista - poderRepublicano >= 10000) // victoria aplastante
                {
                    tropasFranquistas -= (int)(0.2f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.75f * valorSliderRepublicano);
                }
                else
                {
                    tropasFranquistas -= (int)(0.4f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.5f * valorSliderRepublicano);
                }
            }
            else
            {
                territoriosRepublicanos += 1; // gana republicano

                if (poderRepublicano - poderFranquista >= 10000) // victoria aplastante
                {
                    tropasFranquistas -= (int)(0.75f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.2f * valorSliderRepublicano);
                }
                else
                {
                    tropasFranquistas -= (int)(0.5f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.4f * valorSliderRepublicano);
                }

            }

            andalucia.SetActive(false);
            castilla.SetActive(false);
            galicia.SetActive(false);
            paisvasco.SetActive(false);
            barcelona.SetActive(false);
            valencia.SetActive(true);
            madrid.SetActive(false);
            mapaNormal.SetActive(false);
        }
        if (turno == 13)
        {
            int diceRollFranquista = Random.Range(1, 7);
            int poderFranquista = valorSliderFranquista * diceRollFranquista;

            int diceRollRepublicano = Random.Range(1, 7);
            int poderRepublicano = valorSliderRepublicano * diceRollRepublicano;

            if (poderFranquista - poderRepublicano > 0) // gana franquista
            {
                territoriosFranquistas += 1;

                if (poderFranquista - poderRepublicano >= 10000) // victoria aplastante
                {
                    tropasFranquistas -= (int)(0.2f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.75f * valorSliderRepublicano);
                }
                else
                {
                    tropasFranquistas -= (int)(0.4f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.5f * valorSliderRepublicano);
                }
            }
            else
            {
                territoriosRepublicanos += 1; // gana republicano

                if (poderRepublicano - poderFranquista >= 10000) // victoria aplastante
                {
                    tropasFranquistas -= (int)(0.75f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.2f * valorSliderRepublicano);
                }
                else
                {
                    tropasFranquistas -= (int)(0.5f * valorSliderFranquista);
                    tropasRepublicanas -= (int)(0.4f * valorSliderRepublicano);
                }

            }

            andalucia.SetActive(false);
            castilla.SetActive(false);
            galicia.SetActive(false);
            paisvasco.SetActive(false);
            barcelona.SetActive(false);
            valencia.SetActive(false);
            madrid.SetActive(true);
            mapaNormal.SetActive(false);
        }
    }

    public void AjustarTropasFranquistas(float tropas)
    {

    }
}
