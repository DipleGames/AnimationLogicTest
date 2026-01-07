using JetBrains.Annotations;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public enum State { Chase, Pattern}

    [SerializeField] private State _curState;
    public PatternExecutor patternExecutor;
    private FSM _fsm;

    public GameObject target;
    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        target = GameObject.Find("PlayerRoot");
        _curState = State.Chase;
        _fsm = new FSM(new ChaseState(this));
    }

    [SerializeField] private float _patternTick = 0f;
    private void Update()
    {
        _patternTick += Time.deltaTime;
        _fsm.UpdateState();
        
        if(_patternTick < 5f)
        {
            if(_curState == State.Chase) return;
            ChangeCurrentState(State.Chase);
        }
        else if(_patternTick < 8f)
        {
            if(_curState == State.Pattern) return;
            ChangeCurrentState(State.Pattern);
        }
        else if(_patternTick > 8f)
        {
            _patternTick = 0f;
        }
    }


    private void ChangeCurrentState(State nextState)
    {
        _curState = nextState;
        switch(_curState)
        {
            case State.Chase:
                _fsm.ChangeState(new ChaseState(this));
                break;
            case State.Pattern:
                _fsm.ChangeState(new PatternState(this));
                break;
        }
    }
}
