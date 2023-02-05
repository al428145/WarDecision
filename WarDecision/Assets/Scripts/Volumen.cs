using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volumen : MonoBehaviour
{

    public AudioMixer audioMixer;
    public void EstablecerVolumen (float volumen)
    {
        audioMixer.SetFloat("volumen", volumen);
    }
}
