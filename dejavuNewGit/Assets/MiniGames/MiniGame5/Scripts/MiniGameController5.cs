using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameController5 : MiniGameController {
    [SerializeField]
    Image TitleImage;
    [SerializeField]
    Image TutorialImage;
    [SerializeField]
    Text TitleText;
    [SerializeField]
    GameObject BackGround;
    [SerializeField]
    GameObject Camera;
    [SerializeField]
    GameObject Rocket;
    [SerializeField]
    GameObject cloudPrefab;
    [SerializeField]
    GameObject starPrefab;
    [SerializeField]
    SpriteRenderer moon;
    [SerializeField]
    Rigidbody2D Back;
    float timeForQuest;
    float time = 0;
    bool startGame = false;
    bool InGame = false;
    bool showMoon = false;
    bool win;
    float currentGravity;
	// Use this for initialization
	void Start () {
        Rocket.SetActive(false);
        currentGravity = 0.2f;
    }
	public void StartGame()
    {
        if (InGame == false)
        {
            InGame = true;
            startGame = true;
            TitleImage.gameObject.SetActive(false);
            Rocket.SetActive(true);
            InvokeRepeating("CreateCloud", 2, .5f);
            InvokeRepeating("CreateStar", 40, .2f);
            timeForQuest = 20 + 20 * Difficulty;
            Rocket.GetComponent<RocketScript>().rotateSpeed *= Difficulty;
            Rocket.GetComponent<RocketScript>().turbul *= Difficulty;
            StartCoroutine(ChangeSky());
            Back.isKinematic = false;
        }
        else
        {
            EndGame(win);
        }
    }
	// Update is called once per frame
	void Update () {
        if(startGame == true)
        {
            time += Time.deltaTime;
            Camera.transform.localEulerAngles = new Vector3(Camera.transform.localEulerAngles.x, Camera.transform.localEulerAngles.y, Rocket.transform.localEulerAngles.z  +180);
            currentGravity += Time.deltaTime / 10f;
            if(CheckRocketDeath())
            {
                win = false;
                StopGame(false);
            }
            else if(time >= timeForQuest)
            {
                win = true;
                StopGame(true);
            }
            if (time > 60 && showMoon == false)
            {
                StartCoroutine(ShowMoon());
                showMoon = true;
            }
        }
    }
    void CreateCloud()
    {
        GameObject cloud = Instantiate(cloudPrefab, BackGround.transform.position + new Vector3(Random.Range(-3f, 3f), 10, 0), Quaternion.identity) as GameObject;
        cloud.GetComponent<Rigidbody2D>().gravityScale = currentGravity;
        if (time > 30) cloud.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 1);

    }
    void CreateStar()
    {
        GameObject star = Instantiate(starPrefab, BackGround.transform.position + new Vector3(Random.Range(-3f, 3f), 10, 0), Quaternion.identity) as GameObject;
        star.GetComponent<Rigidbody2D>().gravityScale = currentGravity;
    }
    void StopGame(bool success)
    {
        CancelInvoke();
        startGame = false;
        Rocket.SetActive(false);
        TitleImage.gameObject.SetActive(true);
        TutorialImage.gameObject.SetActive(false);
        if (success) TitleText.text = "Вы выиграли!";
        else TitleText.text = "Вы проиграли!";
    }
    bool CheckRocketDeath()
    {
        if (Rocket.transform.position.x > 5 || Rocket.transform.position.x < -5)
            return true;
        else
            return false;
    }
    IEnumerator ShowMoon()
    {
        while(moon.color.a < 1)
        {
            moon.color += new Color(0, 0, 0, 0.01f);
            yield return null;
        }
    }
    IEnumerator ChangeSky()
    {
        while (BackGround.GetComponent<SpriteRenderer>().color.r >= 0)
        {
            BackGround.GetComponent<SpriteRenderer>().color -= new Color(0.0002f, 0.0002f, 0.00018f, 0);
            yield return null;
        }
    }
}
