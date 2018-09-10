using UnityEngine;
using System.IO;
using System.Text;
using System.Xml.Linq;
using MiniJSON;
using System.Collections.Generic;
using LitJson;
using DragonBones;
public enum StateEnum
{
    Idling = 0,
    Walking = 1,
    Attacking = 2,
    Defending = 3
}
public class PlayerCtl : MonoBehaviour {
    // Use this for initialization
    public float MoveSpeed = 5.0f;
    public UnityArmatureComponent unityArmature;
    public State[] charcter_state = new State[4];
    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int MaxExp { get; set; }
    public int Exp { get; set; }
    public int Level { get; set; }
    public int ATK { get; set; }
    private State CurrentState;
    public BarBox HealthBox;
    public BarBox ExpBox;
    bool isFlip;

    void Awake() {    
        isFlip = false;
        charcter_state[0] = new IdelState(gameObject);//默认状态
        charcter_state[1] = new WalkState(gameObject);//行走状态
        charcter_state[2] = new AttackState(gameObject);//攻击状态
        charcter_state[3] = new DefendState(gameObject);//防御状态
        Debug.Log(charcter_state[0]);
        Debug.Log(charcter_state[1]);
        Debug.Log(charcter_state[2]);
        Debug.Log(charcter_state[3]);
        CurrentState = new State(gameObject);
        CurrentState = charcter_state[0];
        DataInit();
        UiInit();
    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update() {
        WalkCtl();
    }
    void Flip()
    {
        Vector3 theScale = unityArmature.gameObject.transform.localScale;
        theScale.x *= -1;
        unityArmature.gameObject.transform.localScale = theScale;
        isFlip = !isFlip;
    }
    void WalkCtl()
    {
        Vector3 vec = Vector3.zero;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.anyKey)
        {

            if (GetCurrentState() == charcter_state[1])
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    vec.y = 1;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    vec.y = -1;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (!isFlip)
                    {
                        Flip();
                    }
                    vec.x = -1;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (isFlip)
                    {
                        Flip();
                    }
                    vec.x = 1;
                }
                rb.velocity = vec * MoveSpeed;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    public void Idel()
    {
        unityArmature.animation.Play("stay");
    }
    public void Walk()
    {
        unityArmature.animation.Play("Move");
    }
    public void Attack()
    {
        unityArmature.animation.Play("Attack");
    }
    public void Defend()
    {
        unityArmature.animation.Play("BeAttack");
    }
    public void SetState(StateEnum _index)
    {
        if (_index < 0 || (int)_index >= charcter_state.Length)
        {
            Debug.Log("越界");
            return;
        }
        CurrentState = charcter_state[(int)_index];
    }
    
    public State GetCurrentState()
    {
        return CurrentState;
    }
    //读取数据
    public void ReadData()
    {
        string FileName = "Assets/Data/Archice.json";
        StreamReader json = File.OpenText(FileName);
        string input = json.ReadToEnd();
        Dictionary<string, List<Dictionary<string, object>>> jsonObject = JsonMapper.ToObject<Dictionary<string, List<Dictionary<string, object>>>>(input);
        Debug.Log(jsonObject["Archice"][0]["EXP"]);
    }
    //治疗
    public void Cure(int cure)
    {
        if (cure > 0)
            Health = Health + cure > MaxHealth ? Health : Health + cure;
        UIUpdate();
    }
    //受伤
    public void GetDamage(int damage)
    {
        if (damage > 0)
            Health = Health - damage < 0 ? 0 : Health - damage;
        UIUpdate();
    }
    //数据初始化
    private void DataInit()
    {
        string FileName = "Assets/Data/Archice.json";
        StreamReader json = File.OpenText(FileName);
        string input = json.ReadToEnd();
        Dictionary<string, List<Dictionary<string, object>>> jsonObject = JsonMapper.ToObject<Dictionary<string, List<Dictionary<string, object>>>>(input);
        MaxHealth = 1000 + 100 * (int.Parse(jsonObject["Archice"][0]["Level"].ToString()) - 1);
        MaxExp = 500 + 100 * (int.Parse(jsonObject["Archice"][0]["Level"].ToString()) -1);
        Health = int.Parse(jsonObject["Archice"][0]["HP"].ToString());
        Exp = int.Parse(jsonObject["Archice"][0]["EXP"].ToString());
        ATK = 100 + 5 * (int.Parse(jsonObject["Archice"][0]["Level"].ToString()) - 1);
        Armature sword = UnityFactory.factory.BuildArmature("Assets/Texture/Knight/sword_01.png");
        unityArmature.GetComponent<Armature>().GetSlot("sword").childArmature = sword;
    }
    //UI初始化
    private void UiInit()
    {
        HealthBox.MaxValue = MaxHealth;
        HealthBox.RealValue = Health;
        HealthBox.LengthUpdate();
        ExpBox.MaxValue = MaxExp;
        ExpBox.RealValue = Exp;
        ExpBox.LengthUpdate();
    }
    //更新UI
    private void UIUpdate()
    {
        HealthBox.RealValue = Health;
        ExpBox.RealValue = Exp;
        HealthBox.LengthUpdate();
        ExpBox.LengthUpdate();
    }
}
