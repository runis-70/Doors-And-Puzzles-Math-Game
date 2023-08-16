using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : Follower
{
    public bool limitCameraZone;
    public Transform leftCornerLimit;
    public Transform rightCornerLimit;

    private float _xOfsetClamp;
    private float _yOfsetClamp;


    private void Start()
    {
        transform.position = new Vector3(target.position.x + clamp.x, target.position.y + clamp.y, transform.position.z);
        _xOfsetClamp = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, Camera.main.nearClipPlane)).x - Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, Camera.main.nearClipPlane)).x;
        _yOfsetClamp = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.5f, Camera.main.nearClipPlane)).y - Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, Camera.main.nearClipPlane)).y;
    }

    private void FixedUpdate()
    {
        FollowTheTarget(target, speed);
        CheckLimition(leftCornerLimit, rightCornerLimit);
    }

    public void CheckLimition(Transform leftCornerLimit, Transform rightCornerLimit)
    {
        if (leftCornerLimit != null && rightCornerLimit != null)
        {
            transform.position = new Vector3
                   (
                   Mathf.Clamp(transform.position.x, leftCornerLimit.transform.position.x + _xOfsetClamp + clamp.x, rightCornerLimit.transform.position.x - _xOfsetClamp - clamp.x),
                   Mathf.Clamp(transform.position.y, leftCornerLimit.transform.position.y + _yOfsetClamp + clamp.y, rightCornerLimit.transform.position.y - _yOfsetClamp - clamp.y),
                   transform.position.z
                   );
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (leftCornerLimit != null && rightCornerLimit != null)
        {
            Gizmos.DrawLine(new Vector2(leftCornerLimit.position.x, rightCornerLimit.position.y), new Vector2(rightCornerLimit.position.x, rightCornerLimit.position.y));
            Gizmos.DrawLine(new Vector2(leftCornerLimit.position.x, leftCornerLimit.position.y), new Vector2(rightCornerLimit.position.x, leftCornerLimit.position.y));
            Gizmos.DrawLine(new Vector2(leftCornerLimit.position.x, rightCornerLimit.position.y), new Vector2(leftCornerLimit.position.x, leftCornerLimit.position.y));
            Gizmos.DrawLine(new Vector2(rightCornerLimit.position.x, rightCornerLimit.position.y), new Vector2(rightCornerLimit.position.x, leftCornerLimit.position.y));
        }
    }
}
