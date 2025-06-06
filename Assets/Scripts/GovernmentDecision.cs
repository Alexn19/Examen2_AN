using UnityEngine;

// Gen�rico: GovernmentDecision<T> puede trabajar con cualquier tipo que implemente IDecisionStrategy.
[CreateAssetMenu(fileName = "NewGovernmentDecision", menuName = "Government Sim/Government Decision")]
public class GovernmentDecision : ScriptableObject
{
    public string decisionName;
    public string description;
    public float decisionValue; // Valor asociado a la decisi�n

    // La estrategia se asigna en el Inspector o mediante c�digo
    [SerializeReference] public IDecisionStrategy decisionStrategy;

    public void MakeDecision()
    {
        if (decisionStrategy != null)
        {
            Debug.Log($"Tomando decisi�n: {decisionName}");
            decisionStrategy.ExecuteDecision(decisionValue);
            GameManager.Instance.RecordAction($"Decisi�n tomada: {decisionName}");
        }
        else
        {
            Debug.LogWarning($"La decisi�n '{decisionName}' no tiene una estrategia asignada.");
        }
    }
}