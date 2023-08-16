using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public float speed = 10f;
    public Transform target;
    public Vector2 clamp;

    public void FollowTheTarget(Transform target, float speed)
    {
        if (target != null)
        {
            Vector3 position = new Vector3
            {
                x = target.position.x + clamp.x,
                y = target.position.y + clamp.y,
                z = transform.position.z
            };
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
        }
    }
    public void FollowTheTarget(Transform target, float speed, bool isRight)
    {
        if (target != null)
        {
            if (isRight)
            {
                Vector3 position = new Vector3
                {
                    x = target.position.x - clamp.x,
                    y = target.position.y + clamp.y,
                    z = transform.position.z
                };
                transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
            }
            else
            {
                Vector3 position = new Vector3
                {
                    x = target.position.x + clamp.x,
                    y = target.position.y + clamp.y,
                    z = transform.position.z
                };
                transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
            }
        }
    }
}
