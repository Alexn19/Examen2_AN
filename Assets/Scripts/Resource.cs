using UnityEngine;

// Clase abstracta: No se puede instanciar directamente, solo sus subclases.
// Define un contrato b�sico para todos los recursos.
public abstract class Resource : ScriptableObject
{
    public string resourceName;
    public string description;
    public Sprite icon;

    // M�todo abstracto: Debe ser implementado por las subclases.
    public abstract void OnResourceGain(float amount);
    public abstract void OnResourceLoss(float amount);
}