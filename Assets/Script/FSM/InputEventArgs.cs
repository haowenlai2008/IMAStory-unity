using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class InputEventArgs : EventArgs
{
    public KeyCode input;
    public string addition;
    public InputEventArgs(KeyCode _input, string _addition)
    {
        this.input = _input;
        this.addition = _addition;
    }
}
