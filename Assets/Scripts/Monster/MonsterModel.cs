using UnityEngine;

public class MonsterModel : MonoBehaviour
{
    [SerializeField] private float _monsterHP;
    public float MonsterHP
    {
        get => _monsterHP;
        set
        {
            _monsterHP = value;
        }
    }
}
