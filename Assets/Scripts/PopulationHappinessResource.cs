using UnityEngine;

[CreateAssetMenu(fileName = "NewHappinessResource", menuName = "Government Sim/Resources/Happiness Resource")]
public class PopulationHappinessResource : Resource
{
    public override void OnResourceGain(float amount)
    {
        Debug.Log($"La felicidad de la poblaci�n aument� en {amount}.");
        GameManager.Instance.ChangeResource(ResourceType.PopulationHappiness, amount);
    }

    public override void OnResourceLoss(float amount)
    {
        Debug.Log($"La felicidad de la poblaci�n disminuy� en {amount}.");
        GameManager.Instance.ChangeResource(ResourceType.PopulationHappiness, -amount);
    }
}