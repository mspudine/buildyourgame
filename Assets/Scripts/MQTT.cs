using UnityEngine;
using System.Collections;

using uPLibrary.Networking.M2Mqtt;
using System;
using System.Runtime.InteropServices;
using System.Text;
using uPLibrary.Networking.M2Mqtt.Messages;

public class MQTT : MonoBehaviour {
	//http://tdoc.info/blog/2014/11/10/mqtt_csharp.html
	private MqttClient4Unity client;
	
	string brokerHostname = "13.80.23.240";
	int brokerPort = 8883;
	string userName = "Riccardo";
	string password = "";
	string topic = "FlappyMicrosoftDay";

	bool check = false;
	bool alterna = false;

	private Queue msgq = new Queue();

	string lastMessage = null;

	// Use this for initialization
	void Awake () {
		if (brokerHostname != null && userName != null && password != null) {
			Connect ();
			client.Subscribe(topic);
		}
		client.Publish(topic, System.Text.Encoding.ASCII.GetBytes("0/OFF/0"));
	}

	// Update is called once per frame
	void Update () {
		while (client.Count() > 0) {
			string s = client.Receive();
			msgq.Enqueue(s);
			Debug.Log("received :" + s);
		}

		if(BirdMovement1.gameOver && !check){

			client.Publish(topic, System.Text.Encoding.ASCII.GetBytes("0/ON/10"));
			StartCoroutine("Spegni");
			check = true;
		}

		if(BirdMovement1.inviaMessaggio){

			if(alterna){

				client.Publish(topic, System.Text.Encoding.ASCII.GetBytes("1/PULSE/1"));
			} else {

				client.Publish(topic, System.Text.Encoding.ASCII.GetBytes("2/PULSE/1"));
			}
			alterna = !alterna;
		}
	}

	IEnumerator Spegni(){

		yield return new WaitForSeconds(1);
		client.Publish(topic, System.Text.Encoding.ASCII.GetBytes("0/OFF/0"));
		StopCoroutine("Spegni");
	}

	public void Connect()
	{
		client = new MqttClient4Unity(brokerHostname, brokerPort, false, null);
		string clientId = "BuildYourGame";
		client.Connect(clientId, userName, password);
	}

	public void Publish(string _topic, string msg)
	{
		client.Publish(
			_topic, Encoding.UTF8.GetBytes(msg),
			MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
	}
}

