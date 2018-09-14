using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SideType
{
    Left,
    Right
}

public class MapSide : MonoBehaviour {
    public SideType type;
    public MapManager mapManager;
	// Use this for initialization
	void Start () {
        mapManager = GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            if (type == SideType.Left)
                mapManager.command = Command.ToLeft; 
            else
                mapManager.command = Command.ToRight;

        }
    }
}
