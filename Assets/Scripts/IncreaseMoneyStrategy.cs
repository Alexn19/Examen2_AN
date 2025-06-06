using UnityEngine;

public class IncreaseMoneyStrategy : IDecisionStrategy
{
    public void ExecuteDecision(float value)
    {
        Debug.Log($"Estrategia: Aumentando dinero en {value} unidades.");
        GameManager.Instance.ChangeResource(ResourceType.Money, value);
    }
}