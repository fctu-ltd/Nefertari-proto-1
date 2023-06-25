using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class SpawnReactor : StateReactor
{
    MeshRenderer mesh;

    protected override void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        base.Awake();
        React();
    }

    public override void React()
    {
        if (switcher.state)
        {
            mesh.enabled = true;
        }
        else
        {
            mesh.enabled = false;
        }
    }
}
