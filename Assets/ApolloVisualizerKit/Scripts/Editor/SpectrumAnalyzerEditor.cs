using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Apollo;
using System.IO;

[CustomEditor(typeof(SpectrumAnalyzer))]
public class SpectrumAnalyzerEditor : Editor
{
    SpectrumAnalyzer mySpectrum;
    /*
    SerializedProperty source;
    SerializedProperty rangeGroup;
    CustomRange range;

    void OnEnable()
    {
        mySpectrum = (SpectrumAnalyzer)target;
        source = serializedObject.FindProperty("Source");
        rangeGroup = serializedObject.FindProperty("Custom_Ranges"); 
        range = CustomRange.CreateInstance<CustomRange>();
        CheckForRanges();
    }
    private void CheckForRanges()
    {
        if (mySpectrum.Custom_Ranges!=null)
        {
            mySpectrum.Custom_Ranges = GetAtPath<CustomRange>("ApolloVisualizerKit/CustomRanges");
        }
        else
        {
            mySpectrum.Custom_Ranges = new CustomRange[1];
        }
    }

    public static CustomRange[] GetAtPath<CustomRange>(string path)
    {

        ArrayList al = new ArrayList();
        string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);
        foreach (string fileName in fileEntries)
        {
            int index = fileName.LastIndexOf("/");
            string localPath = "Assets/" + path;

            if (index > 0)
                localPath += fileName.Substring(index);

            Object t = AssetDatabase.LoadAssetAtPath(localPath, typeof(CustomRange));

            if (t != null)
                al.Add(t);
        }
        CustomRange[] result = new CustomRange[al.Count];
        for (int i = 0; i < al.Count; i++)
            result[i] = (CustomRange)al[i];

        return result;
    }

    private void CreateCustomRange(CustomRange range)
    {
        AssetDatabase.CreateAsset(range, "Assets/ApolloVisualizerKit/CustomRanges/" + range.name+ ".asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = range;
        CheckForRanges();
    }

        } */
    public override void OnInspectorGUI()
    {
        mySpectrum = (SpectrumAnalyzer)target;
        DrawDefaultInspector();/*
        mySpectrum.UseSpecificAudioSource = EditorGUILayout.Toggle("Use Specific AudioSource?",mySpectrum.UseSpecificAudioSource);
        EditorGUILayout.PropertyField(source,mySpectrum.Source);
        EditorGUILayout.PropertyField(rangeGroup,new GUIContent("Custom Ranges"));
        range.name = EditorGUILayout.TextField(new GUIContent("Custom Range Name","Sets the name of the new custom range"),range.name);
        range.LowestFrequency = EditorGUILayout.IntField(new GUIContent("Lowest Frequency","Sets the lowest frequency for the new custom range"),range.LowestFrequency);
        range.HighestFrequency = EditorGUILayout.IntField(new GUIContent("Highest Frequency", "Sets the highest frequency for the new custom range"),range.HighestFrequency);

        if (GUILayout.Button("Add Custom Range"))
        {
            CreateCustomRange(range);
        }*/
    }
}
