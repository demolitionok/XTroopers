using UnityEngine;

public abstract class EnemyUnit : MonoBehaviour
{
    public BaseState startState;
    public BaseState currentState;
    private void Start()
    {
        SetState(startState);
    }

    private void SetState(BaseState state)
    {
        currentState = Instantiate(state);
        currentState.enemyUnit = this;
        currentState.Init();
    }
}
