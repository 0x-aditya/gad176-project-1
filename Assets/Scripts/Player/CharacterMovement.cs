using System;
using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckDistance;
    
    private Vector3 _movement;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        
        Move(horizontal, vertical);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move(float horizontal, float vertical)
    {
        _movement = new Vector3(horizontal, 0, vertical);
        _movement = MathOperations.Normalize(_movement);
        _movement *= speed * Time.deltaTime;
        transform.position += _movement;
    }
    
    private void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            _rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }
}
