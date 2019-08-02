using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class EventWriter : MonoBehaviour
{
    //------Fields------
    public List<string> Branches;
    static public string path;
    static public List<HistoryEvent> events;//Collection of events
    [HideInInspector] public List<string> eventNames;
    //-----Methods------
    public void Add(HistoryEvent n)
    {
        
        if (eventNames.Contains(n.EventName))
        {
            events.Remove(FindWithName(n.EventName));
        }
        events.Add(n);
        events.Sort();
        NamesUpdate();
        Serialize();
        
    }
    public void Remove(string name)
    {
        if (eventNames.Contains(name))
        {
            events.Remove(FindWithName(name));
        }
        Serialize();
        NamesUpdate();
        
    }
    //---
    void Start()
    {
        Upload();
        NamesUpdate();
    }
    //---
    static public List<HistoryEvent> Deserialize()
    {
        
        var serializer = new XmlSerializer(typeof(List<HistoryEvent>));
        var stream = new FileStream(path, FileMode.OpenOrCreate);
        List<HistoryEvent> container = serializer.Deserialize(stream) as List<HistoryEvent>;
        stream.Close();
        
        return container;
    }     //Xml serializing
    public void Serialize()
    {
        var serializer = new XmlSerializer(typeof(List<HistoryEvent>));
        var stream = new FileStream(path, FileMode.Create);
        serializer.Serialize(stream, events);
        stream.Close();

    }                     
    //---
    public HistoryEvent FindWithName(string name)
    {
        return events.Find(x => x.EventName == name);
    }
    public void NamesUpdate()
    {
        eventNames = new List<string>();
        for (int i = 0; i < events.Count; i++)
        {
            eventNames.Add(events[i].EventName);
        }
    }
    public void Upload()
    {
        path = Application.dataPath + "/Resources/event.xml";
        events = Deserialize();
        NamesUpdate();
    }
}
