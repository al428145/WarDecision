using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoBoton : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip soundButton;

    public void SoundButton()
    {
        sound clip = soundButton;

        sound.enabled = false;
        sound.enabled = true;
    }
}
