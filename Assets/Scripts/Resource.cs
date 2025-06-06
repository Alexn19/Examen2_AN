using UnityEngine;

// Clase abstracta: No se puede instanciar directamente, solo sus subclases.
// Define un contrato básico para todos los recursos.
public abstract class Resource : ScriptableObject
{
    public string resourceName;
    public string description;
    public Sprite icon;

    // Método abstracto: Debe ser implementado por las subclases.
    public abstract void OnResourceGain(float amount);
    public abstract void OnResourceLoss(float amount);
}