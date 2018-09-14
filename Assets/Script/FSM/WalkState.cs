using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public WalkState(GameObject _Player) : base(_Player)
    {

    }
    public override void handleInput(object sender, InputEventArgs e)
    {
        if (playerCtl.GetCurrentState() == this)
        {
            switch (e.input)
            {
                case KeyCode.X:
                    playerCtl.SetState(StateEnum.Attacking);
                    break;
                default:
                    break;
            }
            playerCtl.GetCurrentState().Start();
        }
    }
    // Use this for initialization
    public override void Start()
    {
        chargeTime = 0.0f;
        MaxTime = 0.88f;
        playerCtl.Walk();//播放动画
    }

    // Update is called once per frame
    public override void Update()
    {
        if (chargeTime < MaxTime)
            chargeTime += Time.deltaTime * playerCtl.unityArmature.animation.timeScale;
        else
        {
            if (Input.GetKey(KeyCode.UpArrow) ||
                    Input.GetKey(KeyCode.DownArrow) ||
                    Input.GetKey(KeyCode.LeftArrow) ||
                    Input.GetKey(KeyCode.RightArrow)
                    )
            {
                chargeTime = 0.0f;
            }
            else
            {
                chargeTime = 0.0f;
                playerCtl.SetState(0);
                playerCtl.GetCurrentState().Start();
            }
        }
    }
}
