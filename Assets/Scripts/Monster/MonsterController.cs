using JetBrains.Annotations;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public enum State { Patrol, Chase}

    [SerializeField] private State _curState;
    private FSM _fsm;

    public GameObject target;

    private void Start()
    {
        target = GameObject.Find("PlayerRoot");
        _curState = State.Patrol;
        _fsm = new FSM(new PatrolState(this));
    }

    private void Update()
    {
        switch(_curState)
        {
            case State.Patrol:
                if(IsPlayerInRange()) // 만약 플레이어와 적사이의 거리거 5f보다 멀다면
                {
                    ChangeState(State.Chase);
                }
                break;
            case State.Chase:
                if(!IsPlayerInRange()) // 만약 플레이어와 적사이의 거리거 5f보다 가깝다면
                {
                    ChangeState(State.Patrol);
                }
                break;
        }

        _fsm.UpdateState();
    }

    private void ChangeState(State nextState)
    {
        _curState = nextState;
        switch(_curState)
        {
            case State.Patrol:
                _fsm.ChangeState(new PatrolState(this));
                break;
            case State.Chase:
                _fsm.ChangeState(new ChaseState(this));
                break;
        }
    }

    private bool IsPlayerInRange()
    {
        return Vector3.Distance(target.transform.position, transform.position) < 20f;
    }
}
