using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEventSender : MonoBehaviour {
    public delegate void InputEventHandler(object sender, InputEventArgs e);
    public event InputEventHandler InputTran;
    public PlayerCtl playerCtl;
    InputEventArgs inputArgs = new InputEventArgs(0, "");
    State characterStateActVer;
	// Use this for initialization
	void Start () {
        playerCtl = GetComponent<PlayerCtl>();
        Debug.Log(playerCtl);
        characterStateActVer = new State(gameObject);
        Debug.Log(playerCtl.charcter_state[0]);
        foreach (State state in playerCtl.charcter_state)
        {
            InputTran += new InputEventHandler(state.handleInput);//向所有状态发送事件
        }
        
    }
	void Input_events(InputEventArgs e)
    {
        if (e != null)
        {
            InputTran(this, e);
        }
    }
	// Update is called once per frame
	void Update ()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    inputArgs.input = keyCode;
                    Input_events(inputArgs);
                }
            }
        }
        playerCtl.GetCurrentState().Update();
	}
}
