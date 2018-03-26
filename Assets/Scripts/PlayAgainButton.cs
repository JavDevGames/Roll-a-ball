using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayAgainButton : MonoBehaviour
{
    public RollaBallController player;
    private Button button;

    private GameObject[] pickups;
    
    public void SetPickUps(GameObject[] levelPickUps)
    {
        pickups = levelPickUps;
    }

    void Start ()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
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
