using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solicitud : Accion
{
    private DatosGobierno datos;
    [SerializeField] private int gananciaSolicitud;

    void Start()
    {
        datos = FindObjectOfType<DatosGobierno>().GetComponent<DatosGobierno>();
    }

    public override void EjecutarSolicitud()
    {
        datos.AumentarPresupuesto(gananciaSolicitud);
    }
}
