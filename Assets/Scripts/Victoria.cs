using System.Collections;
using System.Collections.Generic;
using GameJolt.API;
using System.ComponentModel;
using UnityEngine;

public class Victoria : MonoBehaviour
{
    private DatosGobierno datos;
    void Start()
    {
        datos = FindObjectOfType<DatosGobierno>().GetComponent<DatosGobierno>();
        Scores.Add(datos.Mostrarmiembros(), $"{datos.Mostrarmiembros()} miembros", 1010757, "", (success) =>
        {
        });
        Scores.Add(datos.MostrarPresupuesto(), $"{datos.MostrarPresupuesto()} presupuesto", 1010762, "", (success) =>
        {
        });
    }

}
