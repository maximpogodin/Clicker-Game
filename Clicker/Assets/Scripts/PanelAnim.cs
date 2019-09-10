using UnityEngine;
using System.Collections;

public class PanelAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ClosePanel()
	{
		GetComponent<Animator> ().SetBool ("Panel", false);
	}

	public void OpenPanel()
	{
		GetComponent<Animator> ().SetBool ("Panel", true);
	}
}
