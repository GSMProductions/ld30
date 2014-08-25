using UnityEngine;
using System.Collections;

public class DialogTrigger : MonoBehaviour {

    GlobalState state;
    Dialog dialog;

    public enum TriggerType{GoOutside, CheckFirstGate};

    public TriggerType trigger;


    public string dialogToTrigger;

    // Use this for initialization
    void Start () {
    
    }

    void Awake() {
        state = GameObject.Find("Global State").GetComponent<GlobalState>();
        dialog = Camera.main.GetComponent<Dialog>();
    }
	
	// Update is called once per frame
	void Update () {
	   switch (trigger){
        case TriggerType.GoOutside:
            if (!state.need_to_go_outside) {
                dialogToTrigger = null;
            }
            break;
        case TriggerType.CheckFirstGate:
            if (!state.first_gate_check) {
                dialogToTrigger = "First gate check again";
                state.need_to_go_outside = false;
            }
            break;
       }
	}

    void OnTriggerEnter2D () {
        if (dialogToTrigger != null) {
            dialog.GetTextPhase(dialogToTrigger, 0);
            switch (trigger){
                case TriggerType.CheckFirstGate:
                    state.first_gate_check = false;
                    break;
            }
        }
    }
}
