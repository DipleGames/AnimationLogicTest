using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Clone : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(CloneActionRoutine());   
    }

    void OnDisable()
    {
        StopCoroutine(CloneActionRoutine());
    }

    IEnumerator CloneActionRoutine()
    {
        Debug.Log("패링파티클 등장");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
