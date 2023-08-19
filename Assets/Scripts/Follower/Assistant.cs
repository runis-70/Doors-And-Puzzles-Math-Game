using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assistant : Follower
{
    public Player player;

    private void FixedUpdate()
    {
        FollowTheTarget(target, speed, player.isRight);
    }
}
