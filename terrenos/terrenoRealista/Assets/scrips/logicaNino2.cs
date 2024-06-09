using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class logicaNino2 : MonoBehaviour
{
    public GameObject panelInteraccion;
    public GameObject panelInfo;
    public TextMeshProUGUI textoInfo;
    public bool jugadorCerca;
    private int parteActual;
    private string[] partesTexto = {
        "Rigo: ¡Hola! Un placer, me llamo Rigo. Últimamente no salgo de casa y no te había visto.",
        "Mis padres no me dejan salir a jugar; tienen miedo de que me pase algo, como a Luisa.",
        "No hay mucho que hacer últimamente... estamos la mayoría del tiempo escondidos.",
        "El alcalde nos dijo que pronto estaría nuestra escuela y que vendrían soldados a cuidarnos",
        "pero... esa promesa ya la ha hecho varias veces. :,,v"
    };

    void Start()
    {
        panelInteraccion.SetActive(false);
        panelInfo.SetActive(false);
        parteActual = 0;
    }

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.X))
        {
            IniciarConversacion();
        }
        
        if (panelInfo.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            ContinuarConversacion();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            panelInteraccion.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            panelInteraccion.SetActive(false);
            panelInfo.SetActive(false);
        }
    }

    void IniciarConversacion()
    {
        panelInteraccion.SetActive(false); // Ocultar el panel de interacción
        panelInfo.SetActive(true); // Mostrar el panel de información
        MostrarSiguienteParte();
    }

    void MostrarSiguienteParte()
    {
        if (parteActual < partesTexto.Length)
        {
            textoInfo.text = partesTexto[parteActual] + "\n<size=75%>Presiona C para continuar</size>";
        }
        else
        {
            FinalizarConversacion();
        }
    }

    void ContinuarConversacion()
    {
        parteActual++;
        MostrarSiguienteParte();
    }

    void FinalizarConversacion()
    {
        panelInfo.SetActive(false); // Ocultar el panel de información
        parteActual = 0; // Reiniciar la parte actual para futuras interacciones
    }
}
