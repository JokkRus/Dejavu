using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameControllerTwo : MiniGameController {
    [SerializeField]
    Button[] DnkButtons;
    [SerializeField]
    Text WaveText;
    [SerializeField]
    Text ElementText;
    [SerializeField]
    Image TitleImage;
    [SerializeField]
    Button TitleButton;
    [SerializeField]
    Text TitleText;
    float timeForRemember = 1f;
    int[] dnkNumbers;
    int numberDnk;
    int numberOfTries;
    int numberOfElements;
    int numberWave;
    bool endGame = false;
    bool win;
	// Use this for initialization
	void Start () {
        numberDnk = Difficulty * 3;
        numberOfTries = numberDnk + 1;
        numberWave = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void StartGame()
    {
        if (!endGame)
        {
            TitleImage.gameObject.SetActive(false);
            TitleText.gameObject.SetActive(false);
            NextWave();
            RefreshStats();
        }
        else
        {
            EndGame(win);
        }
    }
    void NextWave()
    {
        numberOfTries = numberOfTries = numberDnk + 1;
        numberOfElements = 0;
        for (int i = 0; i<DnkButtons.Length;i++)
        {
            DnkButtons[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
            DnkButtons[i].enabled = true;
        }
        dnkNumbers = new int[DnkButtons.Length];
        for (int i = 0; i < numberDnk; i++)
        {
            dnkNumbers[i] = 1;
        }
        dnkNumbers = ShuffleArray(dnkNumbers);
        for(int i = 0;i<dnkNumbers.Length;i++)
        {
            if(dnkNumbers[i] == 1)
            {
                StartCoroutine(ShowElement(i));
            }
        }
    }
    public void DnkChoice(int number)
    {
        numberOfTries--;
        if (dnkNumbers[number] == 1)
        {
            DnkButtons[number].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            numberOfElements++;
            RefreshStats();
            DnkButtons[number].enabled = false;
            if (numberOfElements == numberDnk)
            {
                TitleText.text = "Вы угадали!";
                TitleImage.gameObject.SetActive(true);
                
                TitleText.gameObject.SetActive(true);
                numberWave++;
                if(numberWave > 3)
                {
                    TitleButton.gameObject.SetActive(true);
                    TitleText.text = "Вы выиграли!";
                    win = true;
                    endGame = true;
                }
                
            }
        }
        else
        {
            StartCoroutine(WrongElement(number));
        }
        if (numberOfTries< numberDnk - numberOfElements)
        {
            TitleText.text = "Вы проиграли!";
            TitleImage.gameObject.SetActive(true);
            TitleButton.gameObject.SetActive(true);
            TitleText.gameObject.SetActive(true);
            win = false;
            endGame = true;
        }
        
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
    IEnumerator WrongElement(int num)
    {
        while (DnkButtons[num].GetComponent<Image>().color.a < 0.95f)
        {
            DnkButtons[num].GetComponent<Image>().color = new Color(1, 0, 0, DnkButtons[num].GetComponent<Image>().color.a + 0.05f);
			yield return new WaitForFixedUpdate();
        }
        while (DnkButtons[num].GetComponent<Image>().color.a > 0.2f)
        {
            DnkButtons[num].GetComponent<Image>().color = new Color(1, 1, 1, DnkButtons[num].GetComponent<Image>().color.a - 0.02f);
			yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator ShowElement(int num)
    {
        DnkButtons[num].enabled = false;
        while(DnkButtons[num].GetComponent<Image>().color.a < 0.95f)
        {
            DnkButtons[num].GetComponent<Image>().color = new Color(1, 1, 1, DnkButtons[num].GetComponent<Image>().color.a + 0.005f);
			yield return new WaitForFixedUpdate();
        }
        while (DnkButtons[num].GetComponent<Image>().color.a > 0.2f)
        {
            DnkButtons[num].GetComponent<Image>().color = new Color(1, 1, 1, DnkButtons[num].GetComponent<Image>().color.a - 0.05f);
			yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.1f);
        DnkButtons[num].enabled = true;
    }
    void RefreshStats()
    {
        WaveText.text = numberWave + "/3";
        ElementText.text = numberOfElements + "/" + numberDnk;
    }
 
}
