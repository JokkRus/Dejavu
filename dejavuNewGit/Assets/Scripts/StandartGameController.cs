using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Text;

public class StandartGameController : MonoBehaviour
{
	List<Scenario> scenaries;
	string finishScenario;
    string[] spheres = new string[5];
    static public bool win;
    static public int difficulty;
    List<HistoryEvent> events;    //Main fields
    HistoryEvent currentEvent;
    int curIndex = 0;
    [SerializeField]
    Camera Camera;
    [SerializeField]
    Canvas Canvas;
    [SerializeField]
    GameObject Buttons;
    [SerializeField]
    GameObject History;
    #region UI fields
    [SerializeField]
    Image BackgroundImage;
    [SerializeField]
    Button TitleButton;
    [SerializeField]
    Button FirstButton;
    [SerializeField]
    Button SecondButton;
    [SerializeField]
    Button ThirdButton;
    [SerializeField]
    ParticleSystem Particles;
    [SerializeField]
    GameObject YearText;
    [SerializeField]
    Text HistoryText;

    #endregion
    void Awake()
    {
        spheres[0] = "w";
        spheres[1] = "m";
        spheres[2] = "k";
        spheres[3] = "i";
        spheres[4] = "t";
        win = false;
        difficulty = 0;
		LoadScenariesXml ();
		foreach (Scenario scen in scenaries) {
			Debug.Log (scen.Key + " " + scen.Text);
		}
        LoadEventsXml();
        LoadCurrent();
        StartCoroutine(StartLevel());
    }
    void Start()
    {

    }


    void Update()
    {

    }
    void LoadCurrent()
    {
        currentEvent = events[curIndex];
        UpdateCurrent();
        events.Sort();
    }

    void LoadEventsXml()
	{
        TextAsset textAsset = Resources.Load("event") as TextAsset;
        byte[] byteArray = Encoding.UTF8.GetBytes(textAsset.text);
        MemoryStream stream = new MemoryStream(byteArray);
        XmlSerializer xml = new XmlSerializer(typeof(List<HistoryEvent>));
        events = xml.Deserialize(stream) as List<HistoryEvent>;
        stream.Close();
    }
	void LoadScenariesXml()
	{
		TextAsset textAsset = Resources.Load("scenaries") as TextAsset;
		byte[] byteArray = Encoding.UTF8.GetBytes(textAsset.text);
		MemoryStream stream = new MemoryStream(byteArray);
		XmlSerializer xml = new XmlSerializer(typeof(List<Scenario>));
		scenaries = xml.Deserialize(stream) as List<Scenario>;
		stream.Close();
	}
    void UpdateCurrent()
    {
        TitleButton.GetComponentInChildren<Text>(false).text = currentEvent.EventBranch + "." + Environment.NewLine + currentEvent.EventName + ".";
        FirstButton.GetComponentInChildren<Text>(false).text = currentEvent.LowerButton;
        SecondButton.GetComponentInChildren<Text>(false).text = currentEvent.StandartButton;
        ThirdButton.GetComponentInChildren<Text>(false).text = currentEvent.UpperButton;
        BackgroundImage.sprite = Resources.Load<Sprite>("Background/" + currentEvent.BackgroundImage);
        YearText.GetComponentInChildren<Text>(false).text = Convert.ToString(currentEvent.EventYear);
        HistoryText.text = currentEvent.HistoryText;
        foreach (Button item in Canvas.GetComponentsInChildren<Button>())
        {
            Image image = item.GetComponent<Image>();
            if (item.tag != "HelpButton") image.color = currentEvent.UIColor;
            if (item.tag == "Title")
            {
                Color color = image.color;
                color *= 0.7f;
                color.a = 1;
                image.color = color;
            }

        }
    }
    public void CloseHistory()
    {
        Buttons.SetActive(true);
        History.SetActive(false);
    }
    public void OpenHistory()
    {
        Buttons.SetActive(false);
        History.SetActive(true);
    }
    IEnumerator StartLevel()
    {
        YearText.gameObject.SetActive(true);
        Animation anim = YearText.GetComponent<Animation>();
        anim.Play();
        yield return new WaitForSeconds(3);
        YearText.gameObject.SetActive(false);
        OpenHistory();
        yield return null;
    }
    IEnumerator WaitForAnimation(Animation animation)
    {
        do
        {
            yield return null;
        } while (animation.isPlaying);
    }
    public void LoadLevel(int diff)
    {
        StartCoroutine(LoadLvl(diff));
    }
    IEnumerator LoadLvl(int diff)
    {
        Camera.gameObject.GetComponent<AudioListener>().enabled = false;
        //Canvas.gameObject.SetActive(false);
        difficulty = diff;
        SceneManager.LoadScene(currentEvent.MiniGame, LoadSceneMode.Additive);
        yield return new WaitForEndOfFrame();
        Canvas.gameObject.SetActive(false);
		Camera.gameObject.GetComponent<AudioListener>().enabled = false;
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
        yield return new WaitForFixedUpdate();
        yield return GameObject.FindGameObjectWithTag("MiniGameController").GetComponent<MiniGameController>().WaitForEndOfGame();
        SceneManager.UnloadScene(currentEvent.MiniGame);
        //======
        int num = 0, year = 0;

        if ((difficulty == 1 && win == true) || (difficulty > 1 && win != true))
        {
            year = currentEvent.DownYear;
            num = 0;
        }
        else if (difficulty == 2 && win == true) num = 1;
        else if (difficulty == 3 && win == true)
        {
            year = currentEvent.UpYear;
            num = 2;
        }
        else Loose();
        //--------
        for (int i = curIndex + 1; i < events.Count; i++)
        {
            events[i].EventYear += year;
        }
        switch (currentEvent.EventBranch)
        {
            case "Ядерная энергетика":
                spheres[0] += num;
                break;
            case "Медицина":
                spheres[1] += num;
                break;
            case "Космос":
                spheres[2] += num;
                break;
            case "Изобретения":
                spheres[3] += num;
                break;
            case "Информационные технологии":
                spheres[4] += num;
                break;
            default: throw new Exception("Invalid sphere");
        }
        foreach (string t in spheres) Debug.Log(t);//test
		if (++curIndex != events.Count) {
			LoadCurrent ();
			StartCoroutine (StartLevel ());
			Camera.gameObject.GetComponent<AudioListener> ().enabled = true;
			Canvas.gameObject.SetActive (true);
		} else
			End ();
    }
    void Loose()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void End()
    {
		Camera.gameObject.GetComponent<AudioListener>().enabled = true;
		Canvas.gameObject.SetActive(true);
		OpenHistory ();
		History.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
		History.GetComponentInChildren<Button> ().onClick.AddListener (()=>SceneManager.LoadScene("MainMenu"));
		History.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text = "Выход";
		foreach (string key in spheres) {
			Scenario scen = scenaries.Find (x => x.Key == key);
			finishScenario += scen.Text;
			finishScenario += Environment.NewLine;
		}
        HistoryText.text = finishScenario;
        foreach (string t in spheres)
        {
            //if (!PlayerPrefs.HasKey(t)) PlayerPrefs.SetInt(t, 0);
        }
        //PlayerPrefs.Save();
    }
	void OnGUI(){
#if UNITY_EDITOR
        GUILayout.BeginArea (new Rect (0, 0, 150, 50));
		if (GUILayout.Button ("win"))
			GameObject.FindGameObjectWithTag ("MiniGameController").GetComponent<MiniGameController> ().EndGame (true);
		GUILayout.EndArea ();
#endif

    }
    //void OnLevelWasLoaded(int n)
    //{
    //    Debug.Log(true);
    //}
}
