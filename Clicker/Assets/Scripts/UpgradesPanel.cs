using UnityEngine;
using System.Collections;

public class UpgradesPanel : MonoBehaviour {
	bool open;

	// Use this for initialization
	void Start () 
	{
		open = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PanelOpen()
	{
		if (open) 
		{
			GetComponent<Animator> ().SetBool ("Upgrades", true);
			open = false;
		}
		else 
		{
			GetComponent<Animator> ().SetBool ("Upgrades", false);
			open = true;
		}
	}
	
}
