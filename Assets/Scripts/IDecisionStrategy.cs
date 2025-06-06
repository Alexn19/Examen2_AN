// Interfaz: Define un contrato para diferentes estrategias de decisión.
// Permite intercambiar algoritmos en tiempo de ejecución.
public interface IDecisionStrategy
{
    void ExecuteDecision(float value);
}