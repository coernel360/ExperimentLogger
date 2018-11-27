using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// This class attached as an Editorscript is used to set up 
/// PositionLogging in 3D Space for all items in the Array.
/// 
/// </summary>


public class LoggerManager : MonoBehaviour {

    [Tooltip("An object where the position logging is relative to. Used 0,0,0 if empty.")]
    [SerializeField] GameObject anchorObject;


    [Tooltip ("Set logging frequency here (x/s)")]
    [SerializeField]
    float LoggingFrequency;

    [SerializeField] GameObject[] objectsToLog;

    private StreamWriter writer;

    // Use this for initialization
    void Start () {
        var path = "Assets/Logs/";
        //check if directory doesn't exit
        if (!Directory.Exists (path))
        {
            //if it doesn't, create it
            Directory.CreateDirectory (path);
        }
        var LogFileName = "AllItems.csv";

        writer = new StreamWriter (path + LogFileName);

        InvokeRepeating ("WriteLog", 0, 1 / LoggingFrequency);
    }

    void WriteLog ()
    {
        foreach (GameObject go in objectsToLog)
            writer.WriteLine (go.name + "," + go.transform.position.ToString () + "," + DateTime.Now.Millisecond);
    }

    private void OnApplicationQuit ()
    {
     writer.Close ();
    }
}
