using System.Collections;
using UnityEngine;

public enum LocomotionState { Idle, Move }
public enum CombatState { None, InCombat }
public enum AttackState { Basic, Skill, Critical}
public enum ConditionState  { Normal, Hit, Stun, Die }

public class PlayerStateMachine : MonoBehaviour
{
    public static PlayerStateMachine instance;

    public LocomotionState locomotion = LocomotionState.Idle;
    public CombatState combat = CombatState.None;
    public ConditionState Condition = ConditionState.Normal;

    public GameObject playerInstance; 
    private Rigidbody _rb;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        _rb = playerInstance.GetComponent<Rigidbody>();
    }

    void Update()
    {
        SetLocomotion();
    }

    public void SetLocomotion()
    {
        if(_rb.linearVelocity.magnitude > 0.01f)
        {
            locomotion = LocomotionState.Move;
        }
        else
        {
            locomotion = LocomotionState.Idle;
        }
    }
}
 