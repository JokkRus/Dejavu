using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MiniGameController12 : MiniGameController {
    [SerializeField]
    Sprite[] Forms;
    [SerializeField]
    Color[] Colors;
    [SerializeField]
    Button[] Elements;
    [SerializeField]
    Text questText;
    [SerializeField]
    Image questImage;
    [SerializeField]
    GameObject[] Stars;
    [SerializeField]
    GameObject[] Lifes;
    [SerializeField]
    Image TitleImage;
    [SerializeField]
    Image TutorialImage;
    [SerializeField]
    Text TitleText;
    [SerializeField]
    Text TimeText;
    [SerializeField]
    GameObject Particle;
    int currentScore;
    int currentLife;
    int[,] currentLevel;
    int whatIsQuest;
    int waveScore;
    bool startGame;
    bool endGame;
    float timeForQuest;
    int waveCount;
    bool win;
    ElementLevelScript elementLevel;
    List<int[,]> AllLevels = new List<int[,]>();
	// Use this for initialization
	void Start () {
        waveScore = 0;
        currentLife = 2;
        waveCount = Difficulty * 4;
        elementLevel = new ElementLevelScript();
        for (int i = 0; i< Elements.Length;i++)
        {
           Elements[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < Stars.Length; i++)
        {
            Stars[i].SetActive(false);
        }
        AllLevels.Add(elementLevel.lvl0);
        AllLevels.Add(elementLevel.lvl1);
        AllLevels.Add(elementLevel.lvl2);
        AllLevels.Add(elementLevel.lvl3);
        AllLevels.Add(elementLevel.lvl4);
        AllLevels.Add(elementLevel.lvl5);

    }
    public void StartGame()
    {
        if(!endGame)
        {
            timeForQuest = 13 - Difficulty * 3;
            currentScore = 0;
            TitleImage.gameObject.SetActive(false);
            TutorialImage.gameObject.SetActive(false);
            NextWave();
            startGame = true;
        }
        else
        {
            EndGame(win);
        }
    }
	void NextWave()
    {
        currentScore = 0;
        int choice = Random.Range(0, AllLevels.Count);
        whatIsQuest = elementLevel.questlvl[choice];
        currentLevel = AllLevels[choice];
        currentLevel = ShuffleArray(currentLevel);
        questImage.sprite = Forms[currentLevel[0, 9]];
        questImage.color = Colors[currentLevel[1, 9]];
        if (whatIsQuest == 0) questText.text = "Форма:";
        else questText.text = "Цвет:";
        for(int i = 0; i < Stars.Length;i++)
        {
            Stars[i].SetActive(false);
        }
        for (int i = 0; i < Elements.Length; i++)
        {
            Elements[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < Elements.Length; i++)
        {
            Elements[i].GetComponent<Image>().sprite = Forms[currentLevel[0, i]];
            Elements[i].GetComponent<Image>().color = Colors[currentLevel[1, i]];
        }
        questText.gameObject.SetActive(true);
        questImage.gameObject.SetActive(true);
        TimeText.gameObject.SetActive(true);
    }
    public void ChoiceElement(int num)
    {
        if(whatIsQuest == 0)
        {
            if(currentLevel[0,num]!=currentLevel[0,9])
            {
                Instantiate(Particle, Elements[num].transform.position + new Vector3(0,0,-2), Quaternion.identity);
                Elements[num].gameObject.SetActive(false);
                Stars[currentScore].SetActive(true);
                currentScore++;
            }
            else
            {
                currentLife--;
                Lifes[currentLife].SetActive(false);
            }
        }
        else
        {
            if (currentLevel[1, num] != currentLevel[1, 9])
            {
                Instantiate(Particle, Elements[num].transform.position + new Vector3(0, 0, -2), Quaternion.identity);
                Elements[num].gameObject.SetActive(false);
                Stars[currentScore].SetActive(true);
                currentScore++;
            }
            else
            {
                currentLife--;
                Lifes[currentLife].SetActive(false);
            }
        }
    }
	// Update is called once per frame
	void Update () {
        if (startGame)
        {
            timeForQuest -= Time.deltaTime;
            TimeText.text = "Осталось: " + Mathf.FloorToInt(timeForQuest);
            if (currentLife == 0 || timeForQuest < 0.5f)
            {
                End(false);
            }
            if (currentScore == 5)
            {
                waveScore++;
                if (waveScore == waveCount)
                {
                    End(true);
                }
                else
                {
                    NextLevel();
                }
            }
        }
	}
    void NextLevel()
    {
        startGame = false;
        TitleImage.gameObject.SetActive(true);
        TitleText.text = "Вы угадали!";
    }
    void End(bool value)
    {
        win = value;
        startGame = false;
        endGame = true;
        TitleImage.gameObject.SetActive(true);
        if (value) TitleText.text = "Вы выиграли!";
        else TitleText.text = "Вы проиграли!";
    }
    int[,] ShuffleArray(int[,] numbers)
    {
        int[,] newArray = numbers.Clone() as int[,];
        for (int i = 0; i < 9; i++)
        {
            int tmp1 = newArray[0,i];
            int tmp2 = newArray[1, i];
            int r = Random.Range(i, 8);
            newArray[0,i] = newArray[0,r];
            newArray[1, i] = newArray[1, r];
            newArray[0,r] = tmp1;
            newArray[1, r] = tmp2;
        }
        return newArray;
    }
}
