using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    [SerializeField]
    Button TitleButton;
    [SerializeField]
    Button FirstButton;
    [SerializeField]
    Button SecondButton;
    [SerializeField]
    Button ThirdButton;
    [SerializeField]
    Button ConfirmButton;
    [SerializeField]
    Text TitleText;
    [SerializeField]
    Text FirstText;
    [SerializeField]
    Text SecondText;
    [SerializeField]
    Text ThirdText;
    [SerializeField]
    Text TextYear;
    [SerializeField]
    Text DataText;
    [SerializeField]
    SpriteRenderer MainBackground;
    [SerializeField]
    Image ThemeGround;
    [SerializeField]
    Sprite[] Backgrounds;
    [SerializeField]
    Color[] Themes;
    [SerializeField]
    ParticleSystem mainParticle;
    bool allInclusive = true;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void TitleButtonClick()
    {

    }
    public void FirstButtonClick()
    {
        NextLevel(MainSector.standardRunTime);
    }
    public void SecondButtonClick()
    {
        NextLevel(MainSector.slowerRunTime);
    }
    public void ThirdButtonClick()
    {
        NextLevel(MainSector.fasterRunTime);
    }
    public void ConfirmQuest()
    {
        FirstButton.enabled = true;
        SecondButton.enabled = true;
        ThirdButton.enabled = true;
        GlobalChangeTheme();
        TextYear.color = new Color(1, 1, 1, 1);
        FirstText.color = new Color(1, 1, 1, 1);
        SecondText.color = new Color(1, 1, 1, 1);
        ThirdText.color = new Color(1, 1, 1, 1);
        DataText.color = new Color(1, 1, 1, 0);
        ConfirmButton.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        ConfirmButton.enabled = false;
        MainSector.Level++;
    }
    public void NextLevel(byte[] choice)
    {
        ConfirmButton.enabled = true;
        TextYear.color = new Color(1, 1, 1, 0);
        TextYear.text = (int.Parse(TextYear.text) + choice[MainSector.Level]).ToString();
        ThemeGround.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        GlobalChangeTheme();
        TextYear.color = new Color(1, 1, 1, 0);
        FirstButton.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        SecondButton.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        ThirdButton.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        ConfirmButton.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        FirstButton.enabled = false;
        SecondButton.enabled = false;
        ThirdButton.enabled = false;
        
        FirstText.color = new Color(1, 1, 1, 0);
        SecondText.color = new Color(1, 1, 1, 0);
        ThirdText.color = new Color(1, 1, 1, 0);
        DataText.color = new Color(1, 1, 1, 1);
        TitleText.fontSize = 45;
      FirstText.fontSize = SecondText.fontSize = ThirdText.fontSize = 30;
        DataText.fontSize = 25;
        TitleText.text = MainSector.nameLevel[MainSector.Level]+". " + MainSector.titleLevel[MainSector.Level];
        FirstText.text = MainSector.standardWay[MainSector.Level];
        SecondText.text = MainSector.downgradeWay[MainSector.Level];
        ThirdText.text = MainSector.upgradeWay[MainSector.Level];
        DataText.text = MainSector.dataLevel[MainSector.Level];
    }
    void GlobalChangeTheme()
    {
        switch (MainSector.nameLevel[MainSector.Level]) //В зависимости от названия сферы меняем расцветку
        {
            case "Военная и ядерная сферы":
                ChangeTheme(0);
                break;
            case "Медицина":
                ChangeTheme(1);
                break;
            case "Изобретение":
                ChangeTheme(3);
                break;
            case "Космос":
                ChangeTheme(2);
                break;
            case "Информационные технологии":
                ChangeTheme(4);
                break;
        }
    }
    void ChangeTheme(byte a)
    {
        ThemeGround.GetComponent<Image>().color = Themes[a];
        MainBackground.sprite = Backgrounds[a];
        TitleButton.GetComponent<Image>().color = Themes[a];
        SecondButton.GetComponent<Image>().color = Themes[a];
        ActiveButtonChanged(allInclusive, Themes[a]);
        mainParticle.startColor = Themes[a];
    }
    void ActiveButtonChanged(bool all, Color a)
    {
        if (all)
        {
            FirstButton.enabled = true;
            FirstButton.GetComponent<Image>().color = new Color(a.r, a.g, a.b, 150 / 255f);
            ThirdButton.enabled = true;
            ThirdButton.GetComponent<Image>().color = new Color(a.r, a.g, a.b, 150 / 255f);
        }
        else
        {
            FirstButton.enabled = false;
            FirstButton.GetComponent<Image>().color = new Color(a.r, a.g, a.b, 0.1f);
            ThirdButton.enabled = false;
            ThirdButton.GetComponent<Image>().color = new Color(a.r, a.g, a.b, 0.1f);
        }
    }
    public void Sucess()
    {
        allInclusive = true;
     //   NextLevel();
    }
    public void Failure()
    {
        allInclusive = false;
       // NextLevel();
    }
}
