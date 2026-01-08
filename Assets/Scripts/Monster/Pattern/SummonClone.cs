using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Pattern", menuName = "Pattern/SummonClone")]
public class SummonClone : Pattern
{
    public GameObject clonePrefab;
    private float radius = 10f;
    public override IEnumerator CastPattern()
    {
        Debug.Log("시전 동작");
        
        yield return new WaitForSeconds(1.5f);

        Debug.Log("분신 소환");

        GameObject player = GameObject.FindWithTag("Player");
        Vector2 randomEdge = Random.insideUnitCircle.normalized;
        Vector3 spawnOffset = new Vector3(randomEdge.x * radius, 0, randomEdge.y * radius);
        Vector3 randomPos = player.transform.position + spawnOffset;
        Vector3 dir = (player.transform.position - randomPos).normalized;

        if (player != null)
        {
            Instantiate(clonePrefab, randomPos, Quaternion.LookRotation(dir));
        }
        yield break;
    }
}
