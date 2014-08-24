using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour {

    public GUISkin skin;
    public int defaultFontSize = 40;

    public float textanimation = 0.0f;

    public bool visible = false;
    public int dialog_text = 0;

    private string[] dialogs = new string[1];


    int getFontSize(int defaultSize) {
        return (int) (Mathf.Min(defaultSize * Screen.height/720.0f, defaultSize * Screen.width/1280.0f));
    }

    // Use this for initialization
    void Start () {
        dialogs[0] =  "CHARACTER A:\n"+
                      "This is a test dialog box.\n"+
                      "I wonder if it works?!";
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    void OnGUI() {

        if (visible) {
            GUI.skin = skin;
            GUIStyle labelStyle = skin.GetStyle("label");

            // Scale the font size relative to the default 1280x720 resolution
            labelStyle.fontSize = getFontSize(defaultFontSize);
            
            string[] textlines = new string[5];
            textlines[0] = "*";
            textlines[1] = "*---*";
            textlines[2] = "*------*\n"+
                           "*------*";
            textlines[3] = "*---------*\n"+
                           "|         |\n"+
                           "*---------*";
            textlines[4] = dialogs[dialog_text];

            int index = (int)Mathf.Floor(textanimation);
            Vector2 size = labelStyle.CalcSize(new GUIContent(textlines[index]));


            GUI.Box(new Rect(Screen.width/2-size.x/2, Screen.height/4*3-size.y/2, size.x, size.y), "");
            GUI.Label(new Rect(Screen.width/2-size.x/2, Screen.height/4*3-size.y/2, size.x, size.y),textlines[index]);
        }

    }
}
