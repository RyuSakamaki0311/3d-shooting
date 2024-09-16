using System;
using UnityEngine;

public class PlayerRotato : MonoBehaviour
{
    [SerializeField]
    private float _rotatoSpeed;

    private Transform _t;

    private void Awake()
    {
        _t = transform;
    }

    void Update()
    {
        Rotato();
    }

    private void Rotato()
    {
        var mouseInput = Input.GetAxis("Mouse X");
        if (MathF.Abs(mouseInput) > 0.01f)
        {
            var speed = mouseInput * _rotatoSpeed * Time.deltaTime;
            transform.RotateAround(_t.position, Vector3.up, mouseInput);
        }
    }
}
