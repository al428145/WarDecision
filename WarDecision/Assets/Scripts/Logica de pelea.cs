using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logicadepelea : MonoBehaviour
{
    public int gold;
    public int goldPlayer1;
    public int goldPlayer2;
    public int troops;
    public int player1Troops;
    public int player2Troops;

    public void SendTroops(int troopsToSend, int player)
    {
        // Verificar si hay suficiente oro para enviar soldados
        float cost = 0.25f * troopsToSend;
        if (gold < cost)
        {
            Debug.Log("No hay suficiente oro para enviar soldados");
            return;
        }

        // Restar oro
        gold -= (int)cost;

        // Generar número aleatorio
        int randomValue = Random.Range(1, 7);

        // Calcular el resultado de la batalla
        int battleResult = randomValue * troopsToSend;

        // Guardar el resultado de la batalla según el jugador
        if (player == 1)
        {
            player1Troops += battleResult;
        }
        else if (player == 2)
        {
            player2Troops += battleResult;
        }

        // Calcular la diferencia de tropas
        int troopsDifference = Mathf.Abs(player1Troops - player2Troops);

        // Decidir quién enviará más soldados
        int winner;
        if (player1Troops > player2Troops)
        {
            winner = 1;
        }
        else
        {
            winner = 2;
        }

        // Aplicar las pérdidas de tropas según la diferencia de tropas
        if (troopsDifference > 10000)
        {
            if (winner == 1)
            {
                player1Troops -= (int)(0.2f * battleResult);
                player2Troops -= (int)(0.75f * battleResult);
            }
            else
            {
                player1Troops -= (int)(0.75f * battleResult);
                player2Troops -= (int)(0.2f * battleResult);
            }
        }
        else
        {
            if (winner == 1)
            {
                player1Troops -= (int)(0.4f * battleResult);
                player2Troops -= (int)(0.5f * battleResult);
            }
            else
            {
                player1Troops -= (int)(0.5f * battleResult);
                player2Troops -= (int)(0.4f * battleResult);
            }
        }

        // Añadir oro al ganador
        if (winner == 1)
        {
            gold += 200;
        }
        else
        {
            gold += 200;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        public int tropasFranquistas = 20000;
        public int tropasRepublicanas = 22000;
        public int oroFranquista = 1500;
        public int oroRepublicano = 1300;
        // Recordamos conversión: 1 soldado cuesta 0.25 de oro

    }

    // Update is called once per frame
    void Update()
    {
        if (tropasFranquistas == 0 || oroFranquista == 0)
        {
            
        }

        if (tropasRepublicanas == 0 || oroRepublicano == 0)
        {

        }
    }
}
