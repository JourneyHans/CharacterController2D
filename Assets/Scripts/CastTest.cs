using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CastType
{
    Physics2D,
    RigidBody2D,
}

public class CastTest : MonoBehaviour
{
    public CastType CurrentCastType = CastType.Physics2D;
    public float speed = 1f;
    public float maxSpeed = 5f;

    private Rigidbody2D _rigidBody;
    private RaycastHit2D[] _hits = new RaycastHit2D[16];
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = new Vector3(xInput, yInput, 0f).normalized;
        if (CurrentCastType == CastType.Physics2D)
        {
            Debug.DrawLine(transform.position, transform.position + inputDir * maxSpeed, Color.green);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, inputDir, maxSpeed);
            if (hit)
            {
                Debug.Log("hit something: " + hit.collider.name);
            }
        }
        else if (CurrentCastType == CastType.RigidBody2D)
        {
            Debug.DrawLine(transform.position, transform.position + inputDir * maxSpeed, Color.red);
            int count = _rigidBody.Cast(inputDir, _hits, maxSpeed);
            for (int i = 0; i < count; i++)
            {
                RaycastHit2D hit = _hits[i];
                Debug.Log("hit something: " + hit.collider.name);
            }
        }
    }
}
