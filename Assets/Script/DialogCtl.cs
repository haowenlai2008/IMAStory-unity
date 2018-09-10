using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//句子单元
public class SentenceUnit
{
    public string sentence;//要显示的句子
    public Texture2D icon;//图标
    public string funName;//要执行的函数名
    public SentenceUnit(string _sentence)//构造
    {
        sentence = _sentence;
        icon = null;
        funName = null;
    }
    public SentenceUnit(string _sentence, string _funName)//构造
    {
        sentence = _sentence;
        icon = null;
        funName = _funName;
    }
    public SentenceUnit(string _sentence, Texture2D _icon, string _funName)//构造
    {
        sentence = _sentence;
        icon = _icon;
        funName = _funName;
    }
}
public class DialogCtl : MonoBehaviour {
    public Text text;//UI text
    public Image image;//UI图标
    public GameObject box;//对话框实体
    private int count;//计数
    private Texture2D icon;//图标纹理
    private SentenceUnit sentenceUnit;//当前句子单元
    private Queue<SentenceUnit> sentenceQueue;//对话的队列
	// Use this for initialization
	void Start () {
        sentenceQueue = new Queue<SentenceUnit>();
        box.SetActive(false);
        count = 0;
        sentenceUnit = null;
        StartCoroutine(showSentence());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (sentenceQueue.Count != 0)
                    sentenceUnit = sentenceQueue.Dequeue();
                if (sentenceQueue.Count == 0)
                {
                    if (sentenceUnit != null)
                        if (count == sentenceUnit.sentence.Length)
                            hideDialogBox();
                        else
                            text.text = sentenceUnit.sentence;
                }
                count = 0;
            }
            //调用示范
            if (Input.GetKeyDown(KeyCode.A))
            {
                
                pushSentence("233333");
                pushSentence("拜托你很弱欸");
                pushSentence("你现在知道谁是老大了吗");
                showDialogBox();
            }
        }

	}
    public void showDialogBox()//显示对话框，*使用完pushSentence后再调用！
    {
        box.SetActive(true);
        count = 0;
        sentenceUnit = sentenceQueue.Dequeue();
    }
    public void hideDialogBox()
    {
        box.SetActive(false);
    }
    public void pushSentence(string _sentence)
    {
        sentenceQueue.Enqueue(new SentenceUnit(_sentence));
    }
    public void pushSentence(string _sentence, string _funName)
    {
        sentenceQueue.Enqueue(new SentenceUnit(_sentence, _funName));
    }
    public void pushSentence(string _sentence, Texture2D _icon, string _funName)
    {
        sentenceQueue.Enqueue(new SentenceUnit(_sentence, _icon, _funName));
    }
    IEnumerator showSentence()
    {
        if (sentenceUnit != null && count < sentenceUnit.sentence.Length)
        {
            count++;
            if (count == 1)
            {
                
                icon = sentenceUnit.icon;
                if (icon != null)
                    image.sprite = Sprite.Create(icon, new Rect(0, 0, icon.width, icon.height), new Vector2(image.transform.position.x,image.transform.position.y));
                if (sentenceUnit.funName != null)
                    Invoke(sentenceUnit.funName, 0);
            }
            string str = sentenceUnit.sentence.Substring(0, count);
            text.text = str;
        }
        
        yield return new WaitForSeconds(0.02f);
        StartCoroutine(showSentence());
    }
    void DoAfterSpeak()
    {

    }
}
