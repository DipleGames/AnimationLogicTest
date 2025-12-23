using UnityEngine;


public class PlayerAnimation : MonoBehaviour
{
    public bool isKeyChange = false;

    void Update()
    {
        switch(PlayerStateMachine.instance.locomotion)
        {
            case LocomotionState.Idle:
                break;
            case LocomotionState.Move:
                break;
        }
    }
}
