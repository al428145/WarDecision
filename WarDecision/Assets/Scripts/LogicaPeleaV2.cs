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

    var numerosTerritorios = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

    // Galicia: 1, Pais Vasco: 2, Barcelona: 3, Valencia: 4, Andalucia: 5, Castilla: 6, Madrid: 7

    // Start is called before the first frame update
    void Start()
    {
        public int valorRandom = Random.Range(1, 8);
        numerosTerritorios.Remove(valorRandom);
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

    public void Batalla()
    {
        
    }
}
