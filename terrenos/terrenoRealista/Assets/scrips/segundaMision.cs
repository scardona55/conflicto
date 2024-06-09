using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class segundaMision : MonoBehaviour
{
    public GameObject simboloMision;
    public GameObject panelNPC;
    public GameObject panelNPC2;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject[] objetivos;

    public playerFlores logicaMision;
    private bool misionParaEntregar = false;

    void Start()
    {
        simboloMision.SetActive(true);
        panelNPC.SetActive(false);
        panelNPC2.SetActive(false);

        objetivos = GameObject.FindGameObjectsWithTag("flor");
        foreach (var objetivo in objetivos)
        {
            objetivo.transform.parent.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.X) && !aceptarMision)
        {
            IniciarConversacion();
        }

        if (panelNPC2.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                AceptarMision();
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                RechazarMision();
            }
        }

        if (jugadorCerca && misionParaEntregar && Input.GetKeyDown(KeyCode.X))
        {
            CompletarMision();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            if (!aceptarMision)
            {
                panelNPC.SetActive(true);
            }
            else if (logicaMision.MisionCompletada)
            {
                panelNPC.SetActive(true);
                textoMision.text = "Presiona 'X' para entregar la misión";
                misionParaEntregar = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            panelNPC.SetActive(false);
            panelNPC2.SetActive(false);
            misionParaEntregar = false;
        }
    }

    void IniciarConversacion()
    {
        panelNPC.SetActive(false);
        panelNPC2.SetActive(true);
    }

    void AceptarMision()
    {
        aceptarMision = true;
        simboloMision.SetActive(false);
        panelNPC.SetActive(false);
        panelNPC2.SetActive(false);

        foreach (var objetivo in objetivos)
        {
            objetivo.transform.parent.gameObject.SetActive(true);
        }

        logicaMision.AceptarMision(objetivos.Length);
    }

    void RechazarMision()
    {
        panelNPC2.SetActive(false);
        panelNPC.SetActive(true);
    }

    void CompletarMision()
    {
        logicaMision.CompletarMisionConNPC();
        panelNPC.SetActive(false);
        misionParaEntregar = false;
    }
}
