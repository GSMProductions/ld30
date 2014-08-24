using UnityEngine;
using System.Collections;

public class GlobalState : MonoBehaviour {

    public bool warped = true;
    public Vector2 warpTarget;
    public Vector2 cameraWarpTarget;

	// Use this for initialization
	void Start () {
	   DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
