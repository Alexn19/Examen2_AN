using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;

public class Solicitud : Accion
{
    private DatosGobierno datos;
    [SerializeField] private int gananciaSolicitud;
    private bool desbloqueado = false;

    void Start()
    {
        datos = FindObjectOfType<DatosGobierno>().GetComponent<DatosGobierno>();
    }

    public override void EjecutarSolicitud()
    {
        datos.AumentarPresupuesto(gananciaSolicitud);
        if (datos.MostrarPresupuesto() >= 100 && desbloqueado == false)
        {
            Trophies.Unlock(270086);
            desbloqueado=true;
        }
    }
}
