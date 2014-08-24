using UnityEngine;
using System.Collections;

public class CameraScrolling : MonoBehaviour {

    public int directionX = 0;
    public int directionY = 0;

    public float screenSize = 10.0f;

    public bool cameraIsScrolling = false;

    float oldCameraX = 0.0f;
    float oldCameraY = 0.0f;

    float targetCameraX = 0.0f;
    float targetCameraY = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
    public void StartScrolling(float targetX, float targetY) {

        oldCameraX = Camera.main.transform.position.x;
        oldCameraY = Camera.main.transform.position.y;

        targetCameraX = targetX;
        targetCameraY = targetY;

        cameraIsScrolling = true;
    }

    public void StopScrolling() {
        cameraIsScrolling = false;
    }

    void Update () {
        if (cameraIsScrolling) {
            float cameraX = Camera.main.transform.position.x;
            float cameraY = Camera.main.transform.position.y;
            if ((Mathf.Abs(targetCameraX-cameraX) < 0.1f) && (Mathf.Abs(targetCameraY-cameraY) < 0.1f)) {
                Camera.main.transform.position = new Vector3(targetCameraX, targetCameraY, -10.0f);
                StopScrolling();
            } else {
                Vector3 travel = new Vector3( cameraX+(targetCameraX-oldCameraX) * Time.deltaTime/1.0f,  cameraY+(targetCameraY-oldCameraY) * Time.deltaTime/1.0f, -10.0f);
                Camera.main.transform.position = travel;
            }
        }
    }


}
