using UnityEngine;
using System.Collections;

public class levelManager : MonoBehaviour {


	public void LoadLevel(string name){
		Debug.Log("New Level load: " + name);
		Application.LoadLevel(name);
	}
	public void QuitRequest ()
	{
		Debug.Log ("Quit Requested ");
		Application.Quit ();
	}



	public void LoadNextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}

}
