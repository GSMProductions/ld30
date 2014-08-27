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

    public string[] characters;
    public int unlocked_characters;
    public int current_character;

    public string[] characters_world;

    public Vector2[] characters_position;
    public Vector3[] cameras_position;

    public string[] characters_console;


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
