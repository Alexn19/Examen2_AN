using UnityEngine;

public class DecreaseHappinessStrategy : IDecisionStrategy
{
    public void ExecuteDecision(float value)
    {
        Debug.Log($"Estrategia: Disminuyendo felicidad en {value} unidades.");
        GameManager.Instance.ChangeResource(ResourceType.PopulationHappiness, -value);
    }
}