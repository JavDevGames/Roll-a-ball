using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public PlayAgainButton playAgain;
    // Use this for initialization
	void Start ()
    {
        playAgain.SetPickUps(GameObject.FindGameObjectsWithTag("Pick Up"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
