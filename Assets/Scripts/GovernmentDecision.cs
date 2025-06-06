using UnityEngine;

// Genérico: GovernmentDecision<T> puede trabajar con cualquier tipo que implemente IDecisionStrategy.
[CreateAssetMenu(fileName = "NewGovernmentDecision", menuName = "Government Sim/Government Decision")]
public class GovernmentDecision : ScriptableObject
{
    public string decisionName;
    public string description;
    public float decisionValue; // Valor asociado a la decisión

    // La estrategia se asigna en el Inspector o mediante código
    [SerializeReference] public IDecisionStrategy decisionStrategy;

    public void MakeDecision()
    {
        if (decisionStrategy != null)
        {
            Debug.Log($"Tomando decisión: {decisionName}");
            decisionStrategy.ExecuteDecision(decisionValue);
            GameManager.Instance.RecordAction($"Decisión tomada: {decisionName}");
        }
        else
        {
            Debug.LogWarning($"La decisión '{decisionName}' no tiene una estrategia asignada.");
        }
    }
}