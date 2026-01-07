using UnityEngine;
using System.Collections;

public abstract class Pattern : ScriptableObject
{
    public abstract IEnumerator CastPattern(); 
}
