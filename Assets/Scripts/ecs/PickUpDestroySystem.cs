using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PickUpDestroySystem : ComponentSystem
{
    struct Data
    {
        public PickUps pickUps;
    }

    protected override void OnUpdate()
    {
        float dt = Time.deltaTime;

        var toDestroy = new List<GameObject>();
        foreach (var entity in GetEntities<Data>())
        {
            var s = entity.pickUps;
            if (s.timeToLive <= 0.0f)
            {
                toDestroy.Add(s.gameObject);
            }
        }

        foreach (var go in toDestroy)
        {
            Object.Destroy(go);
        }
    }
}

