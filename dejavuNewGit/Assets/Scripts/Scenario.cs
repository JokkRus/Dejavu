using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Scenario
{
    public string Key { get; set; }
    public string Text { get; set; }
    public Scenario()
    {

    }
    public Scenario(string key, string text)
    {
        Key = key;
        Text = text;
    }
}
