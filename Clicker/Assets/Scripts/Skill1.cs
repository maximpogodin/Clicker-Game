using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skill1 : MonoBehaviour 
{
	public GameObject Panel;
	public Button buyUpgrades;
	public int costUpgrades = 1;
	public Text costText;
	public GameHelper _gameHelper;
	public Slider _slider;
	bool open;

	// Use this for initialization
	void Start () 
	{
		Panel.gameObject.SetActive (false);
		costText.text = costUpgrades.ToString ();
		open = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		_slider.value = costUpgrades - 1;
		if (_gameHelper.skillpoints < costUpgrades) 
		{
			buyUpgrades.interactable = false;
		} else
			buyUpgrades.interactable = true;
		costText.text = costUpgrades.ToString ();

		if (costUpgrades > 3) 
		{
			Destroy(Panel);
		}

	}

	public void OpenUpgrades()
	{
		if (open) {
			Panel.gameObject.SetActive (true);
			open = false;
		} else 
		{
			Panel.gameObject.SetActive(false);
			open = true;
		}

	}

	public void BuyUpgrade()
	{
		costUpgrades += 1;
		_gameHelper.skillpoints -= 1;
		_gameHelper.PlayerDamage += 5;
		_gameHelper.SaveGame ();
	}


}
