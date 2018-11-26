using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


/// <summary>
/// This class attached as an Editorscript is used to set up 
/// PositionLogging in 3D Space for all items in the Array.
/// 
/// </summary>


public class LoggerManager : MonoBehaviour {

    [Tooltip("An object where the position logging is relative to. Used 0,0,0 if empty.")]
    [SerializeField] GameObject anchorObject;

    [SerializeField] GameObject[] objectsToLog;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
