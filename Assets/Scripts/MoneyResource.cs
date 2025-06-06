using UnityEngine;

[CreateAssetMenu(fileName = "NewMoneyResource", menuName = "Government Sim/Resources/Money Resource")]
public class MoneyResource : Resource
{
    public float valuePerUnit = 1f;

    public override void OnResourceGain(float amount)
    {
        Debug.Log($"Ganadas {amount * valuePerUnit} unidades de dinero.");
        GameManager.Instance.ChangeResource(ResourceType.Money, amount * valuePerUnit);
    }

    public override void OnResourceLoss(float amount)
    {
        Debug.Log($"Perdidas {amount * valuePerUnit} unidades de dinero.");
        GameManager.Instance.ChangeResource(ResourceType.Money, -amount * valuePerUnit);
    }
}