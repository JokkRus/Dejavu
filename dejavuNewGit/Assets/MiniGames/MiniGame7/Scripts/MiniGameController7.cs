using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameController7 : MiniGameController
{
    [SerializeField]
    GameObject Claw;
    [SerializeField]
    GameObject[] ufos;
    [SerializeField]
    GameObject[] Baskets;
    [SerializeField]
    GameObject TouchButton;
    [SerializeField]
    Image TitleImage;
    [SerializeField]
    Image TutorialImage;
    [SerializeField]
    Text TitleText;
    [SerializeField]
    Text CountText;
    bool startGame = false;
    int currentBall = 0;
    int[] ufosBasket;
    public int numOfBall = 3;
    int score = 0;
    int needCount;
    bool win;

    // Use this for initialization
    void Start()
    {
        Claw.SetActive(false);
        TouchButton.SetActive(false);
        ufosBasket = new int[ufos.Length * numOfBall];
        for (int i = 0; i < ufos.Length; i++)
        {
            for (int j = i * 3; j < numOfBall + i * 3; j++)
            {
                ufosBasket[j] = i;
            }
        }
        ufosBasket = ShuffleArray(ufosBasket);
        needCount = 6 + Difficulty;
    }
    public void StartGame()
    {
        if (startGame == false)
        {
            CountText.text = "Необходимо набрать: " + needCount;
            TouchButton.SetActive(true);
            TitleImage.gameObject.SetActive(false);
            Claw.SetActive(true);
            Claw.GetComponent<ClawScript>().moveSpeed *= Difficulty;
            TouchButton.SetActive(true);
            Instantiate(ufos[ufosBasket[currentBall]], Claw.transform.position, Quaternion.identity);
            startGame = true;
        }
        else
        {
            EndGame(win);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (currentBall == ufosBasket.Length - 1)
        {
            Invoke("CheckBaskets", 1);
        }
        else StartCoroutine(CreateBall());
    }
    IEnumerator CreateBall()
    {
        currentBall++;
        yield return new WaitForSeconds(1);
        Instantiate(ufos[ufosBasket[currentBall]], Claw.transform.position, Quaternion.identity);

    }
    void CheckBaskets()
    {
        for (int i = 0; i < Baskets.Length; i++)
        {
            score += Baskets[i].GetComponent<BasketScript>().score;
        }
        Claw.SetActive(false);
        TouchButton.SetActive(false);
        TitleImage.gameObject.SetActive(true);
        TutorialImage.gameObject.SetActive(false);
        if (score >= needCount)
        {
            win = true;
            TitleText.text = "Вы выиграли!";
        }
        else
        {
            win = false;
            TitleText.text = "Вы проиграли!";
        }
    }
}
