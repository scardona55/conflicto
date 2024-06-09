using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class logicaMisionMadera : MonoBehaviour
{
    public int numDeObjetivos;
    public TextMeshProUGUI textoMision;
    public GameObject panelMision;
    public GameObject objetoParaActivar; // Referencia pública para el objeto a activar

    private bool misionCompletada = false;
    private bool regresarANPC = false;

    public bool MisionCompletada
    {
        get { return misionCompletada; }
    }

    void Start()
    {
        panelMision.SetActive(false);
        if (objetoParaActivar != null)
        {
            objetoParaActivar.SetActive(false); // Asegúrate de que el objeto esté desactivado al inicio
        }
    }

    void Update()
    {
        if (misionCompletada && regresarANPC && Input.GetKeyDown(KeyCode.F))
        {
            FinalizarMision();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "madera")
        {
            Destroy(col.gameObject);  // Asumiendo que la madera es el gameObject principal y no el padre.
            numDeObjetivos--;
            textoMision.text = "Obten los palos para la reconstrucción de la granja\nRestantes: " + numDeObjetivos;

            if (numDeObjetivos <= 0)
            {
                misionCompletada = true;
                regresarANPC = true;
                textoMision.text = "Regresa con Juan y entrega los palos";
            }
        }
    }

    public void AceptarMision(int numObjetivos)
    {
        numDeObjetivos = numObjetivos;
        textoMision.text = "Obten los palos para la reconstrucción de la granja\nRestantes: " + numDeObjetivos;
        panelMision.SetActive(true);
    }

    public void CompletarMisionConNPC()
    {
        textoMision.text = "¡Muchas gracias; ya mismo montare el nuevo establo, has sido de mucha ayuda!\n<size=75%>El panel se cerrará automáticamente en 5 segundos</size>";
        StartCoroutine(CerrarPanelAutomaticamente(5f));

        if (objetoParaActivar != null)
        {
            objetoParaActivar.SetActive(true); // Activar el objeto
        }
    }

    IEnumerator CerrarPanelAutomaticamente(float tiempoEspera)
    {
        yield return new WaitForSeconds(tiempoEspera);
        FinalizarMision();
    }

    void FinalizarMision()
    {
        textoMision.text = "";
        panelMision.SetActive(false);
        misionCompletada = false;
        regresarANPC = false;
    }
}
