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
    public float jumpSpeed;

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
        float moveVertical = Input.GetKey(KeyCode.W) ? 1.0f : 0.0f;
        moveVertical = Input.GetKey(KeyCode.S) ? -1.0f : moveVertical;

        float jump = Input.GetKey(KeyCode.Space) ? 1.0f : 0.0f;
        jump *= jumpSpeed;
        //jump *= Time.deltaTime;

        Camera cam = Camera.main;

        Vector3 movement = cam.transform.forward * moveVertical;

        movement.y += jump;
         
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
