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
        Vector3 velocity = dir.normalized * 2f;
        _monsterController.rb.linearVelocity = new Vector3(velocity.x, _monsterController.rb.linearVelocity.y, velocity.z);

        if (dir.sqrMagnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir);
            _monsterController.rb.MoveRotation(targetRot);
        }
    }

    public override void OnStateExit()
    {
        Debug.Log("추적 상태 탈출");
    }
}
