using UnityEngine;
using System.Collections;

public class WarpPoint : MonoBehaviour {

    public string warpLevel;
    public Vector2 warpTarget;
    public Vector2 cameraWarpTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        GameObject globalState = GameObject.Find("Global State");
        GlobalState state = globalState.GetComponent<GlobalState>();

        state.warpTarget = warpTarget;
        state.cameraWarpTarget = cameraWarpTarget;
        state.warped = false;
        Application.LoadLevel(warpLevel);
    }

}
