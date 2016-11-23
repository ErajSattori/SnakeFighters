using UnityEngine;
using System.Collections;

public class musicPlayer : MonoBehaviour {
	static musicPlayer instance = null;
	// Use this for initialization

	void Awake () {
		Debug.Log("Music player Awake." + GetInstanceID());
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate is destroyed!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	void Start ()
	{  
		Debug.Log("Music player Start." + GetInstanceID());
	}

	// Update is called once per frame
	void Update () {

	}
}
