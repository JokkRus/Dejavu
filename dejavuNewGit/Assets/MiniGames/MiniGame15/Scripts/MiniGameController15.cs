using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MiniGameController15 : MiniGameController {
    [SerializeField]
    GameObject[] LineComputer1;
    [SerializeField]
    GameObject[] LineComputer2;
    [SerializeField]
    GameObject[] LineComputer3;
    [SerializeField]
    GameObject[] LineComputer4;
    [SerializeField]
    GameObject[] LineComputer5;
    [SerializeField]
    GameObject[] LineComputer6;

    [SerializeField]
    GameObject[] AllLines;
    [SerializeField]
    Scrollbar Trafic;
    [SerializeField]
    Image TitleImage;
    [SerializeField]
    Image TutorialImage;
    [SerializeField]
    Text TitleText;
    [SerializeField]
    Text TimeText;
    List<GameObject[]> ArrayLines;
    LinesScript lineScript;
    bool[] lineActive;
    bool tmpLine;
    float mainTrafic;
    float currentTrafic;
    float time;
    bool startGame;
    bool InGame;
    bool win;
    // Use this for initialization

    void Start () {
        lineActive = new bool[]
        {
            true,
            true,
            true,
            true,
            true,
            true
        };
        lineScript = new LinesScript();
        ArrayLines = new List<GameObject[]>();
        ArrayLines.Add(LineComputer1);
        ArrayLines.Add(LineComputer2);
        ArrayLines.Add(LineComputer3);
        ArrayLines.Add(LineComputer4);
        ArrayLines.Add(LineComputer5);
        ArrayLines.Add(LineComputer6);
        mainTrafic = 0.3f;
        time = 60;
    }
	public void StartGame()
    {
        if(!InGame)
        {
            startGame = true;
            InGame = true;
            TitleImage.gameObject.SetActive(false);
            TutorialImage.gameObject.SetActive(false);
        }
        else
        {
            EndGame(win);
        }
    }
	// Update is called once per frame
	void FixedUpdate()
	{

	}
	void Update () {
        if (startGame)
        {
            time -= Time.deltaTime;
            TimeText.text = "Осталось: " + Mathf.FloorToInt(time);
            if (Random.Range(0, 25) == 5)
            {
                TurnLine(Random.Range(0, AllLines.Length));
            }
            CheckLines();
            ChangeTrafic();
            Trafic.size = mainTrafic;
            if(mainTrafic >= 1 )
            {
                win = true;
                StopGame(win);
            }
            if(mainTrafic <=0 || time < 1)
            {
                win = false;
                StopGame(win);
            }
        }
	}
    void TurnLine(int curLine)
    {
        int rot = Random.Range(1, 3);
        if (rot == 1) rot = 90;
        if (rot == 2) rot = 180;
        if (rot == 3) rot = 270;
        AllLines[curLine].transform.Rotate(0, 0, rot);
    }
    public void ClickLine(int num)
    {
        StartCoroutine(TurnClickLine(num));
    }
    IEnumerator TurnClickLine(int num)
    {
        for(int k=0;k<15;k++)
        {
            AllLines[num].transform.Rotate(0, 0, -6);
            yield return new WaitForEndOfFrame();
        }
    }
    void CheckLines()
    {
        for(int i =0; i< ArrayLines.Count;i++)
        {
            tmpLine = true;
            for(int j = 0; j<ArrayLines[i].Length;j++)
            {
                if (Mathf.Round(ArrayLines[i][j].transform.localEulerAngles.z) == lineScript.list[i][0, j] || Mathf.Round(ArrayLines[i][j].transform.localEulerAngles.z) == lineScript.list[i][1, j])
                {
                    ArrayLines[i][j].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                else
                {
                    ArrayLines[i][j].GetComponent<Image>().color = new Color(1, 0, 0, 1);
                    tmpLine = false;
                }
            }
            if (tmpLine == false) lineActive[i] = false;
            else lineActive[i] = true;
        }
    }
    void ChangeTrafic()
    {
        currentTrafic = 0;
        for(int i = 0; i < lineActive.Length;i++)
        {
            if (lineActive[i]) currentTrafic += 0.0002f;
            else currentTrafic += -Difficulty * 0.0001f;
        }
        mainTrafic += currentTrafic;
    }
    void StopGame(bool value)
    {
        startGame = false;
        TitleImage.gameObject.SetActive(true);
        if (value) TitleText.text = "Вы выиграли!";
        else TitleText.text = "Вы проиграли!";
    }
}
