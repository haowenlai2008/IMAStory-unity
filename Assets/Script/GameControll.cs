﻿using UnityEngine;
using System.IO;
using System.Text;
using System.Xml.Linq;
using MiniJSON;
using System.Collections.Generic;
using LitJson;
using DragonBones;

public class GameControll : MonoBehaviour {
    public GameObject Player;
    public GameObject MapManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ReadMapData()
    {
    }
    void ReadCharacterData()
    {
        //Player = (GameObject)Resources.Load("Character/Prefabs/Villae");
        //Instantiate(Player);
        //Player.transform.position = Vector3.zero;
        //PlayerCtl playerCtl = Player.GetComponent<PlayerCtl>();

        //string FileName = "Assets/Data/Archice.json";
        //StreamReader json = File.OpenText(FileName);
        //string input = json.ReadToEnd();
        //Dictionary<string, List<Dictionary<string, object>>> jsonObject = JsonMapper.ToObject<Dictionary<string, List<Dictionary<string, object>>>>(input);
        //playerCtl.MaxHealth = 1000 + 100 * (int.Parse(jsonObject["Archice"][0]["Level"].ToString()) - 1);
        //playerCtl.MaxExp = 500 + 100 * (int.Parse(jsonObject["Archice"][0]["Level"].ToString()) - 1);
        //playerCtl.Health = int.Parse(jsonObject["Archice"][0]["HP"].ToString());
        //playerCtl.Exp = int.Parse(jsonObject["Archice"][0]["EXP"].ToString());
        //playerCtl.ATK = 100 + 5 * (int.Parse(jsonObject["Archice"][0]["Level"].ToString()) - 1);
    }
}