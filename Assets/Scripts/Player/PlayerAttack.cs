using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttackable
{
    public IEnumerator Attack()
    {
        yield return null;
    }

}
