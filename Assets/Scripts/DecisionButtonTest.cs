using UnityEngine;

public class DecisionButtonTest : MonoBehaviour
{
    public GovernmentDecision increaseMoneyDecision;
    public GovernmentDecision decreaseHappinessDecision;

    // Métodos para ser llamados desde la UI o manualmente
    public void CallIncreaseMoneyDecision()
    {
        if (increaseMoneyDecision != null)
        {
            increaseMoneyDecision.MakeDecision();
        }
    }

    public void CallDecreaseHappinessDecision()
    {
        if (decreaseHappinessDecision != null)
        {
            decreaseHappinessDecision.MakeDecision();
        }
    }

    // Para probar la pila y la cola
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.RecordAction("Usuario presionó espacio");
            GameManager.Instance.AddPendingEvent("Reunión urgente");
        }
        if (Input.GetKeyDown(KeyCode.U)) // Undo
        {
            GameManager.Instance.UndoLastAction();
        }
        if (Input.GetKeyDown(KeyCode.P)) // Process Pending Event
        {
            GameManager.Instance.GetNextPendingEvent();
        }
    }
}