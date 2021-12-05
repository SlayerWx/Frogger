using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float speed = 0.1f;
    public float limitLeft;
    public float limitRight;
    public float limitUp;
    public float limitDown;
    void FixedUpdate()
    {
        Following();
    }
    void Following()
    {
        Vector3 aux = new Vector3(target.position.x, target.position.y, transform.position.z);
        if(limitDown > target.position.y || limitUp < target.position.y)
        {
            aux.y = transform.position.y;
        }
        if (limitLeft > target.position.x || limitRight < target.position.x)
        {
            aux.x = transform.position.x;
        }
        transform.position = Vector3.Lerp(transform.position,aux, speed);
    }
}
