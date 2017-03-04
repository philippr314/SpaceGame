using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * @author: Philipp Rösner
 * @date: 2017
 */

/*
 * @description Handles the players input preferences; Detects input and invokes the resulting actions
 */

public class PlayerInput : MonoBehaviour {

    public static InputManager instance;

	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = new InputManager();
        else Destroy(this);
	}
	
}

//manaher for keysets
[System.Serializable]
public class InputManager
{
    public InputSet currentSet;
    private InputSet defaultSet;
    private InputSet savedSet;

    public InputManager()
    {
        currentSet = new InputSet();
        defaultSet = new InputSet();

        //TODO..CHANGE WHEN SAVE SYSTEM IS CREATED
        savedSet = null;

        SetDefaultSet();
        if (savedSet == null)
        {
            currentSet = defaultSet;
        }
    }

    private void SetDefaultSet()
    {
        defaultSet.AddKey("Forward", KeyCode.W);
        defaultSet.AddKey("Backward", KeyCode.S);
        defaultSet.AddKey("Left", KeyCode.A);
        defaultSet.AddKey("Right", KeyCode.D);
        defaultSet.AddKey("Action", KeyCode.F);
    }
}

//a set of single keys
[System.Serializable]
public class InputSet
{
    public List<InputKey> inputKeys;

    public InputSet()
    {
        inputKeys = new List<InputKey>();
    }

    public void AddKey(string _name, KeyCode _code)
    {
        inputKeys.Add(new InputKey(_name, _code));
    }

    public void EraseKeys()
    {
        inputKeys = new List<InputKey>();
    }

    //return a keycode for a given name
    public KeyCode FindKeyCode(string name)
    {
        foreach (InputKey key in inputKeys)
        {
            if (key.name == name)
                return key.code;
        }
        return 0;
    }

    //returns if a certain key is pressed; key gets identified by its name
    public bool GetKey(string key)
    {
        return Input.GetKeyDown(FindKeyCode(key));
    }

}

//a single key
[System.Serializable]
public class InputKey
{
    public string name;
    public KeyCode code;
    
    public InputKey(string _name, KeyCode _code)
    {
        name = _name;
        code = _code;
    }
}
