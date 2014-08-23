using UnityEngine;
using System.Collections;

public class ScreenEdge : MonoBehaviour {

    public int directionX = 0;
    public int directionY = 0;

    public float screenSize = 10.0f;

    bool cameraIsScrolling = false;

    float oldCameraX = 0.0f;
    float oldCameraY = 0.0f;

    float targetCameraX = 0.0f;
    float targetCameraY = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other) {
        if (!Camera.main.GetComponent<CameraScrolling>().cameraIsScrolling) {
            oldCameraX = Camera.main.transform.position.x;
            oldCameraY = Camera.main.transform.position.y;

            targetCameraX = oldCameraX + directionX*screenSize;
            targetCameraY = oldCameraY + directionY*screenSize;

            Camera.main.GetComponent<CameraScrolling>().StartScrolling(targetCameraX, targetCameraY);
        }
    }

}
