using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarBox : MonoBehaviour {
    public GameObject bar;//条
    public int MaxValue = 1;
    public int RealValue = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Increase(int value)
    {
        if (value < 0)
        {
            Decrease(-value);
        }
        else
        {
            RealValue += value;
            if (RealValue > MaxValue)//保证RealValue不大于MaxValue
            {
                RealValue = MaxValue;
            }
            LengthUpdate();
        }
    }
    public void Decrease(int value)
    {
        if (value < 0)
        {
            Increase(-value);
        }
        else
        {
            RealValue -= value;
            if (RealValue < 0)//保证RealValue不小于0
            {
                RealValue = MaxValue;
            }
            LengthUpdate();
        }
    }
    public void FillUp()//加满
    {
        RealValue = MaxValue;
        LengthUpdate();
    }
    public void Zero()//归零
    {
        RealValue = 0;
        LengthUpdate();
    }
    public void LengthUpdate()//图形长度更新
    {
        Vector3 vec = bar.transform.localScale;
        MaxValue = MaxValue != 0 ? MaxValue : 1;//保证MaxValue不为零
        bar.transform.localScale = new Vector3((float)RealValue / (float)MaxValue, vec.y, vec.z);
    }
}
