using UnityEngine;

public abstract class BaseState : ScriptableObject
{
    public bool isFinished { get; protected set; }
    [HideInInspector] public EnemyUnit enemyUnit;
    
    public virtual void Init(){ }
    public abstract void Run();

}
