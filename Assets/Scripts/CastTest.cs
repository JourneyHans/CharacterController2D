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
    private ContactFilter2D _contactFilter;
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));

        Debug.Log("gameObject layer: " + gameObject.layer);
        Debug.Log("Physics2D.GetLayerCollisionMask(gameObject.layer): " + Physics2D.GetLayerCollisionMask(gameObject.layer));

        _contactFilter.useLayerMask = true;
    }

    void FixedUpdate()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = new Vector3(xInput, yInput, 0f).normalized;
        if (CurrentCastType == CastType.Physics2D)
        {
            Debug.DrawLine(transform.position, transform.position + inputDir * maxSpeed, Color.green);
            int count = Physics2D.Raycast(transform.position, inputDir, _contactFilter, _hits, maxSpeed);
            for (int i = 0; i < count; i++)
            {
                RaycastHit2D hit = _hits[i];
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
