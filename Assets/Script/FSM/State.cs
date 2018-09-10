using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected static string input;
    protected GameObject Player;
    protected PlayerCtl playerCtl;
    protected float chargeTime;
    protected float MaxTime;
    public State(GameObject _Player)
    {
        this.Player = _Player;
        this.playerCtl = _Player.GetComponent<PlayerCtl>();
    }
    public virtual void handleInput(object sender, InputEventArgs e)
    {

    }
	// Use this for initialization
	public virtual void Start () {
		
	}

    // Update is called once per frame
    public virtual void Update () {
		
	}
}
