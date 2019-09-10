using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skill2 : MonoBehaviour 
{
	public AnimationButtonClick _animationButtonClick;
	public GameObject Panel2;
	public Button buyUpgrades2;
	public int costUpgrades2 = 1;
	public Text costText;
	public GameHelper _gameHelper;
	bool open;
	
	// Use this for initialization
	void Start () 
	{
		Panel2.gameObject.SetActive (false);
		costText.text = costUpgrades2.ToString ();
		open = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_gameHelper.skillpoints < costUpgrades2) {
			buyUpgrades2.interactable = false;
		} else
			buyUpgrades2.interactable = true;

		costText.text = costUpgrades2.ToString ();

	}
	
	public void OpenUpgrades()
	{
		if (open) {
			Panel2.gameObject.SetActive (true);
			open = false;
		} else 
		{
			Panel2.gameObject.SetActive(false);
			open = true;
		}
		
	}
	
	public void BuyUpgrade()
	{
		costUpgrades2 += 1;
		_gameHelper.skillpoints -= 1;
		_animationButtonClick.critChance += 1;
		_gameHelper.SaveGame ();
	}
	
	
}
