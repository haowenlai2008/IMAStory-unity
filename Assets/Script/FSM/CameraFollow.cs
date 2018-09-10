using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Camera mainCamera;
    private GameObject player;
    private MapManager mapManager;
	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
        mapManager = GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>();
    }
	
	// Update is called once per frame
	void Update () {
        float left = -mapManager.GetMapMsg().x / 2 + mainCamera.orthographicSize * mainCamera.aspect;
        float right = mapManager.GetMapMsg().x / 2 - mainCamera.orthographicSize * mainCamera.aspect;
        float top = mapManager.GetMapMsg().y / 2 - mainCamera.orthographicSize;
        float bottom = -mapManager.GetMapMsg().y / 2 + mainCamera.orthographicSize;
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        x = x > left ? x : left;
        x = x < right ? x : right;
        y = y > bottom ? y : bottom;
        y = y < top ? y : top;
        transform.position = new Vector3(x, y, transform.position.z);
	}
}
