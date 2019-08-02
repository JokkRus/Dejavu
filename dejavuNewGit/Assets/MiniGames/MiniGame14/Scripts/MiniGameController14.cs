using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameController14 : MiniGameController {
    [SerializeField]
    GameObject SpawnPoint;
    [SerializeField]
    GameObject RightCell;
    [SerializeField]
    GameObject WrongCell;
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
    float time;
    int currentLife;
    float rightCellRepeat;
    float wrongCellRepeat;
    float gravity;
    bool startGame;
    bool InGame;
    bool win;
	// Use this for initialization
	void Start () {
        time = 60;
        currentLife = 2;
        gravity = 0.1f + Difficulty*0.1f;
        rightCellRepeat = 1.5f / Difficulty;
        wrongCellRepeat = 2.6f / Difficulty;
        RightCell.GetComponent<Rigidbody2D>().gravityScale = gravity;
        WrongCell.GetComponent<Rigidbody2D>().gravityScale = gravity;
    }
	public void StartGame()
    {
        if(!InGame)
        {
            TutorialImage.gameObject.SetActive(false);
            TitleImage.gameObject.SetActive(false);
            startGame = true;
            InGame = true;
            InvokeRepeating("MakeRightCell", rightCellRepeat, rightCellRepeat);
            InvokeRepeating("MakeWrongCell", wrongCellRepeat, wrongCellRepeat);
        }
        else
        {
            EndGame(win);
        }
    }
	// Update is called once per frame
	void Update () {
	if(startGame)
        {
            time -= Time.deltaTime;
            TimeText.text = "Осталось: " + Mathf.FloorToInt(time);
            if(currentLife < 0)
            {
                win = false;
                StopGame(win);
            }
            if(time < 1)
            {
                win = true;
                StopGame(win);
            }
        }
	}
    void MakeRightCell()
    {
        float offset = Random.Range(0.5f, 2.5f);
        Instantiate(RightCell, SpawnPoint.transform.position + new Vector3(offset, 0, 0), Quaternion.identity);
        Instantiate(RightCell, SpawnPoint.transform.position + new Vector3(-offset, 0, 0), Quaternion.identity);
    }
    void MakeWrongCell()
    {
        float offset = Random.Range(0.5f, 2.5f);
        int direction = Random.Range(0, 2);
        if(direction == 1)
        {
            Instantiate(WrongCell, SpawnPoint.transform.position + new Vector3(offset, 0, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(WrongCell, SpawnPoint.transform.position + new Vector3(-offset, 0, 0), Quaternion.identity);
        }
    }
    public void ChangeLife()
    {
        Lifes[currentLife].SetActive(false);
        currentLife--;
    }
    void StopGame(bool value)
    {
        CancelInvoke();
        startGame = false;
        TitleImage.gameObject.SetActive(true);
        if (value) TitleText.text = "Вы выиграли!";
        else TitleText.text = "Вы проиграли!";
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (startGame == true && coll.tag == "wrong") ChangeLife();
        Destroy(coll.gameObject);
    }
}
