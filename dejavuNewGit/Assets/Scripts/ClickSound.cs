using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[AddComponentMenu("UI/Button Click")]
[RequireComponent(typeof(AudioSource))]
public class ClickSound : MonoBehaviour
{
    Button[] buttons;
    public AudioClip clip;
    public AudioSource audio { get { return GetComponent<AudioSource>(); } }
    void Awake()
    {
        clip = Resources.Load<AudioClip>("Audio/click");
        audio.clip = clip;
        audio.playOnAwake = false;
        audio.enabled = true;
        buttons = FindObjectsOfType<Button>();
        foreach(Button but in buttons)
        {
            but.onClick.AddListener(() => audio.PlayOneShot(clip));
        }
    }

}

