using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidoRama : MonoBehaviour
{
    public AudioSource sonido;

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag =="Player")
        {
            sonido.Play();
        }
    }
}
