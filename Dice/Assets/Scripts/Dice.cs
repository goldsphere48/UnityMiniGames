using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _transform;

    private bool IsAtAir => _transform.position.y > -4;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _rigidbody.maxAngularVelocity = 70;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ApplyRandomForce();
        }
    }

    private float RandomTorque => Random.value >= 0.5f ? 20 : -20;

    private Vector3 RandomTorqueVector3 => new Vector3(RandomTorque, RandomTorque, RandomTorque);

    public void ApplyRandomForce()
    {
        var dx = -10 + Random.value * 20;
        var dy = IsAtAir ? -10 + Random.value * 10 : 10 + Random.value * 10;
        var dz = -10 + Random.value * 20;
        _rigidbody.AddForce(new Vector3(dx, dy, dz), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorqueVector3, ForceMode.Impulse);
    }
}
