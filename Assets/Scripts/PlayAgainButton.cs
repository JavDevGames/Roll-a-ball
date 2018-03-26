using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayAgainButton : MonoBehaviour
{
    public RollaBallController player;
    private Button button;

    public GameObject[] pickups;

    // Use this for initialization
    void Start ()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Click()
    {
        player.Reset();

        for(int i = 0; i < pickups.Length; ++i)
        {
            pickups[i].gameObject.SetActive(true);
        }

        this.gameObject.SetActive(false);
    }
}
