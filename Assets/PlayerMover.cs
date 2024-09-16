using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [Range(300f,1000f)]
    [SerializeField]
    private float _moveSpeed;

    private Camera _camera;
    private Rigidbody _rb;

    private void Awake()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Walk();
    }

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
            _rb.velocity = velo;
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }
}
