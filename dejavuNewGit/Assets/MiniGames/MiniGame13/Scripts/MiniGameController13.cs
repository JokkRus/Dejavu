using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameController13 : MiniGameController {
    [SerializeField]
    Scrollbar Progress;
    [SerializeField]
    Text TimeText;
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
    float time;
    bool win;
    float currentPower;
    float pinPower;
    float currentProgress;
    // Use this for initialization
    void Start() {
        for (int i = 0; i < Pins.Length; i++)
        {
            Pins[i].GetComponent<PinScriptTwo>().enabled = false;
        }
        pinPower = Difficulty * 0.0005f;
        currentProgress = 0.8f;
        time = 60;
    }

    public void StartGame()
    {
        if (endGame == false)
        {
            TitleImage.gameObject.SetActive(false);
            for (int i = 0; i < Pins.Length; i++)
            {
                Pins[i].GetComponent<PinScriptTwo>().enabled = true;
            }
            ready = true;
        }
        else
        {
            EndGame(win);
        }
    }
    // Update is called once per frame
    void Update() {
        if (ready)
        {
            time -= Time.deltaTime;
            TimeText.text = "Осталось: " + Mathf.FloorToInt(time);
            CheckPins();
            Progress.size = currentProgress;
            ChangeColor(currentProgress);
            if (currentProgress > 1 || currentProgress < 0)
            {
                win = false;
                StopGame(false);
            }
            if(time < 1)
            {
                win = true;
                StopGame(true);
            }
        }
    }
    void CheckPins()
    {
        currentPower = 0;
        for (int i = 0; i < Pins.Length; i++)
        {
            if (Pins[i].GetComponent<PinScriptTwo>().power == true)
            {
                currentPower += pinPower;
            }
            else
            {
                currentPower -= pinPower / 2;
            }
        }
        currentProgress += currentPower;
    }
    void ChangeColor(float value)
    {
        ColorBlock cb = Progress.colors;
        float redColor = 1;
        float greenColor = 1;
        if (0.25f > Mathf.Abs(0.5f - value))
        {
            redColor = Mathf.Abs(value - 0.5f) * 4;
        }
        if(0.25f < Mathf.Abs(0.5f - value))
        {
            greenColor = 2f - Mathf.Abs(value - 0.5f) * 4;
        }
        cb.disabledColor = new Color(redColor, greenColor, 0, 1);
        Progress.colors = cb;
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
