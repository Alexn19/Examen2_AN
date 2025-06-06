using UnityEngine;
using TMPro; // Asegúrate de tener TextMeshPro importado (Window > TextMeshPro > Import TMP Essential Resources)

public class ResourceDisplay : MonoBehaviour, IGameObserver
{
    public ResourceType resourceType;
    public TextMeshProUGUI resourceText;

    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddObserver(this);
            // Actualizar al activar por si ya hay un valor inicial
            resourceText.text = $"{resourceType.ToString()}: {GameManager.Instance.GetResource(resourceType):F0}";
        }
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RemoveObserver(this);
        }
    }

    public void OnResourceChanged(ResourceType type, float value)
    {
        if (type == resourceType)
        {
            resourceText.text = $"{resourceType.ToString()}: {value:F0}";
        }
    }
}