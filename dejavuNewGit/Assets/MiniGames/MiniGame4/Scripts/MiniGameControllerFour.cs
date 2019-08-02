using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MiniGameControllerFour : MiniGameController
{
    bool win;
    [SerializeField]
    GameObject[] PuzzleField;
    [SerializeField]
    Sprite[] PuzzleSprites;
    [SerializeField]
    Image[] Diamonds;
    [SerializeField]
    GameObject MainDiamond;
    [SerializeField]
    Image TitleImage;
    [SerializeField]
    Image TutorialImage;
    [SerializeField]
    Text TitleText;
    [SerializeField]
    Button TitleButton;
    [SerializeField]
    Text TimeRemainingText;
    public static int numberOfTries = 0;
    List<int[,]> AllLevels = new List<int[,]>();
    int[,] currentLevel;
    int score = 0;
    float timeRemaining = 5;
    bool startGame = false;
    bool inGame = false;
    bool success = false;
    PuzzleLevelScript puzzleLevel = new PuzzleLevelScript();
    public void StartGame()
    {
        if (!inGame)
        {
            inGame = true;
            startGame = true;
            TitleImage.gameObject.SetActive(false);
            for (int i = 0; i < PuzzleField.Length; i++)
            {
                PuzzleField[i].SetActive(true);
            }
            NextWave();
        }
        else
        {
            EndGame(success);
        }
    }
    void NextWave()
    {
        timeRemaining = 7 * (4 - Difficulty);
        currentLevel = AllLevels[Random.Range(0, AllLevels.Count)];
        for (int i = 0; i < PuzzleField.Length; i++)
        {
            PuzzleField[i].GetComponent<SpriteRenderer>().sprite = PuzzleSprites[currentLevel[0, i]];
            PuzzleField[i].transform.localEulerAngles = new Vector3(0, 0, currentLevel[1, i]);
        }
        MixPuzzle();
    }
    bool CheckLevel()
    {
        for (int i = 0; i < PuzzleField.Length; i++)
        {
            if (Mathf.RoundToInt(PuzzleField[i].transform.localEulerAngles.z) != currentLevel[1, i] && Mathf.RoundToInt(PuzzleField[i].transform.localEulerAngles.z) != currentLevel[2, i] && currentLevel[2, i] != 500)
            {
                return false;
            }
        }
        return true;
    }
    void MixPuzzle()
    {
        for (int i = 0; i < PuzzleField.Length; i++)
        {
            PuzzleField[Random.Range(0, PuzzleField.Length)].transform.Rotate(0, 0, -90);
        }
    }
    void Start()
    {
        for (int i = 0; i < PuzzleField.Length; i++)
        {
            PuzzleField[i].SetActive(false);
        }
        AllLevels.Add(puzzleLevel.lvl_0);
        AllLevels.Add(puzzleLevel.lvl_1);
        AllLevels.Add(puzzleLevel.lvl_2);
        AllLevels.Add(puzzleLevel.lvl_3);
        AllLevels.Add(puzzleLevel.lvl_4);

    }

    void Update()
    {
        if (inGame)
        {
            if (startGame == true)
            {
                if (score == 3)
                {
                    success = true;
                    StopGame(success);
                }
                timeRemaining -= Time.deltaTime;
                TimeRemainingText.text = "Осталось: " + Mathf.FloorToInt(timeRemaining);
                if (timeRemaining <= 1)
                {
                    StopGame(success);
                }
            }
            if (CheckLevel())
            {
                StartCoroutine(GrowDiamond());
                NextWave();
                Diamonds[score].color = new Color(1, 1, 1, 1);
                score++;
            }
        }
    }
    void StopGame(bool value)
    {
        for (int i = 0; i < PuzzleField.Length; i++)
        {
            PuzzleField[i].SetActive(false);
        }
        startGame = false;
        TitleImage.gameObject.SetActive(true);
        TutorialImage.gameObject.SetActive(false);
        if (value == true)
        {
            TitleText.text = "Вы выиграли";
        }
        else
        {
            TitleText.text = "Вы проиграли";
        }
    }
    IEnumerator GrowDiamond()
    {
        Vector3 ChangeScale = MainDiamond.transform.localScale;
        while (MainDiamond.transform.localScale.z < ChangeScale.z * 1.2)
        {
            MainDiamond.transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
            yield return null;
        }
    }
}
