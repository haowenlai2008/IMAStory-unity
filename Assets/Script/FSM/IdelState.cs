using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdelState : State
{
    public IdelState(GameObject _Player) : base(_Player)
    {

    }
    public override void handleInput(object sender, InputEventArgs e)
    {
        if (playerCtl.GetCurrentState() == this)
        {
            switch (e.input)
            {
                case KeyCode.UpArrow:
                    playerCtl.SetState(StateEnum.Walking);
                    break;
                case KeyCode.DownArrow:
                    playerCtl.SetState(StateEnum.Walking);
                    break;
                case KeyCode.LeftArrow:
                    playerCtl.SetState(StateEnum.Walking);
                    break;
                case KeyCode.RightArrow:
                    playerCtl.SetState(StateEnum.Walking);
                    break;
                case KeyCode.X:
                    playerCtl.SetState(StateEnum.Attacking);
                    Debug.Log("Idel to atk");
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
        MaxTime = 0.92f;
        playerCtl.Idel();//播放动画
    }

    // Update is called once per frame
    public override void Update()
    {
        if (chargeTime < MaxTime)
            chargeTime += Time.deltaTime * playerCtl.unityArmature.animation.timeScale;
        else
        {
            chargeTime = 0.0f;
            playerCtl.SetState(StateEnum.Idling);
            playerCtl.GetCurrentState().Start();
        }
    }
}
