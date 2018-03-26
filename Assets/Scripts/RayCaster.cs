using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public int pickupsWide;
    public int pickupsDeep;

    public GameObject spawnPrefab;
    public GameObject pickUpParent;

    public float offsetY;

    // Use this for initialization
    void Start ()
    {
        float width = 10 * transform.localScale.x;
        float depth = 10 * transform.localScale.z;

        float startPosX = transform.position.x - (0.5f * width);
        float startPosY = transform.position.y;
        float startPosZ = transform.position.z - (0.5f * width);

        int spacingX = (int) width / pickupsWide;
        int spacingZ = (int) depth / pickupsDeep;

        Vector3 rayCastStart = new Vector3();

        RaycastHit hitInfo;

        for (int i = 0; i < pickupsWide; ++i)
        {
            for (int j = 0; j < pickupsDeep; ++j)
            {
                rayCastStart.x = startPosX + (i * spacingX);
                rayCastStart.y = startPosY;
                rayCastStart.z = startPosZ + (j * spacingZ);

                if(Physics.Raycast(rayCastStart, Vector3.down, out hitInfo, 200))
                {
                    GameObject newPickUp = GameObject.Instantiate(spawnPrefab, pickUpParent.transform);
                    newPickUp.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + offsetY, hitInfo.point.z);
                }
            }
        }

        //and hit it
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
