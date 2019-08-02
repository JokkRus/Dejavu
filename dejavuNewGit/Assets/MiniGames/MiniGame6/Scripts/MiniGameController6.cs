using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameController6 : MiniGameController {
    [SerializeField]
    GameObject[] Asteroids;
    [SerializeField]
    GameObject Sputnik;
    [SerializeField]
    Image TitleImage;
    [SerializeField]
    Image TutorialImage;
    [SerializeField]
    Text TitleText;
    [SerializeField]
    Text TimeText;
    float time = 60;
    bool startGame = false;
    bool InGame = false;
    bool win;
	// Use this for initialization
	void Start () {
        Sputnik.SetActive(false);
	}
 public	void StartGame()
    {
        if (InGame == false)
        {
            startGame = true;
            InGame = true;
            TitleImage.gameObject.SetActive(false);
            Sputnik.SetActive(true);
            InvokeRepeating("CreateAsteroid", 1f, 1f);
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
            if(Sputnik.gameObject == null)
            {
                Invoke("StopGame", 1);
            }
            if(time<= 1)
            {
                StopGame(true);
            }
        }
	}
    void CreateAsteroid()
    {
        GameObject asteroid;
        asteroid = Instantiate(Asteroids[Random.Range(0, 3)], new Vector3(Random.Range(-3f, 3f), 6, 0),Quaternion.identity) as GameObject;
        asteroid.GetComponent<AsteroidScript>().moveSpeed *= Difficulty;
    }
    void StopGame(bool value)
    {
        startGame = false;
        TitleImage.gameObject.SetActive(true);
        TutorialImage.gameObject.SetActive(false);
        win = value;
        if (value) TitleText.text = "Вы выиграли!";
        else TitleText.text = "Вы проиграли!";
    }
    void StopGame()
    {
        startGame = false;
        TitleImage.gameObject.SetActive(true);
        TutorialImage.gameObject.SetActive(false);
        TitleText.text = "Вы проиграли!";
    }
}
