using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed;       // 移动速度

    private SpriteRenderer _sprite;

    void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        int xInput = (int)Input.GetAxisRaw("Horizontal");
        float xPos = xInput * moveSpeed * Time.deltaTime;
        Vector2 result = new Vector2(xPos, 0);

        // 处理转向
        HandleTurn(xInput);

        transform.Translate(result);
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
