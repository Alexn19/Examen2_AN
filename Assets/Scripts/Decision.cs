using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision : MonoBehaviour, IProbabilidad
{
    private DatosGobierno datos;
    private Miembros miembros;
    [SerializeField] private int probabilidad;

    private void Start()
    {
        datos = FindObjectOfType<DatosGobierno>().GetComponent<DatosGobierno>();
        miembros = FindObjectOfType<Miembros>().GetComponent<Miembros>();
    }

    public void TomarDecision()
    {
        try
        {
            CalcularProbabilidad();
            float numeroAleatorio = Random.Range(0, 100);
            if (numeroAleatorio <= probabilidad)
            {
                Debug.Log("Decision Exitosa");
            }
            else
            {
                Debug.Log("Decision Fallida");
                miembros.Despedir();
                miembros.Despedir();
                miembros.Despedir();
            }

            Debug.Log($"Probabilidad: {probabilidad}% | Número generado: {numeroAleatorio}");
        }
        catch (System.Exception)
        {
            Debug.Log("Error");
            throw;
        }
    }

    public void CalcularProbabilidad()
    {
        int cantidadMiembros = datos.Mostrarmiembros();
        probabilidad = cantidadMiembros * 10;

        probabilidad = Mathf.Clamp(probabilidad, 0, 100);
    }
}
