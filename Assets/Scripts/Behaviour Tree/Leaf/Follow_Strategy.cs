using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Strategy : IStrategy
{
    bool isFollow;
    Transform Followed;
    readonly float Movespeed;
    readonly Transform Follower;

    public Follow_Strategy(Transform _followed, Transform _follower, bool _isFollow, float _moveSpeed = 3f)
    {
        this.Followed = _followed;
        this.Follower = _follower;
        this.isFollow = _isFollow;
        this.Movespeed = _moveSpeed;
    }

    public Node.Status Process()
    {
        if (isFollow)
        {
            if (Vector2.Distance(Followed.position, Follower.position) > 10)
            {
                return Node.Status.Failure;
            }
            else if (Vector2.Distance(Followed.position, Follower.position) > 1)
            {
                Follower.transform.position = Vector2.MoveTowards(Follower.position, Followed.position, Movespeed * Time.deltaTime);

                return Node.Status.Running;
            }
            return Node.Status.Success;
        }
        return Node.Status.Failure;
    }

    public void Reset()
    {
        isFollow = false;
    }
}
