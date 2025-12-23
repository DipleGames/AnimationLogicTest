using UnityEngine;

public class ChaseState : BaseState
{
    public ChaseState(MonsterController monsterController) : base (monsterController) { }

    public override void OnStateEnter()
    {
        Debug.Log("추적 상태 진입");
    }

    public override void OnStateUpdate()
    {
        Vector3 dir = _monsterController.target.transform.position - _monsterController.transform.position;
        dir.y = 0f;
        _monsterController.transform.position += dir.normalized * 3f * Time.deltaTime;
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        _monsterController.transform.rotation = targetRotation;
    }

    public override void OnStateExit()
    {
        Debug.Log("추적 상태 탈출");
    }
}
