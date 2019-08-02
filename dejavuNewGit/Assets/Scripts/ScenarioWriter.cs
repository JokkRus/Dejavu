using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
[ExecuteInEditMode]
public class ScenarioWriter : MonoBehaviour {
    
    List<Scenario> scenaries;
    void Awake()
    {
        scenaries = new List<Scenario>();
        scenaries.Add(new Scenario("w000", "Olololo"));
        scenaries.Add(new Scenario("w001", "BHjbikfv"));
        Serialize();
    }
    public void Serialize()
    {
        var serializer = new XmlSerializer(typeof(List<Scenario>));
        var stream = new FileStream(Application.dataPath + "/Resources/scenaries.xml", FileMode.Create);
        serializer.Serialize(stream, scenaries);
        stream.Close();

    }
}
