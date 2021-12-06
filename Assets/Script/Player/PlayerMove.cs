using System.Collections;
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
    public bool inWaterFloor;
    public Transform safePlatform;
    public LayerMask platformLayer;
    bool needCheckerAlive = false;
    public Vector3 offsetPlatform;
    public Vector3 startPosition;
    public int lifes = 3;
    public int startLifes = 3;
    public float restartLevelWait = 1.0f;
    public static Action<int> OnLifeChange;
    public bool inPause;
    void Start()
    {
        needCheckerAlive = false;
        safePlatform = null;
        inWaterFloor = false;
        dead = false;
        moving = false;
        startPosition = transform.position;
        OnLifeChange?.Invoke(startLifes);
        lifes = startLifes;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }
    void PlayerInput()
    {
        if (!moving && !dead && !needCheckerAlive && !inPause)
        {
            if(safePlatform)
            {
                transform.position = safePlatform.position + offsetPlatform;
            }
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
        safePlatform = null;
        float timer = 0.0f;
        moving = true;
        needCheckerAlive = true;
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
        AliveCheck();
    }
    bool CheckNotCollision(Vector2 direction)
    {
        return !(Physics2D.Raycast(transform.position + offsetRaycast, direction, distance, obstacleCollision));
    }
    void AliveCheck()
    {
        if(inWaterFloor && !safePlatform)
        {
            if(!dead)StartCoroutine(RestartForLife());
            dead = true;
        }
        needCheckerAlive = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(inWaterFloor)
        {
            safePlatform = collision.transform;
        }
        if(!inWaterFloor)
        {
            if (!dead) StartCoroutine(RestartForLife());
            dead = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(inWaterFloor && safePlatform)
        {
            safePlatform = null;
        }    
    }
    IEnumerator RestartForLife()
    {
        yield return new WaitForSeconds(restartLevelWait);
        lifes--;
        OnLifeChange?.Invoke(lifes);
        transform.position = startPosition;
        if(lifes > 0)dead = false;
    }
}
