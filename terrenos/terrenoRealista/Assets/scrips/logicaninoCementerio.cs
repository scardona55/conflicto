using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class logicaninoCementerio : MonoBehaviour
{
    public GameObject panelInteraccion;
    public GameObject panelInfo;
    public TextMeshProUGUI textoInfo;
    public bool jugadorCerca;
    private int parteActual;
    private string[] partesTexto = {
        "Emilliano: Hola... me llamo Emilliano. Estoy aquí visitando a mi hermana Luisa. ",
        "Ella era muy pequeña y murió por culpa de una bala perdida",
        "......",
        "Mis padres se fueron a la ciudad a pedir justicia por ella y ahora me estoy quedando con mis abuelos.",
        "Es muy triste estar sin ella......",
        "Extraño mucho a mis padres también, pero ellos dicen que tienen que hacer esto por Luisa..."
    };

    // Start is called before the first frame update
    void Start()
    {
        panelInteraccion.SetActive(false);
        panelInfo.SetActive(false);
        parteActual = 0;
    }

    // Update is called once per frame
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
