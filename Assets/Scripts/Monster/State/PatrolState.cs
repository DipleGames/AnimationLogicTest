using UnityEngine;

public class PatrolState : BaseState
{
    public PatrolState(MonsterController monsterController) : base (monsterController) { }

    public override void OnStateEnter()
    {
        Debug.Log("순찰 상태 진입");
    }

    public override void OnStateUpdate()
    {
        Debug.Log("순찰 상태 진행 중");
    }

    public override void OnStateExit()
    {
        Debug.Log("순찰 상태 탈출");
    }
}
