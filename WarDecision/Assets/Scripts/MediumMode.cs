using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MediumMode : MonoBehaviour
{
    // Start is called before the first frame update
    public ControllerDificulty controller;



    public void OnClick()
    {
        controller.Dificultad = 1;
        SceneManager.LoadScene(2);
    }
}
