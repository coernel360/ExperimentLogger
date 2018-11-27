using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LogWriter : MonoBehaviour
{
    [Tooltip ("Set logging frequency here (x/s)")]
    [SerializeField]
    float LoggingFrequency;

    [Tooltip ("Set to true if you want to log during next play")]
    [SerializeField]
    bool Log;

    StreamWriter writer;
	// Use this for initialization
	void Start () {
        var path = "Assets/Logs/";
        //check if directory doesn't exit
        if (!Directory.Exists (path))
        {
            //if it doesn't, create it
            Directory.CreateDirectory (path);
        }
        var LogFileName =  ".csv";

        writer = new StreamWriter (path + LogFileName);

        InvokeRepeating ("WriteLog", 0, 1 / LoggingFrequency);
	}

    void WriteLog()
    {
        if (Log)
            writer.WriteLine ("test" + " , " + DateTime.Now.Millisecond);
    }

    // Update is called once per frame
    private void OnApplicationQuit ()
    {
        writer.Close ();
    }


}
