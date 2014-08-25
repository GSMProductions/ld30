using UnityEngine;
using System.Collections;

public class GlobalState : MonoBehaviour {

    public bool warped = true;
    public Vector2 warpTarget;
    public Vector2 cameraWarpTarget;


    public bool opening = true;
    public bool need_to_go_outside = true;
    public bool first_time_outside = false;
    public bool first_gate_check = true;

    public GameObject loadingScreen; 

    void OnLevelWasLoaded(int level) {
        FinishLoadingScreen();
    }

    public void LoadingScreen() {
        loadingScreen.active = true;
        GetComponent<AudioListener>().enabled = false;
    }

    public void FinishLoadingScreen() {
        loadingScreen.active = false;
        GetComponent<AudioListener>().enabled = true;        
    }

	// Use this for initialization
	void Start () {
	   DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
