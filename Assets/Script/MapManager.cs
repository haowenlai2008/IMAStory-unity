using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
    public GameObject map;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Vector3 GetMapMsg()
    {
        if (map != null)
        {
            return map.GetComponent<MeshRenderer>().bounds.size;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
