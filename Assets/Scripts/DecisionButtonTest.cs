using UnityEngine;

public class DecisionButtonTest : MonoBehaviour
{
    public GovernmentDecision increaseMoneyDecision;
    public GovernmentDecision decreaseHappinessDecision;

    // M�todos para ser llamados desde la UI o manualmente
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
            GameManager.Instance.RecordAction("Usuario presion� espacio");
            GameManager.Instance.AddPendingEvent("Reuni�n urgente");
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