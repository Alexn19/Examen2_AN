// Interfaz: Define un contrato para diferentes estrategias de decisi�n.
// Permite intercambiar algoritmos en tiempo de ejecuci�n.
public interface IDecisionStrategy
{
    void ExecuteDecision(float value);
}