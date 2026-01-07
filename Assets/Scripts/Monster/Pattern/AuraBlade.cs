using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Pattern", menuName = "Pattern/AuraBlade")]
public class AuraBlade : Pattern
{
    public override IEnumerator CastPattern()
    {
        Debug.Log("시전 동작");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("검기 방출");
        yield break;
    }
}
