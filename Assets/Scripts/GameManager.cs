using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance { get; private set; }

    [Header("Recursos Iniciales")]
    public float initialMoney = 1000f;
    public float initialPopulationHappiness = 50f;
    public float initialResources = 500f;

    // Dictionary para almacenar los recursos del juego
    // Key: Tipo de Recurso (enum), Value: Cantidad
    private Dictionary<ResourceType, float> gameResources = new Dictionary<ResourceType, float>();

    // Lista de observadores para el patrón Observer
    private List<IGameObserver> observers = new List<IGameObserver>();

    // Pila para un historial de eventos o acciones (ej. para un botón de "deshacer" o resumen de turno)
    private Stack<string> actionHistory = new Stack<string>();

    // Cola para eventos futuros o solicitudes pendientes
    private Queue<string> pendingEvents = new Queue<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeResources();
    }

    private void Start()
    {
        Debug.Log("GameManager inicializado. Recursos: " + GetResource(ResourceType.Money) + " dinero, " + GetResource(ResourceType.PopulationHappiness) + " felicidad, " + GetResource(ResourceType.GeneralResources) + " recursos.");

        // Ejemplo de uso de la pila
        RecordAction("Juego Iniciado");

        // Ejemplo de uso de la cola
        AddPendingEvent("Próximo evento: Elecciones");
    }

    private void InitializeResources()
    {
        gameResources[ResourceType.Money] = initialMoney;
        gameResources[ResourceType.PopulationHappiness] = initialPopulationHappiness;
        gameResources[ResourceType.GeneralResources] = initialResources;
    }

    // Método para agregar o restar recursos
    public void ChangeResource(ResourceType type, float amount)
    {
        // Try/Catch para manejo de errores (ej. intentos de restar más de lo que se tiene)
        try
        {
            if (gameResources.ContainsKey(type))
            {
                gameResources[type] += amount;
                Debug.Log($"Recurso {type}: {gameResources[type]} (cambio: {amount})");

                // Notificar a los observadores sobre el cambio de recursos
                NotifyObservers(type, gameResources[type]);
            }
            else
            {
                throw new KeyNotFoundException($"El tipo de recurso {type} no existe en el diccionario.");
            }
        }
        catch (KeyNotFoundException ex)
        {
            Debug.LogError($"Error al cambiar recurso: {ex.Message}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Un error inesperado ocurrió al cambiar el recurso: {ex.Message}");
        }
    }

    // Método para obtener la cantidad actual de un recurso
    public float GetResource(ResourceType type)
    {
        if (gameResources.ContainsKey(type))
        {
            return gameResources[type];
        }
        Debug.LogWarning($"El recurso {type} no fue encontrado. Retornando 0.");
        return 0f;
    }

    // Métodos para el patrón Observer
    public void AddObserver(IGameObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
            Debug.Log($"{observer.GetType().Name} añadido como observador.");
        }
    }

    public void RemoveObserver(IGameObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
            Debug.Log($"{observer.GetType().Name} removido como observador.");
        }
    }

    private void NotifyObservers(ResourceType type, float value)
    {
        foreach (var observer in observers)
        {
            observer.OnResourceChanged(type, value);
        }
    }

    // Métodos para la Pila (Stack)
    public void RecordAction(string actionDescription)
    {
        actionHistory.Push(actionDescription);
        Debug.Log($"Acción registrada: {actionDescription}. Total de acciones en historial: {actionHistory.Count}");
    }

    public string UndoLastAction()
    {
        if (actionHistory.Count > 0)
        {
            string lastAction = actionHistory.Pop();
            Debug.Log($"Deshaciendo acción: {lastAction}");
            return lastAction;
        }
        Debug.LogWarning("No hay acciones para deshacer.");
        return null;
    }

    // Métodos para la Cola (Queue)
    public void AddPendingEvent(string eventDescription)
    {
        pendingEvents.Enqueue(eventDescription);
        Debug.Log($"Evento pendiente añadido: {eventDescription}. Total de eventos pendientes: {pendingEvents.Count}");
    }

    public string GetNextPendingEvent()
    {
        if (pendingEvents.Count > 0)
        {
            string nextEvent = pendingEvents.Dequeue();
            Debug.Log($"Procesando evento pendiente: {nextEvent}");
            return nextEvent;
        }
        Debug.LogWarning("No hay eventos pendientes.");
        return null;
    }
}

// Interfaz para el patrón Observer
public interface IGameObserver
{
    void OnResourceChanged(ResourceType type, float value);
}

// Enumeración de tipos de recursos
public enum ResourceType
{
    Money,
    PopulationHappiness,
    GeneralResources
}
