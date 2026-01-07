using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    public void Move(float x, float z)
    {
        Vector3 moveDir = (transform.forward * z + transform.right * x).normalized;
        transform.position += moveDir * _moveSpeed * Time.deltaTime;
    }
}