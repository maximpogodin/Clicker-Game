using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skill5 : MonoBehaviour 
{
	public GameObject Panel5;
	public Button buyUpgrades5;
	public int costUpgrades5 = 1;
	public Text costText5;
	public GameHelper _gameHelper;
	bool open;
	
	// Use this for initialization
	void Start () 
	{
		Panel5.gameObject.SetActive (false);
		costText5.text = costUpgrades5.ToString ();
		open = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_gameHelper.skillpoints < costUpgrades5) {
			buyUpgrades5.interactable = false;
		} else
			buyUpgrades5.interactable = true;
	}
	
	public void OpenUpgrades()
	{
		if (open) {
			Panel5.gameObject.SetActive (true);
			open = false;
		} else 
		{
			Panel5.gameObject.SetActive(false);
			open = true;
		}
		
	}
	
	public void BuyUpgrade()
	{
		costUpgrades5 += 1;
		_gameHelper.skillpoints -= 1;

		costText5.text = costUpgrades5.ToString ();

		_gameHelper.SaveGame ();
	}
	
	
}