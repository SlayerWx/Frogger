﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerMove : MonoBehaviour
{
    public static Action<AnimationState> OnMove;
    private bool moving = false;
    private bool dead = false;
    public float speed = 1.0f;
    public float distance = 1.0f;
    public LayerMask obstacleCollision;
    public Vector3 offsetRaycast = Vector3.zero;
    void Start()
    {
        dead = false;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }
    void PlayerInput()
    {
        if (!moving)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                if (CheckNotCollision(Vector2.left))
                    StartCoroutine(MoveToDirection(Vector3.left, AnimationState.left));
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                if (CheckNotCollision(Vector2.right))
                    StartCoroutine(MoveToDirection(Vector3.right, AnimationState.right));
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                if (CheckNotCollision(Vector2.down))
                    StartCoroutine(MoveToDirection(Vector3.down, AnimationState.back));
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (CheckNotCollision(Vector2.up))
                    StartCoroutine(MoveToDirection(Vector3.up,AnimationState.front));
            }
        }
    }
    IEnumerator MoveToDirection(Vector3 direction, AnimationState newANim)
    {
        float timer = 0.0f;
        moving = true;
        OnMove?.Invoke(newANim);
        Vector3 startPosition = transform.position;
        while (moving)
        {
            yield return null;
            timer += speed * Time.deltaTime;
            if (timer > distance)
            {
                timer = distance;
                moving = false;
            }
            transform.position = Vector2.Lerp(startPosition, startPosition + (direction * distance), timer / distance);
        }
        OnMove?.Invoke(AnimationState.idle);
    }
    bool CheckNotCollision(Vector2 direction)
    {
        return !(Physics2D.Raycast(transform.position + offsetRaycast, direction, distance, obstacleCollision));
    }
}
