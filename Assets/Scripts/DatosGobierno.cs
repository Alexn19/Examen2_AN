using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosGobierno : MonoBehaviour
{
    [SerializeField] private int presupuesto;
    public List<string> miembros = new List<string>();
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        
    }

    public int MostrarPresupuesto()
    {
        return presupuesto;
    }

    public void PerderPresupuesto(int perdida)
    {
        presupuesto -= perdida;
    }

    public void AumentarPresupuesto(int aumento)
    {
        presupuesto += aumento;
    }

    public int Mostrarmiembros()
    {
        return miembros.Count;
    }

    public void PerderMiembros(string miembroPerdido)
    {
        miembros.Remove(miembroPerdido);
    }

    public void AumentarMiembros(string nuevoMiembro)
    {
        miembros.Add(nuevoMiembro);
    }
}
