using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class logicaNiño1 : MonoBehaviour
{
    public GameObject panelInteraccion;
    public GameObject panelInfo;
    public TextMeshProUGUI textoInfo;
    public bool jugadorCerca;
    private int parteActual;
    private string[] partesTexto = {
        "Carlos: ¡Hola!; es raro ver gente nueva por acá, me llamo Carlos, si preguntas por los demás niños ",
        "lastimosamente se fueron con sus familias por el conflicto, y ahora somos muy pocos los que quedamos en el pueblo.",
        "Además, nuestra escuela fue destruida y no tenemos dónde estudiar; las pocas cosas que los adultos rescataros las verás por ahí tiradas",
        "lastimosamente el profesor del pueblo no es visto desde hace varios días... Extraño a mis amigos"
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
