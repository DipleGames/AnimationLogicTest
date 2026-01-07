using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatternExecutor : MonoBehaviour
{
    public Pattern[] patterns;
    public void Execute(int index)
    {
        StartCoroutine(patterns[index].CastPattern());
    }
}
