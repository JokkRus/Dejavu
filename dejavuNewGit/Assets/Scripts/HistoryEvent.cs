using UnityEngine;
using System;
using System.Xml.Serialization;

[Serializable]
public class HistoryEvent : IComparable<HistoryEvent>
{
    public string EventName { get; set; }
    public string EventBranch { get; set; }
    public string HistoryText { get; set; }

    public string StandartButton { get; set; }
    public string LowerButton { get; set; }
    public string UpperButton { get; set; }

    public int EventYear { get; set; }

    public int UpYear { get; set; }
    public int DownYear { get; set; }

    public string BackgroundImage { get; set; }
    public Color UIColor { get; set; }
    [XmlElement(ElementName = "MiniGameName")]
    public string MiniGame { get; set; }
    public HistoryEvent()
    {
        EventName = "";
        EventBranch = "Наука";
    }
    public HistoryEvent(int year)
    {
        EventYear = year;
        
    }

    public int CompareTo(HistoryEvent other)
    {

        if (this.EventYear > other.EventYear) return 1;
        if (this.EventYear < other.EventYear) return -1;
        else return 0;
    }
    public HistoryEvent Clone()
    {
        return (MemberwiseClone() as HistoryEvent);
    }
}
