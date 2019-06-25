using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float xSpeed;      // 水平方向速度
    [SerializeField] private float gravity;         // 重力

    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody;

    private Vector2 velocity;       // 速度

    void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 10.0f, 1 << LayerMask.NameToLayer("Collider")))
        {
            string colliderName = Physics2D.Raycast(this.transform.position, Vector2.down, 10.0f, 1 << LayerMask.NameToLayer("Collider")).collider.gameObject.name;
            Debug.Log("Collider " + colliderName + " is under the CubeUp");
        }
        else
        {
            Debug.Log("No collider is under the CubeUp");
        }
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        // 移动前的位置
        Vector2 currentPos = _rigidbody.position;

        // 处理水平方向
        int xInput = (int)Input.GetAxisRaw("Horizontal");
        velocity.x = xInput * xSpeed;

        // 处理垂直方向
        velocity.y = -gravity;

//        Debug.DrawLine(_rigidbody.position, _rigidbody.position + new Vector2(0, -1f) * 1f, Color.blue);
//        RaycastHit2D hit = Physics2D.Raycast(_rigidbody.position, new Vector2(0, -1f), 1f, 1 << LayerMask.NameToLayer("Platform"));
//        if (hit)
//        {
//            Debug.Log("Collider: " + hit.collider.name);
//        }

        // 最终位置
        Vector2 result = velocity * Time.deltaTime + currentPos;

        // 处理转向
        HandleTurn(xInput);

        _rigidbody.MovePosition(result);
//        transform.Translate(result);
    }

    // 处理转向
    private void HandleTurn(int direction)
    {
        if (direction != 0)
        {
            _sprite.flipX = direction < 0;
        }
    }
}
