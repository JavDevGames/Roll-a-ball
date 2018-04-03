using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class PickUps : MonoBehaviour
{
    public float timeToLive;
    public float3 Position;

    private void Start()
    {
        Position = transform.position;   
    }
}
