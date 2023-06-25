using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class MoveReactor : StateReactor
{
    public float activeRotX;
    public float activeRotY;
    public float activeRotZ;
    public float inactiveRotX;
    public float inactiveRotY;
    public float inactiveRotZ;


    Transform _transform;

    protected override void Awake()
    {
        _transform = GetComponent<Transform>();
        base.Awake();
        React();
    }

    public override void React()
    {
        if (switcher.state)
        {
            _transform.rotation = _transform.rotation * Quaternion.Euler(activeRotX, activeRotY, activeRotZ);
        }
        else
        {
            _transform.rotation = _transform.rotation * Quaternion.Euler(inactiveRotX, inactiveRotY, inactiveRotZ);
        }
    }
}
