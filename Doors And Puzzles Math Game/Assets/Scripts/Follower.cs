using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower: MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Transform target;
    //[SerializeField] private Transform leftLimit;
    //[SerializeField] private Transform rightLimit;
    //[SerializeField] private Transform downLimit;
    //[SerializeField] private Transform upLimit;

    //private float _xOfsetClamp;
    //private float _yOfsetClamp;
    private Vector3 position;

    //private Vector2[] pathMin;
    //private Vector2[] pathMax;

    private void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y,transform.position.z);
        //_xOfsetClamp = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, Camera.main.nearClipPlane)).x - Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, Camera.main.nearClipPlane)).x;
        //_yOfsetClamp = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.5f, Camera.main.nearClipPlane)).y - Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, Camera.main.nearClipPlane)).y;
    }

    private void FixedUpdate()
    {
        position = new Vector3
        {
            x = target.position.x,
            y = target.position.y,
            z = transform.position.z
        };
        transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);

        //transform.position = new Vector3
        //       (
        //       Mathf.Clamp(transform.position.x, leftLimit.transform.position.x + _xOfsetClamp, rightLimit.transform.position.x - _xOfsetClamp),
        //       Mathf.Clamp(transform.position.y, downLimit.transform.position.y + _yOfsetClamp, upLimit.transform.position.y - _yOfsetClamp),
        //       transform.position.z
        //       );
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawLine(new Vector2(leftLimit.position.x, upLimit.position.y), new Vector2(rightLimit.position.x, upLimit.position.y));
    //    Gizmos.DrawLine(new Vector2(leftLimit.position.x, downLimit.position.y), new Vector2(rightLimit.position.x, downLimit.position.y));
    //    Gizmos.DrawLine(new Vector2(leftLimit.position.x, upLimit.position.y), new Vector2(leftLimit.position.x, downLimit.position.y));
    //    Gizmos.DrawLine(new Vector2(rightLimit.position.x, upLimit.position.y), new Vector2(rightLimit.position.x, downLimit.position.y));
    //}
}
