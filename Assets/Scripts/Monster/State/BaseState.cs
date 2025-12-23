using UnityEngine;

public abstract class BaseState
{
    protected MonsterController _monsterController;
    
    protected BaseState(MonsterController monsterController)
    {
        _monsterController = monsterController;
    }

    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateExit();
}
