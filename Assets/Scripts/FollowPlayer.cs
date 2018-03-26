using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float distance;
    public Vector3 initialPosition;
    public float sideRotationSpeed;
    public float upRotationSpeed;
    public float maxPitch;
    public float minPitch;
    public GameObject target;

    private static Vector3 DIR_HELPER;
    private static Vector3 POSITION;
    private static Vector3 TARGET_POSITION;

    private Vector3 mCurrentRotation;

    // Use this for initialization
    void Start()
    {
        POSITION = new Vector3();

        mCurrentRotation = new Vector3();

        InitCameraPosition();
    }

    private void InitCameraPosition()
    {
        DIR_HELPER = target.transform.position - this.transform.position;
        DIR_HELPER.Normalize();

        POSITION = target.transform.position;

        POSITION.x += Mathf.Sin(initialPosition.y) * distance;
        POSITION.z += Mathf.Cos(initialPosition.y) * distance;

        POSITION.y += Mathf.Sin(initialPosition.z) * distance;

        this.transform.position = POSITION;
        this.transform.LookAt(target.transform.position);

        mCurrentRotation = initialPosition;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        DIR_HELPER = this.transform.forward;

        POSITION = target.transform.position;

        TARGET_POSITION.x = POSITION.x;
        TARGET_POSITION.y = POSITION.y;
        TARGET_POSITION.z = POSITION.z;

        float verticalValue = Input.GetKey(KeyCode.UpArrow) ? 1.0f : Input.GetKey(KeyCode.DownArrow) ? -1.0f : 0.0f;
        float horizontalValue = Input.GetKey(KeyCode.LeftArrow) ? -1.0f : Input.GetKey(KeyCode.RightArrow) ? 1.0f : 0.0f;

        float targetSideRotation = horizontalValue * sideRotationSpeed * Time.deltaTime;
        float targetUpRotation = verticalValue * upRotationSpeed * Time.deltaTime;

        mCurrentRotation.y += targetSideRotation;
        mCurrentRotation.z += targetUpRotation;

        mCurrentRotation.z = Mathf.Clamp(mCurrentRotation.z, minPitch, maxPitch);

        POSITION.x += Mathf.Sin(mCurrentRotation.y) * distance;
        POSITION.z += Mathf.Cos(mCurrentRotation.y) * distance;

        POSITION.y += Mathf.Sin(mCurrentRotation.z) * distance;

        this.transform.position = POSITION;
        this.transform.LookAt(TARGET_POSITION);
    }
}