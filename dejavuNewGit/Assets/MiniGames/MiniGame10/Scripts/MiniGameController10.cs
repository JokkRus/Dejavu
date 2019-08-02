using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameController10 : MiniGameController {
    public static int goneCell;
    [SerializeField]
    GameObject cell;
    [SerializeField]
    Image TitleImage;
    [SerializeField]
    Image TutorialImage;
    [SerializeField]
    Text TitleText;
    [SerializeField]
    Text TimeText;
    [SerializeField]
    Text ScoreText;
    float repeatingCell;
    bool startGame;
    bool InGame;
    float timeRemaining;
    bool win;
	// Use this for initialization
	void Start () {
        goneCell = 0;
        repeatingCell = 3 - Difficulty/2f;
        timeRemaining = 60;
	}
    public void StartGame()
    {
        if (!InGame)
        {
            TitleImage.gameObject.SetActive(false);
            MakeCell();
            InvokeRepeating("MakeCell", repeatingCell, repeatingCell);
            startGame = true;
            InGame = true;
        }
        else
        {
            EndGame(win);
        }
    }
	void MakeCell()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(cell, new Vector3(Random.Range(-2f,2f), Random.Range(-2f, 2f), -1), Quaternion.identity);
        }

    }
	// Update is called once per frame
	void Update () {
        if (startGame)
        {
            timeRemaining -= Time.deltaTime;
            TimeText.text = "Осталось: " + Mathf.FloorToInt(timeRemaining);
            ScoreText.text = goneCell + "/10";
            if (goneCell > 9) End(false);
            if (timeRemaining < 1) End(true);
        }
	}
    void End(bool value)
    {
        win = value;
        CancelInvoke();
        CellScript.isInvoking = false;
        startGame = false;
        TitleImage.gameObject.SetActive(true);
        TutorialImage.gameObject.SetActive(false);
        if (value) TitleText.text = "Вы выиграли!";
        else TitleText.text = "Вы проиграли!";
    }
}
