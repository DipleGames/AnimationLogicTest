using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Vector3 _moveForce;

    private Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true; 
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        // 키보드 입력 받기
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = (transform.forward * z + transform.right * x).normalized;
        transform.position += moveDir * _moveSpeed * Time.deltaTime;
    }
}