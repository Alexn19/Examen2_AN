using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Indicadores : MonoBehaviour
{
    private DatosGobierno datos;
    [SerializeField] private TextMeshProUGUI textoPresupuesto;
    [SerializeField] private TextMeshProUGUI textoMiembros;
    void Start()
    {
        datos = FindObjectOfType<DatosGobierno>().GetComponent<DatosGobierno>();
    }

    void Update()
    {
        ActualizarMiembros();
    }

    private void ActualizarMiembros()
    {
        textoPresupuesto.text = $"Presupuesto: {datos.MostrarPresupuesto()}";
        textoMiembros.text = $"Miembros: {datos.Mostrarmiembros()}";
    }
}
