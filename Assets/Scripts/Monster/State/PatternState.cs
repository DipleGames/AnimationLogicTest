using System.Collections;
using UnityEngine;

public class PatternState : BaseState
{
    private bool isExecute = false;
    public PatternState(MonsterController monsterController) : base (monsterController) { }

    public override void OnStateEnter()
    {
        Debug.Log("패턴 상태 진입");
    }

    public override void OnStateUpdate()
    {
        if(!isExecute)
        {
            int ran = Random.Range(0,_monsterController.patternExecutor.patterns.Length);
            _monsterController.patternExecutor.Execute(ran);
            isExecute = true;
        }
    }

    public override void OnStateExit()
    {
        isExecute = false;
        Debug.Log("패턴 상태 탈출");
    }
}
