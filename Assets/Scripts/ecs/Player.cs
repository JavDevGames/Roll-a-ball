using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Player : MonoBehaviour
{
    public float3 Position;
    
	// Update is called once per frame
	void Update ()
    {
	    Position = transform.position;	
	}
}
