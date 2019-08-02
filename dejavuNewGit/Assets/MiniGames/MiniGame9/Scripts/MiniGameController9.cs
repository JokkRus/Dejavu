using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameController9 : MiniGameController
{
    [SerializeField]
    GameObject camera;
    [SerializeField]
    GameObject Ship;
    [SerializeField]
    GameObject Ground;
    [SerializeField]
    ParticleSystem StarsParticles;
    [SerializeField]
    Image TitleImage;
    [SerializeField]
    Image TutorialImage;
    [SerializeField]
    Text TitleText;
    [SerializeField]
    Text TimeText;
    float time;
    float timeForLvl;
    bool startGame;
    bool InGame;
    bool success;
    // Use this for initialization
    void Start()
    {
        Ship.SetActive(false);
        StarsParticles.gameObject.SetActive(false);
        time = 0;
        timeForLvl = 60;
    }
    public void StartGame()
    {
        if (!InGame)
        {
            TitleImage.gameObject.SetActive(false);
            Ship.SetActive(true);
            Ship.GetComponent<ShipScript>().torq = Difficulty;
            StarsParticles.gameObject.SetActive(true);
            startGame = true;
            InGame = true;
        }
        else
        {
            EndGame(success);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            //camera.transform.localEulerAngles = new Vector3(camera.transform.localEulerAngles.x, camera.transform.localEulerAngles.y, Ship.transform.localEulerAngles.z);
            TimeText.text = "До приземления осталось: " + Mathf.FloorToInt(timeForLvl);
            timeForLvl -= Time.deltaTime;
            if( Mathf.Abs(Ship.transform.localPosition.x) > 4)
            {
                StarsParticles.startSpeed = 0.1f;
                startGame = false;
                Destroy(Ship);
                Invoke("StopGame", 3);
            }
            if (timeForLvl < 0)
            {
                Ship.GetComponent<Rigidbody2D>().gravityScale = 1;
                StartCoroutine(Grounding());
                StarsParticles.startSpeed = 0.1f;
                startGame = false;
                Invoke("StopGame", 3);
            }
        }
    }
    public void TurnShip(int direction)
    {
        if (Ship != null)
        {
            Ship.GetComponent<Rigidbody2D>().AddTorque(3 * Difficulty * direction);
            Ship.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3 * Difficulty * direction, 0));
        }
    }
    void StopGame()
    {
        if (Ship != null) success = true;
        TitleImage.gameObject.SetActive(true);
        TutorialImage.gameObject.SetActive(false);
        if (success) TitleText.text = "Вы выиграли!";
        else TitleText.text = "Вы проиграли!";
    }
    IEnumerator Grounding()
    {
        while (Ground.transform.localPosition.y < -4.5)
        {
            Ground.transform.localPosition += new Vector3(0, 0.02f, 0);
            yield return null;
        }
    }
}
