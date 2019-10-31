using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class MoveToPoint : MonoBehaviour
{
    public float Speed = 4f;

    private float minimunRadius = 0.04f;

    private Collider Collider = null;

    private Rigidbody Rigidbody = null;

    Vector3 Target { get; set; }

    private void Awake()
    {
        Collider = GetComponent<Collider>();

        Rigidbody = GetComponent<Rigidbody>();

        Stop();
    }

    private void FixedUpdate()
    {
        var direction = Target - transform.position;
        if (direction.magnitude < minimunRadius)
        {
            Stop();
        }
        else
        {
            var velocity = Speed * direction.normalized;
            var acceleration = (velocity - Rigidbody.velocity) / Time.fixedDeltaTime;
            var force = Rigidbody.mass * acceleration;
            Debug.Log(force);
            Rigidbody.AddForce(force);
        }
    }

    public void SetTarget(Vector3 point)
    {
        point.y = transform.position.y;
        if ((point - transform.position).magnitude > minimunRadius)
        {
            Target = point;
            Rigidbody.transform.LookAt(Target);
        }
    }

    private void Stop()
    {
        Target = transform.position;
        Rigidbody.velocity = Vector3.zero;
    }
}
