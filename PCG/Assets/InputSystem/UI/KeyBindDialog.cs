using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindDialog : MonoBehaviour
{
    [SerializeField] InputManager inputManager;

    public GameObject keyItemPrefab;
    public GameObject KeyList;

    string buttonToRebind = null;
    Dictionary<string, Text> buttonLabel;

	// Use this for initialization
	void Start ()
    {

        List<string> buttonsNames = inputManager.GetButtonsNames();
        buttonLabel = new Dictionary<string, Text>();

        for (int i =0; i < buttonsNames.Count; ++i)
        {
            string button;
            button = buttonsNames[i];

           GameObject go = (GameObject)Instantiate(keyItemPrefab);
            go.transform.SetParent(KeyList.transform);
            go.transform.localScale = Vector3.one;


            Text buttonNameTxt = go.transform.Find("ButtonName").GetComponent<Text>();
            buttonNameTxt.text = button;

            Text keyNameTxt = go.transform.Find("Button/KeyName").GetComponent<Text>();
            keyNameTxt.text = inputManager.GetKeyNameFromButton(button);
            buttonLabel[button] = keyNameTxt;


            Button keyBindButton = go.transform.Find("Button").GetComponent<Button>();
            keyBindButton.onClick.AddListener(() => { RebindKey(button); });
        }

    }

    void RebindKey( string buttonName)
    {
        Debug.Log("Key To Rebind: "  + buttonName);

        buttonToRebind = buttonName;
    }	
	// Update is called once per frame
	void Update ()
    {
	    if (buttonToRebind != null)
        {
            if (Input.anyKeyDown)
            {

                foreach ( KeyCode code in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(code))
                    {
                        inputManager.SetNewKey(buttonToRebind, code);
                        buttonLabel[buttonToRebind].text = code.ToString();
                        buttonToRebind = null;
                        break;
                    }
                }
            }
        }

	}
}
