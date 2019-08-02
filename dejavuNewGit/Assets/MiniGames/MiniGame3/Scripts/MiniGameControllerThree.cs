using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameControllerThree : MiniGameController {
    [SerializeField]
    Scrollbar Progress;
    [SerializeField]
    Text TextProgress;
    [SerializeField]
    Button[] Pins;
    [SerializeField]
    Image TitleImage;
    [SerializeField]
    Text TitleText;
    [SerializeField]
    Image TutorialImage;
    int progressState = 0;
    bool ready = false;
    bool endGame = false;
    float time = 0;
    bool win;
	// Use this for initialization
	void Start () {
	for(int i =0; i<Pins.Length;i++)
        {
            Pins[i].GetComponent<PinScript>().enabled = false;
        }
	}

	public void StartGame()
    {
        if (endGame == false)
        {
            TitleImage.gameObject.SetActive(false);
            for (int i = 0; i < Pins.Length; i++)
            {
                Pins[i].GetComponent<PinScript>().enabled = true;
            }
            ready = true;
        }
        else
        {
            EndGame(win);
        }
    }
	// Update is called once per frame
	void Update () {
	if(ready)
        {
            time += Time.deltaTime;
            if (Mathf.FloorToInt(time * 2) == 100)
            {
                win = true;
                StopGame(win);
            }
            if(CheckPins())
            {
                win = false;
                StopGame(win);
            }
            TextProgress.text = Mathf.FloorToInt(time * 2) + "%";
            Progress.size = (time * 2f) / 100f;
        }
	}
    bool CheckPins()
    {
        for (int i = 0; i < Pins.Length; i++)
        {
            if(Pins[i].GetComponent<PinScript>().death == true)
            {
                return true;
            }
        }
        return false;
    }
    void StopGame(bool value)
    {
        TitleImage.gameObject.SetActive(true);
        TutorialImage.gameObject.SetActive(false);
        TitleText.gameObject.transform.localPosition = Vector3.zero;
        if(value) TitleText.text = "Вы выиграли!";
        else TitleText.text = "Вы проиграли!";
        endGame = true;
        ready = false;
    }
}
