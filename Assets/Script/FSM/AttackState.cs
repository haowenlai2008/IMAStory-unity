using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(GameObject _Player) : base(_Player)
    {

    }
    public override void handleInput(object sender, InputEventArgs e)
    {

    }
    // Use this for initialization
    public override void Start()
    {
        chargeTime = 0.0f;
        MaxTime = 0.63f;
        playerCtl.Attack();//播放动画
        Debug.Log("Attack");
    }

    // Update is called once per frame
    public override void Update()
    {
        if (chargeTime < MaxTime)
            chargeTime += Time.deltaTime * playerCtl.unityArmature.animation.timeScale;
        else
        {
            if (Input.GetKey(KeyCode.X))//按住就继续攻击
            {
                chargeTime = 0.0f;
            }
            else if (Input.GetKey(KeyCode.UpArrow) ||
                   Input.GetKey(KeyCode.DownArrow) ||
                   Input.GetKey(KeyCode.LeftArrow) ||
                   Input.GetKey(KeyCode.RightArrow)
                   )
            {
                chargeTime = 0.0f;
                playerCtl.SetState(StateEnum.Walking);
                playerCtl.GetCurrentState().Start();
            }
            else
            {
                chargeTime = 0.0f;
                playerCtl.SetState(StateEnum.Idling);
                playerCtl.GetCurrentState().Start();
            } 
        }
    }
}
