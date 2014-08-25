using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Xml;

public class Dialog : MonoBehaviour {

    public GUISkin skin;
    public int defaultFontSize = 40;

    public float textanimation = 0.0f;

    public bool visible = false;
    public int dialog_text = 0;

    private string[] dialogs = new string[1];

    public string[] char_names = new string[3];

    TextAsset xmlFile;

    int textPhase;
    string currentDialog;
    int nextTextPhase;
    string dialogTree;

    GlobalState state;

    int getFontSize(int defaultSize) {
        return (int) (Mathf.Min(defaultSize * Screen.height/720.0f, defaultSize * Screen.width/1280.0f));
    }

    // Use this for initialization
    void Start () {
        dialogs[0] =  "CHARACTER A:\n"+
                      "This is a test dialog box.\n"+
                      "I wonder if it works?!\n"+
                      "          (SPACE to continue)";
    
        xmlFile = (TextAsset) Resources.Load("dialogs");

        state = GameObject.Find("Global State").GetComponent<GlobalState>();
        if (state.opening) {
            GetTextPhase("Opening", 0);
            state.opening = false;
            state.first_time_outside = true;
        } else if (state.first_time_outside) {
            GetTextPhase("First time outside", 0);
            state.first_time_outside = false;
        }
    }
    
    // Update is called once per frame
    void Update () {
        if (!visible)
            return;

        if (Input.GetKeyUp("space"))
            if (nextTextPhase == -1) {
                visible = false;
                GameObject.Find(state.characters[state.current_character]).GetComponent<TopDownCharacterController>().canMove = true;
            } else {
                GetTextPhase(dialogTree, nextTextPhase);
            }

    }

    public void GetTextPhase(string dialog, int phase) {
        try {
            MemoryStream assetStream = new MemoryStream(xmlFile.bytes);
            XmlReader reader = XmlReader.Create(assetStream);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);

            XmlNode dialogNode = doc.DocumentElement.SelectSingleNode("/dialogs/dialog[@name='"+ dialog +"']");
            
            if (dialogNode == null) {
                throw new UnityException("Dialog " + dialog + " cannot be found.");
            }
            if (phase == 0)
                dialogTree = dialog;

            XmlNode phaseNode = dialogNode.SelectSingleNode("phase[@id='" + phase + "']");

            if (dialogNode == null) {
                throw new UnityException("Phase "+ phase +" for dialog " + dialog + " cannot be found.");
            }

            currentDialog = "";

            XmlNode speaker = phaseNode.SelectSingleNode("speaker");
            if (speaker != null) {
                currentDialog += speaker.Attributes["name"].Value + ":\n";
            }

            foreach(XmlNode line in phaseNode.SelectNodes("line")) {
                currentDialog += line.InnerText + "\n";
            }

            XmlNode nextPhaseNode = phaseNode.SelectSingleNode("next");
            if (nextPhaseNode != null){
                nextTextPhase = Convert.ToInt32(nextPhaseNode.Attributes["id"].Value);
                currentDialog += "\n(SPACE to continue)";
            } else {
                nextTextPhase = -1;
                currentDialog += "\n(Space to close)";
            }
            GameObject.Find(state.characters[state.current_character]).GetComponent<TopDownCharacterController>().canMove = false;
            visible = true;
            
        } catch(Exception e) {
            throw e;
        }
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
            Vector2 size = labelStyle.CalcSize(new GUIContent(currentDialog));


            GUI.Box(new Rect(Screen.width/2-size.x/2, Screen.height/4*3-size.y/2, size.x, size.y), "");
            GUI.Label(new Rect(Screen.width/2-size.x/2, Screen.height/4*3-size.y/2, size.x, size.y),currentDialog);
        }

    }
}
