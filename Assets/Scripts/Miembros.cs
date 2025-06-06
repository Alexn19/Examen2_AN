using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Miembros : MonoBehaviour
{
    private DatosGobierno datos;
    [SerializeField] private int costoContratacion = 50;
    private int numero = 0;
    void Start()
    {
        datos = FindObjectOfType<DatosGobierno>().GetComponent<DatosGobierno>();
    }

    void Update()
    {
        
    }

    public void Contratar()
    {
        if (datos.MostrarPresupuesto() >= costoContratacion)
        {
            numero += 1;
            datos.AumentarMiembros($"Miembro {numero}");
            datos.PerderPresupuesto( costoContratacion );
        }
        else
        {
            Debug.Log("No hay plata - Javier Millei");
        }
    }

    public void Despedir()
    {
        if (datos.Mostrarmiembros() > 0)
        {
            datos.miembros.RemoveAt(datos.miembros.Count - 1);
        }
    }
}
