using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Xml.Linq;
using MiniJSON;
using LitJson;
public enum Command
{
    Default,
    ToLeft,
    ToRight
}
public class MapManager : MonoBehaviour {
    public GameObject mapPrefab;
    public GameObject map;
    public MeshRenderer mapBlock;
    public static string[] mapName = new string[3];
    public Command command { get; set;}
    static public int CurrentMapIndex { get; set; }
	// Use this for initialization
	void Start () {
        ReadMapData();
        showMap();
    }
	
	// Update is called once per frame
	void Update () {
        if (command == Command.ToLeft)
            ToTheLeft();
        if (command == Command.ToRight)
            ToTheRight();
        command = Command.Default;
	}
    private void ReadMapData()
    {
        do
        {
            string FileName = "Assets/Data/MapData.json";
            StreamReader reader = File.OpenText(FileName);
            string input = reader.ReadToEnd();
            Dictionary<string, List<Dictionary<string, object>>> jsonObject = JsonMapper.ToObject<Dictionary<string, List<Dictionary<string, object>>>>(input);
            for (int i = 0; i < mapName.Length; i++)
            {
                mapName[i] = jsonObject["map"][i]["name"].ToString();
                Debug.Log(mapName[i]);
            }
            reader.Close();
            reader.Dispose();
        } while (false);

        do
        {
            string FileName = "Assets/Data/Archice.json";
            StreamReader reader = File.OpenText(FileName);
            string input = reader.ReadToEnd();
            Dictionary<string, List<Dictionary<string, object>>> jsonObject = JsonMapper.ToObject<Dictionary<string, List<Dictionary<string, object>>>>(input);
            CurrentMapIndex = int.Parse(jsonObject["Archice"][0]["MapID"].ToString());
            reader.Close();
            reader.Dispose();
        } while (false);
    }
    public void showMap()
    {
        if (map)
        {
            Destroy(map);
            map = null;
        }
        Debug.Log("现在的地图是:");
        Debug.Log(CurrentMapIndex);
        mapPrefab = null;
        //从Resources文件夹加载Prefabs
        //mapPrefab = (GameObject)Resources.Load("map/Prefabs/" + mapName[CurrentMapIndex]);
        
        //从assetbundles文件夹加载Prefabs
        mapPrefab = AssetBundleLoader.LoadAssetBundle("Assets/assetbundles/Map._ab", mapName[CurrentMapIndex]);
        map = Instantiate(mapPrefab);
        //mapBlock = GameObject.FindGameObjectWithTag("MapBlock").GetComponent<MeshRenderer>();
        mapBlock = map.GetComponentInChildren<MeshRenderer>();
        Debug.Log(mapBlock.bounds.size);
        map.transform.position = new Vector3(-(mapBlock.bounds.size.x / 2), mapBlock.bounds.size.y / 2, 0);
        Debug.Log(map.transform.position);
    }
    void ResetCharaterPos(bool left)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            Vector3 size = player.GetComponent<BoxCollider2D>().size;
            if (left)
                player.transform.position = new Vector3(GetMapMsg().x / 2 - size.x, player.transform.position.y, player.transform.position.z);
            else
                player.transform.position = new Vector3(-GetMapMsg().x / 2 + size.x, player.transform.position.y, player.transform.position.z);
        }
    }
    public Vector3 GetMapMsg()
    {
        if (mapBlock != null)
        {
            return mapBlock.bounds.size;
        }
        else
        {
            return Vector3.zero;
        }
    }
    public void ToTheLeft()
    {
        if (CurrentMapIndex - 1 < 0)
            return;
        else
            CurrentMapIndex -= 1;
        showMap();
        ResetCharaterPos(true);
    }
    public void ToTheRight()
    {
        if (CurrentMapIndex + 1 >= mapName.Length)
            return;
        else
            CurrentMapIndex += 1;
        showMap();
        ResetCharaterPos(false);
    }
}
