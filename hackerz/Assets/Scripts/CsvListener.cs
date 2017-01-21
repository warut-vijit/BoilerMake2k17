using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class CsvListener : MonoBehaviour {

	public string DATA_PATH;

	private string dataUrl;
	private DateTime lastUpdate;

	// Use this for initialization
	void Start () {
		dataUrl = Environment.CurrentDirectory+DATA_PATH;
		//Add file handling behavior later
		Debug.Log(System.IO.File.ReadAllText(dataUrl));
		lastUpdate = System.IO.File.GetLastWriteTime(dataUrl);
	}
	
	// Update is called once per frame
	void Update () {
		//Read file if updates have been written
		if(System.IO.File.GetLastWriteTime(dataUrl) != lastUpdate){
			//Add file handling behavior later
			Debug.Log(System.IO.File.ReadAllText(dataUrl));
			lastUpdate = System.IO.File.GetLastWriteTime(dataUrl);
		}
	}
}
