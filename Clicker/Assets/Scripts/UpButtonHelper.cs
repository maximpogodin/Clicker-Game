using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class UpButtonHelper : MonoBehaviour 
{
	GameHelper _gameHelper;
	HealthHelper _healthHelper;
	public int[] count;

	public GameObject item1Prefab;
	public Transform item1Position;
	public Transform itemParent;
	public bool item1Show;

	public GameObject item2Prefab;
	public Transform item2Position;
	public bool item2Show;

	public Button ButtonUpgradeClick;
	public Button ButtonItem1;
	public Button ButtonItem2;
	//Item1
	public Text DamageItem1Text;
	public Text PriceItem1Text;
	//public int count1;
	//Item2
	public Text DamageItem2Text;
	public Text PriceItem2Text;
	//public int count2;

	public Text DamageText;
	public Text PriceText;

	public float Damage;
	public float Price;
    public float[] Modifier = {1, 1, 1 };
	//public int count;

	public float DamageItem1;
	public float PriceItem1;

	public float DamageItem2;
	public float PriceItem2;


	public GameObject TextPrefab;
	public Transform TextPrefabParent;
	public Transform TextPrefabPosition;

	public Transform TextPrefabPositionItem1;
	public Transform TextPrefabParentItem1;

	public Transform TextPrefabPositionItem2;
	public Transform TextPrefabParentItem2;

    public int[] upgradesForItems = { 10, 25, 50, 100 };

	MySaveGame mySaveGame1 = new MySaveGame();
	
	// Use this for initialization
	void Start () 
	{
		if (DamageItem1 > 0) 
		{
			StartCoroutine(AttackItem1());
		}

		if (DamageItem2 > 0) 
		{
			StartCoroutine(AttackItem2());
		}
		_gameHelper = GameObject.FindObjectOfType<GameHelper> ();
		_healthHelper = HealthHelper.FindObjectOfType<HealthHelper> ();

		if (item1Show)
			ShowItem1 ();
		if (item2Show)
			ShowItem2 ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		_healthHelper = HealthHelper.FindObjectOfType<HealthHelper> ();

		if (_gameHelper.PlayerGold >= Price) 
			ButtonUpgradeClick.interactable = true;
		else
			ButtonUpgradeClick.interactable = false;

		if (_gameHelper.PlayerGold >= PriceItem1)
			ButtonItem1.interactable = true;
	    else
			ButtonItem1.interactable = false;

		if (_gameHelper.PlayerGold >= PriceItem2)
			ButtonItem2.interactable = true;
		else
			ButtonItem2.interactable = false;

		PriceText.text = _gameHelper.Convert.Convert(Price.ToString ());
		DamageText.text = _gameHelper.Convert.Convert(Damage.ToString ());
		PriceItem1Text.text = _gameHelper.Convert.Convert(PriceItem1.ToString ());
		DamageItem1Text.text = _gameHelper.Convert.Convert((DamageItem1).ToString());
		PriceItem2Text.text = _gameHelper.Convert.Convert(PriceItem2.ToString ());
		DamageItem2Text.text = _gameHelper.Convert.Convert((DamageItem2).ToString());
	}

	public void UpClick()//ClickDamage
	{
		if (_gameHelper.PlayerGold >= Price) 
		{
			count[0]++;
			_gameHelper.PlayerDamage = 1 * count[0] * Modifier[0];
			_gameHelper.PlayerGold -= Price;
			Price = (5 + count[0]) * Mathf.Pow(1.07f, count[0] - 1);
            _gameHelper.countTexts[0].text = "x" + count[0].ToString();
			_gameHelper.SaveGame();
		}

		GameObject textobj = Instantiate (TextPrefab) as GameObject;
		textobj.transform.SetParent (TextPrefabParent, true);
		textobj.transform.position = TextPrefabPosition.position;
		textobj.GetComponent<Text> ().text = "$$$";
		Destroy (textobj, 2f);

        if (count[0] == 10)
        {
            Price = 100f;
            Modifier[0] *= 2;
        }
	}

	public void ButtonItem1Start()//Item1
	{
		count[1]++;
		item1Show = true;
		if (_gameHelper.PlayerGold >= PriceItem1) 
		{
			if (DamageItem1 == 0)
			{
			StartCoroutine (AttackItem1());
				ShowItem1 ();
			}
			_gameHelper.PlayerGold -= PriceItem1;
			PriceItem1 = 50 * Mathf.Pow (1.07f, count[1]);
			DamageItem1 = (1 * 1.07f * count[1]) * Modifier[1];
            _gameHelper.countTexts[1].text = "x" + count[1].ToString();
            _gameHelper.SaveGame();
		}

		GameObject textobj = Instantiate (TextPrefab) as GameObject;
		textobj.transform.SetParent (TextPrefabParentItem1, true);
		textobj.transform.position = TextPrefabPositionItem1.position;
		textobj.GetComponent<Text> ().text = "$$$";
		Destroy (textobj, 1f);

        if (count[1] == 10)
        {
            Price = 500f;
            Modifier[1] *= 2;
        }

    }

	void ShowItem1()//создание пидара 1
	{
		GameObject item1 = Instantiate (item1Prefab) as GameObject;
		item1.transform.SetParent (itemParent, true);
		item1.transform.position = item1Position.position;
	}

	public void ButtonItem2Start()//Item2
	{
		count[2]++;
		item2Show = true;
		if (_gameHelper.PlayerGold >= PriceItem2) 
		{
			if (DamageItem2 == 0)
			{
				StartCoroutine (AttackItem2());
				ShowItem2 ();
			}
			_gameHelper.PlayerGold -= PriceItem2;
			PriceItem2 = 250 * Mathf.Pow (1.07f, count[2]);
			DamageItem2 = (10 * 1.07f * count[2]) * Modifier[2];
            _gameHelper.countTexts[2].text = "x" + count[2].ToString();
            _gameHelper.SaveGame();
		}
		
		GameObject textobj = Instantiate (TextPrefab) as GameObject;
		textobj.transform.SetParent (TextPrefabParentItem2, true);
		textobj.transform.position = TextPrefabPositionItem2.position;
		textobj.GetComponent<Text> ().text = "$$$";
		Destroy (textobj, 1f);

        if (count[1] == 10)
        {
            Price = 2500f;
            Modifier[2] *= 2;
        }
    }

	void ShowItem2()//создание пидара 2
	{
		GameObject item2 = Instantiate (item2Prefab) as GameObject;
		item2.transform.SetParent (itemParent, true);
		item2.transform.position = item2Position.position;
	}

	IEnumerator AttackItem1()
	{
		yield return new WaitForSeconds(0.01f);

			_healthHelper.GetHit (DamageItem1/70f);
		
			StartCoroutine (AttackItem1 ());
	}

	IEnumerator AttackItem2()
	{
		yield return new WaitForSeconds(0.01f);
		
		_healthHelper.GetHit (DamageItem2/70f);
		
		StartCoroutine (AttackItem2 ());
	}


}
