using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollaBallController : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidBody;
    public int count;

    public Text countTextBG;
    public Text countText;

    public Text winText;
    public Text winTextBG;

    public Button resetButton;

    public void Reset()
    {
        count = 0;

        countText.text = count + "";
        countTextBG.text = count + "";

        winText.gameObject.SetActive(false);
        winTextBG.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
         
        rigidBody.AddForce(movement * speed);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            IncreaseCount();
        }
    }

    private void IncreaseCount()
    {
        count++;

        countText.text = count + "";
        countTextBG.text = count + "";

        if (count >= 12)
        {
            winText.gameObject.SetActive(true);
            winTextBG.gameObject.SetActive(true);

            resetButton.gameObject.SetActive(true);
        }
    }

}
