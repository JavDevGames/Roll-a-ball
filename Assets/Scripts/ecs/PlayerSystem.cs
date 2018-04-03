using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSystem : ComponentSystem
{
    struct PlayerData
    {
        public Player player;
    }

    struct PickUpData
    {
        public PickUps pickUps;
    }

    protected override void OnUpdate()
    {
        float dt = Time.deltaTime;

        float minDist = 1.0f;

        ComponentGroupArray<PlayerData> playerData = GetEntities<PlayerData>();

        foreach (var entity in GetEntities<PickUpData>())
        {
            float3 diff = entity.pickUps.Position - playerData[0].player.Position;
            float diffSqr = math.dot(diff, diff);
            
            if(diffSqr < minDist)
            {
                entity.pickUps.timeToLive = 0;
            }
        }
    }
}