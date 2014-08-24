using UnityEngine;
using System.Collections;

public class CameraScrolling : MonoBehaviour {

    public int directionX = 0;
    public int directionY = 0;

    public float screenSize = 10.0f;

    public bool cameraIsScrolling = false;

    float oldCameraX = 0.0f;
    float oldCameraY = 0.0f;

    float oldCharacterX = 0.0f;
    float oldCharacterY = 0.0f;

    float targetCameraX = 0.0f;
    float targetCameraY = 0.0f;

    float targetCharacterX = 0.0f;
    float targetCharacterY = 0.0f;

    GlobalState state;
	// Use this for initialization
	void Start () {
	
	}

    void Awake() {
        state = GameObject.Find("Global State").GetComponent<GlobalState>();
    }

    public void StartScrolling(float targetX, float targetY) {

        oldCameraX = Camera.main.transform.position.x;
        oldCameraY = Camera.main.transform.position.y;

        targetCameraX = targetX;
        targetCameraY = targetY;

        GameObject character = GameObject.Find("Character");
        oldCharacterX = character.transform.position.x;
        oldCharacterY = character.transform.position.y;

        if (targetCameraX - oldCameraX > 0) {
            targetCharacterY = oldCharacterY;
            targetCharacterX = oldCharacterX + 1;
        } else if (targetCameraX - oldCameraX < 0) {
            targetCharacterY = oldCharacterY;
            targetCharacterX = oldCharacterX - 1;           
        } else if (targetCameraY - oldCameraY > 0) {
            targetCharacterY = oldCharacterY + 1;
            targetCharacterX = oldCharacterX;
        } else if (targetCameraY - oldCameraY < 0) {
            targetCharacterY = oldCharacterY - 1;
            targetCharacterX = oldCharacterX;
        }

        cameraIsScrolling = true;
        character.GetComponent<TopDownCharacterController>().canMove = false;
    }

    public void StopScrolling() {
        cameraIsScrolling = false;
        GameObject.Find("Character").GetComponent<TopDownCharacterController>().canMove = true;
    }

    void OnLevelWasLoaded(int level) {
        if (!state.warped) {
            GameObject character = GameObject.Find("Character");
            character.transform.position = state.warpTarget;
            Camera.main.transform.position = new Vector3(state.cameraWarpTarget.x, state.cameraWarpTarget.y, -10.0f);
            state.warped = true;
        }
    }

    void Update () {

        if (cameraIsScrolling) {
            GameObject character = GameObject.Find("Character");
            float cameraX = Camera.main.transform.position.x;
            float cameraY = Camera.main.transform.position.y;
            float characterX = character.transform.position.x;
            float characterY = character.transform.position.y;
            if ((Mathf.Abs(targetCameraX-cameraX) < 0.1f) && (Mathf.Abs(targetCameraY-cameraY) < 0.1f)) {
                Camera.main.transform.position = new Vector3(targetCameraX, targetCameraY, -10.0f);
                character.transform.position = new Vector3(targetCharacterX, targetCharacterY, 0.0f);
                StopScrolling();
            } else {
                Vector3 travel = new Vector3( cameraX+(targetCameraX-oldCameraX) * Time.deltaTime/1.0f,  cameraY+(targetCameraY-oldCameraY) * Time.deltaTime/1.0f, -10.0f);
                Camera.main.transform.position = travel;
                Vector3 travelCharacter = new Vector3( characterX+(targetCharacterX-oldCharacterX) * Time.deltaTime/1.0f,  characterY+(targetCharacterY-oldCharacterY) * Time.deltaTime/1.0f, 0.0f);
                character.transform.position = travelCharacter;
            }
        }
    }


}
