using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameController8 : MiniGameController {
    [SerializeField]
    GameObject Letter;
    [SerializeField]
    Text LetterText;
    [SerializeField]
    Text[] BoxLetters;
    [SerializeField]
    Image TitleImage;
    [SerializeField]
    Image TutorialImage;
    [SerializeField]
    Text TitleText;
    [SerializeField]
    Text TimeText;
    [SerializeField]
    GameObject[] Lifes;
    string login;
    int currentLetter;
    char[] letters;
    float time;
    float timeForLetter;
    float timeDifficulty;
    bool startGame;
    int wrongTries;
    bool InGame;
    bool win;
    int arrayletter;
	// Use this for initialization
    public void StartGame()
    {
        if (!InGame)
        {
            letters = ShuffleArray(letters);
            TitleImage.gameObject.SetActive(false);
            Letter.SetActive(true);
            startGame = true;
            InGame = true;
            time = 0;
            timeForLetter = 0;
            LetterText.text = letters[arrayletter].ToString();
        }
        else
        {
            EndGame(win);
        }
    }
	void Start () {
        arrayletter = 0;
        login = "LOGIN";
        currentLetter = 0;
        wrongTries = 3;
        timeDifficulty = 100 - Difficulty * 20;
        Letter.SetActive(false);
        letters = new char[]
            {
                'E',
                'G',
                'I',
                'J',
                'L',
                'N',
                'O',
                'Q',
                'T',
            };
	}
    char[] ShuffleArray(char[] numbers)
    {
        char[] newArray = numbers.Clone() as char[];
        for (int i = 0; i < newArray.Length; i++)
        {
            char tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }
    // Update is called once per frame
    void Update () {
	if(startGame)
        {
            timeDifficulty -= Time.deltaTime;
            TimeText.text = "Осталось: " + Mathf.FloorToInt(timeDifficulty);
            timeForLetter += Time.deltaTime;
            if(timeForLetter > 1.5f/Difficulty)
            {
                arrayletter++;
                if(arrayletter == letters.Length)
                {
                    letters = ShuffleArray(letters);
                    arrayletter = 0;
                }
                LetterText.text = letters[arrayletter].ToString();
                timeForLetter = 0;
                
            }
            if(wrongTries == 0 || timeDifficulty < 1)
            {
                StopGame(false);
            }
            if(currentLetter == 5)
            {
                StopGame(true);
            }
        }
	}
    public void ChooseLetter()
    {
        if(LetterText.text == login[currentLetter].ToString())
        {
            BoxLetters[currentLetter].text = LetterText.text;
            currentLetter++;
        }
        else
        {
            wrongTries--;
            Lifes[wrongTries].SetActive(false);
            StartCoroutine(WrongMoment());
        }
        LetterText.text = letters[Random.Range(0, letters.Length)].ToString();
    }
    IEnumerator WrongMoment()
    {
        while(Letter.GetComponent<Image>().color.g > 0.1f)
        {
            Letter.GetComponent<Image>().color -= new Color(0, 0.05f, 0.05f,0);
            yield return null;
        }
        while (Letter.GetComponent<Image>().color.g < 1f)
        {
            Letter.GetComponent<Image>().color += new Color(0, 0.1f, 0.1f,0);
            yield return null;
        }
    }
    void StopGame(bool value)
    {
        win = value;
        Letter.SetActive(false);
        TitleImage.gameObject.SetActive(true);
        TutorialImage.gameObject.SetActive(false);
        if (value) TitleText.text = "Вы выиграли!";
        else TitleText.text = "Вы проиграли!";
        startGame = false;
    }
}
