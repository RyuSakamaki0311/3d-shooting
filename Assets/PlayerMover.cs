using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private bool _canJumping = true;

    [SerializeField]
    private float _rayStartOffsetLength = 0.95f;

    [SerializeField]
    private float _rayLength = 0.1f;

    [Range(300f, 1000f)]
    [SerializeField]
    private float _moveSpeed = 700f;

    [SerializeField]
    private float _jumpPower = 5f;

    private Camera _camera;
    private Rigidbody _rb;
    private Transform _t;

    private void Awake()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody>();
        _t = transform;
    }

    private void Update()
    {
        Walk();
        Jump();
    }

    /// <summary>
    /// ÉWÉÉÉìÉv
    /// </summary>
    private void Jump()
    {
        if (!_canJumping) return;

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                Debug.Log("Jump");
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            }
        }
    }

    /// <summary>
    /// ï‡Ç≠
    /// </summary>
    private void Walk()
    {
        if (_rb == null) return;

        var v = Input.GetAxisRaw("Vertical");
        var h = Input.GetAxisRaw("Horizontal");
        var dir = v * Vector3.forward + h * Vector3.right;

        if (dir != Vector3.zero)
        {
            dir = _camera.transform.TransformDirection(dir);
            dir.y = 0;

            var velo = dir.normalized * _moveSpeed * Time.deltaTime;
            velo.y = _rb.velocity.y;
            _rb.velocity = velo;
        }
        else
        {
            var velo = Vector3.zero;
            velo.y = _rb.velocity.y;
            _rb.velocity = velo;
        }
    }

    /// <summary>
    /// ê›íuîªíË
    /// </summary>
    private bool IsGrounded()
    {
        var start = transform.position;
        start.y -= _rayStartOffsetLength;
        var end = start;
        end.y -= _rayLength;
        var layerMask = LayerMask.GetMask("Ground");

        return Physics.Linecast(start, end, layerMask);
    }

    private void OnDrawGizmos()
    {
        var start = transform.position;
        start.y -= _rayStartOffsetLength;
        var end = start;
        end.y -= _rayLength;
        Debug.DrawLine(start, end);
    }
}
