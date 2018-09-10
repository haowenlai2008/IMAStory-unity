using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendState : State
{
    public DefendState(GameObject _Player) : base(_Player)
    {

    }
    public override void handleInput(object sender, InputEventArgs e)
    {

    }
    // Use this for initialization
    public override void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {
        if (chargeTime < MaxTime)
            chargeTime += Time.deltaTime * playerCtl.unityArmature.animation.timeScale;
        else
        {
            chargeTime = 0.0f;
            playerCtl.SetState(0);
            playerCtl.GetCurrentState().Start();
        }
    }
}
