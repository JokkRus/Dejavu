using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventWriter))]
public class EventWriterEditor : Editor
{
    bool showNames = false;//Bool of showing names table
    EventWriter main;//Main event writer
    static public HistoryEvent current;//Current event
    bool warning = false;
    public override void OnInspectorGUI()
    {
        EditorStyles.textField.wordWrap = true;
        DrawDefaultInspector();
        GUILayout.Space(20);
        showNames = EditorGUILayout.Foldout(showNames, "Events");
        if (showNames)
        {
            foreach (string name in main.eventNames)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(name);
                if (GUILayout.Button("Load")) current = main.FindWithName(name).Clone();
                if (GUILayout.Button("Remove")) main.Remove(name);
                EditorGUILayout.EndHorizontal();
            }
        }

        #region Finding event mechanism
        //EditorGUILayout.Space();
        //eventName = EditorGUILayout.TextField("Name", eventName);
        //if (GUILayout.Button("Find event with name"))
        //{
        //    if (main.eventNames.Contains(eventName))
        //    {
        //        current = main.FindWithName(eventName).Clone();
        //        warning = false;
        //    }
        //    else warning = true;
        //}
        //if (warning)
        //    EditorGUILayout.HelpBox("No events with this name", MessageType.Error);
        #endregion

        GUILayout.Space(10);
        if (current != null)
        {
            
            current.EventName = EditorGUILayout.TextField("Name", current.EventName);
            int index = main.Branches.FindIndex(x => x == current.EventBranch);
            index = EditorGUILayout.Popup("Branch", index, main.Branches.ToArray());
            current.EventBranch = main.Branches[index];
            current.EventYear = EditorGUILayout.IntField("Year", current.EventYear);
            EditorGUILayout.Space();
            EditorGUILayout.PrefixLabel("History");
            EditorGUILayout.BeginHorizontal();
            current.HistoryText = EditorGUILayout.TextArea(current.HistoryText);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
            current.MiniGame = EditorGUILayout.TextField("Minigame scene", current.MiniGame);
            EditorGUILayout.Space();
            current.LowerButton = EditorGUILayout.TextField("Downgrade button", current.LowerButton);
            current.StandartButton = EditorGUILayout.TextField("Standart button", current.StandartButton);
            current.UpperButton = EditorGUILayout.TextField("Upgrade button", current.UpperButton);
            EditorGUILayout.Space();
            current.DownYear = EditorGUILayout.IntField("Downgrade year sum", current.DownYear);
            current.UpYear = EditorGUILayout.IntField("Upgrade year sum", current.UpYear);
            EditorGUILayout.Space();
            current.UIColor = EditorGUILayout.ColorField("Color of UI", current.UIColor);
            current.BackgroundImage = EditorGUILayout.TextField("Background image", current.BackgroundImage);

            if (GUILayout.Button("Save current")) Save();
            if (warning) EditorGUILayout.HelpBox("Name is null", MessageType.Error);
        }
        if (GUILayout.Button("Add new event")) current = new HistoryEvent();


    }
    //--Event-Save-----
    void Save()
    {
        if (current.EventName == "") { warning = true; return; }
        else warning = false;
        main.Add(current);
        current = null;
    }
    //---OnEnable------
    void OnEnable()
    {
        
        main = (target as EventWriter);
        if (main != null) main.Upload();
    }


}
