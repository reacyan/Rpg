using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : Entity
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void SetVelocity(float _xVelocity, float _yVelocity)
    {
        base.SetVelocity(_xVelocity, _yVelocity);

        EntityDirection = new Vector3(_xVelocity, _yVelocity, 0).normalized;
    }

}
