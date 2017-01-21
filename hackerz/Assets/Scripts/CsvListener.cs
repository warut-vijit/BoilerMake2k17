using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class CsvListener : MonoBehaviour {

	public string DATA_PATH;
	public GameObject PACKET_OBJECT;

	private string dataUrl;
	private DateTime lastUpdate;

	private class Packet {
		public string orig;
		public string dest;
		public string type;
		public int size;
		public string message;
		
		public Packet(string data){
			//Constructor for package
		}
		public Packet(){ //For debugging
			orig = "127.0.0.0";
			dest = "123.345.45.6";
			type = "TCP";
			size = 1024;
			message = "SWEDISH FISH";
		}
	}

	// Use this for initialization
	void Start () {
		dataUrl = Environment.CurrentDirectory+DATA_PATH;
		//Add file handling behavior later
		Debug.Log(System.IO.File.ReadAllText(dataUrl));
		lastUpdate = System.IO.File.GetLastWriteTime(dataUrl);

		displayPacket(new Packet());
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

	//Instantiate packet object
	void displayPacket(Packet packet){
		GameObject packet_obj = (GameObject) Instantiate(PACKET_OBJECT, Vector3.back * 10, Quaternion.identity);
		foreach (Transform child in packet_obj.transform){
			if(child.gameObject.tag == "packet_label"){
				child.GetComponent<TextMesh>().text = packet.message;
			}
			else if(child.gameObject.tag == "packet_capsule"){
				Color capsule_color;
				switch(packet.type){
					case "TCP":
						capsule_color = Color.green;
						break;
					case "UDP":
						capsule_color = Color.blue;
						break;
					default:
						capsule_color = Color.white;
						break;
				}
				child.GetComponent<Renderer>().material.SetColor("_Color", capsule_color);
			}
		}
	}
}
