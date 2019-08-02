using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameControllerOne : MiniGameController
{
    bool win;
    [SerializeField]
    Image PreviewImage;
    [SerializeField]
    Button PreviewButton;
    [SerializeField]
    Text PreviewText;
    [SerializeField]
    GameObject PowerButton;
    [SerializeField]
    Scrollbar PowerScroll;
    [SerializeField]
    GameObject BombPrefab;
    [SerializeField]
    GameObject Camera;
    [SerializeField]
    Transform SpawnPoint;
    [SerializeField]
    Scrollbar Bar;
    [SerializeField]
    GameObject Tower;
    [SerializeField]
    Image[] TriesPicture;
    [SerializeField]
    Text TriesText;
    [SerializeField]
    Text TowersText;
    float power = 10;
    float posXTower = 18;
    public static int numberOfTry = 3;
    float velocity = 0;
    public static int success = 0;
    public static int failure = 0;
    bool go = false;
    public float repeatTime = 1;
    float time = 0;
    GameObject Bomb;

    // Use this for initialization
    public void StartGame()
    {
        if (go == false)
        {
            go = true;
            PreviewImage.gameObject.SetActive(false);
            PreviewButton.gameObject.SetActive(false);
            PreviewText.gameObject.SetActive(false);
            TowersText.color = new Color(0, 0, 0, 1);
            for (int i = 0; i < Difficulty; i++)
            {
                Instantiate(Tower, new Vector3(posXTower, 0, -2), Quaternion.identity);
                posXTower -= 4f;
            }
        }
        else
        {
            EndGame(win);
        }
    }
    public void AddPower()
    {
        if (Bar.size < 1)
        {
            Bar.size += 0.01f * Difficulty;
            velocity += power * Difficulty;
            Bomb.GetComponent<BombController>().inFly = true;
        }
    }
    public void StartFly()
    {

        PowerButton.gameObject.SetActive(false);
        Bomb.GetComponent<Rigidbody2D>().gravityScale = 1;
        Bomb.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, velocity));
        numberOfTry--;
        if (numberOfTry == 0) TriesText.color = new Color(1, 1, 1, 0);
        Destroy(TriesPicture[success + failure]);
        //motor.startSize = 1;
    }
    void Start()
    {
        numberOfTry = 3;
        success = 0;
        failure = 0;
        repeatTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Bomb == null)
        {
            if (numberOfTry < Difficulty - success)
            {
                //Проигрыш
                Loose();
            }
            else if (Difficulty - success == 0)
            {
                //Выигрыш
                Win();
            }
            else
            {
                time += Time.deltaTime;
                if (time >= repeatTime && go == true)
                {
                    Bar.size = 0f;
                    velocity = 0f;
                    Bomb = Instantiate(BombPrefab) as GameObject;
                    Bomb.transform.position = SpawnPoint.position;
                    Bomb.GetComponent<BombController>().inFly = false;
                    PowerButton.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            Camera.transform.position = new Vector3(Mathf.Clamp(Bomb.transform.position.x, 0, 21), Mathf.Clamp(Bomb.transform.position.y, 1, 10), -100);
            time = 0;
        }
        TowersText.text = "x" + (Difficulty - success);
        TriesText.text = "x" + numberOfTry;

    }
    void Loose()
    {
        PreviewImage.gameObject.SetActive(true);
        PreviewButton.gameObject.SetActive(true);
        PreviewText.gameObject.SetActive(true);
        PreviewText.fontSize = 200;
        PreviewText.text = "Вы проиграли!";
        win = false;
    }
    void Win()
    {
        PreviewImage.gameObject.SetActive(true);
        PreviewButton.gameObject.SetActive(true);
        PreviewText.gameObject.SetActive(true);
        PreviewImage.color = new Color(0, 1, 1, 1);
        PreviewText.fontSize = 200;
        PreviewText.text = "Вы победили!";
        win = true;
    }
    public static void Success()
    {
        success++;
    }
    public static void Failure()
    {
        failure++;
    }
}
