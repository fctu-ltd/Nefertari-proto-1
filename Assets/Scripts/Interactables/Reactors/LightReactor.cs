using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReactor : StateReactor
{
    private new Light light;
    ParticleSystem particle;
    protected override void Awake()
    {
        light = GetComponentInChildren<Light>();
        particle = GetComponentInChildren<ParticleSystem>();
        base.Awake();
        React();
    }

    public override void React()
    {
        if (switcher.state)
        {
            light.enabled = true;
            particle.Play();
        }
        else
        {
            light.enabled = false;
            particle.Pause();
        }
    }
}
