using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameController11 : MiniGameController {
    [SerializeField]
    GameObject[] Things;
    [SerializeField]
    Image TitleImage;
    [SerializeField]
    Image TutorialImage;
    [SerializeField]
    Text TitleText;
    [SerializeField]
    GameObject[] Lifes;
    [SerializeField]
    Text ScoreText;
    bool startGame;
    bool InGame;
    int currentThing;
    int numOfThing;
    float timeRepeat;
    int[] thingBasket;
    int currentLife;
    int computerNumber;
    bool win;
    // Use this for initialization
    void Start () {
        currentThing = 0;
        computerNumber = 0;
        currentLife = 2;
        numOfThing = 3 * Difficulty;
        timeRepeat = 1.5f / Difficulty;
        thingBasket = new int[Things.Length * numOfThing];
        for (int i = 0; i < Things.Length; i++)
        {
            for (int j = i * numOfThing; j < numOfThing + i * numOfThing; j++)
            {
                thingBasket[j] = i;
            }
        }
        thingBasket = ShuffleArray(thingBasket);
    }
	public void StartGame()
    {
        if(!InGame)
        {
            TitleImage.gameObject.SetActive(false);
            startGame = true;
            InGame = true;
            InvokeRepeating("PushThing", timeRepeat, timeRepeat);
        }
        else
        {
            EndGame(win);
        }
    }
	// Update is called once per frame
	void Update () {
        if (startGame)
        {
            ScoreText.text = computerNumber + "/" + numOfThing;
            if (currentLife < 0) End(false);
            if (currentThing > thingBasket.Length || computerNumber == numOfThing) End(true);
        }
	}
    public void LostLife()
    {
        if (currentLife >= 0)
        {
            Lifes[currentLife].SetActive(false);
            currentLife--;
        }
    }
    void PushThing()
    {
        Instantiate(Things[thingBasket[currentThing]], new Vector3(Random.Range(-2.5f, 2.5f), 6, -3), Quaternion.identity);
        currentThing++;
    }
    void End(bool value)
    {
        win = value;
        TitleImage.gameObject.SetActive(true);
        TutorialImage.gameObject.SetActive(false);
        startGame = false;
        CancelInvoke();
        if (value) TitleText.text = "Вы выиграли!";
        else TitleText.text = "Вы проиграли!";
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Computer")
        {
            computerNumber++;
        }
        else
        {
            LostLife();
        }
        Destroy(coll.gameObject);
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
}
