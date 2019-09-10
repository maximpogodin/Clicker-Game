using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class GameHelper : MonoBehaviour 
{

    public Converter Convert;
	public UpButtonHelper _upButtonHelper;
	public AnimationButtonClick _animationButtonClick;
	public Language language;

	public GameObject particleSystemCoinDrop;
    public Transform plane;


	//skills
	public Skill1 _skill1;
	public Skill5 _skill5;
	public Skill2 _skill2;

    public Text[] countTexts;

	public GameObject RubyPrefab;
	public Transform parentRubyPrefab;
	public Text DamageText;
	public float PlayerDamage = 1;
	public Slider HealthSlider;
	public Transform StartPosition;
	public float PlayerGold;
	public float totalGold;
	public Transform PositionGold;
	public float PlayerRuby;
	public float Gold = 1;
	public Text PlayerGoldUI;
	public Text RubyText;
	public GameObject GoldPrefab;
	public Transform parentGoldPrefab;
	public GameObject[] MonstersPrefabs;
	public GameObject[] BossPrefabs;
	HealthHelper _healthHelper;
	Ranks _ranks;
	public int _count = 0;
	public Text HpTextBar;
	public int Area = 1;
	public Text AreaText;
	public float Timer = 20;
	public Text TimerText;
	public int indexMonster;
	public Slider WaveSlider;

	public float MaxHealth;
	public float Health;
	
	float prevMaxHealth;

	GameObject BossObj;
	public Slider XpBar;
	public Text XpText;
	public Transform TextPrefabParentXp;
	public Transform TextPrefabPositionXp;
	public GameObject TextPrefab;
	int xp = 1;
	public int skillpoints = 0;
	public Text SkillText;

	public GameObject ChestPrefab;
	public int ChestChance;
	public bool idle;
	public Button BossFightButton;
	bool boss = true;

	public Image TimerImg;
	public Image TimerBack;

	//offline
	int year;
	int months;
	int day;
	int seconds;
	int minute;
	int hours;
	public Image OfflinePanel;
	public Text OfflineText;
	float damageTotal;
	float offGold;

	MySaveGame mySaveGame1 = new MySaveGame();

	// Use this for initialization
	void Start () 
	{
        
        _ranks = GameObject.FindObjectOfType<Ranks> ();
		language = GameObject.FindObjectOfType<Language> ();
        
        SpawnMonster();
        LoadGame();


        if (_upButtonHelper.DamageItem1 > 0) 
		{
			OfflinePanel.gameObject.SetActive(true);
			damageTotal = _upButtonHelper.DamageItem1 + _upButtonHelper.DamageItem2;

			offGold =  
				(((System.DateTime.Now.Hour - hours) * 3600) + 
				((System.DateTime.Now.Minute - minute) * 60) + 
				((System.DateTime.Now.Second - seconds))) * Gold;
            offGold /= MaxHealth;

			OfflineText.text = "Your earnings offline: " + Convert.Convert(offGold.ToString());
		}

		if (_count == 10) 
		{
			_count--;
            MaxHealth = 10 * (Area - 1 + Mathf.Pow(1.55f, Area - 1));
        }
		WaveSlider.value = _count;
		Health = MaxHealth;

		//language
		if (language.setLang == "ru") {
			language.ru_RU ();
		} 
		if (language.setLang == "en") 
		{
			language.en_EN ();
		}

        for (int i = 0; i <= 2; i++)
        {
            countTexts[i].text = "x" + _upButtonHelper.count[i].ToString();
        }
	}
	
	// Update is called once per frame
	void Update () 
	{

		SkillText.text = skillpoints.ToString ();
		WaveSlider.value = _count;
		PlayerGoldUI.text = Convert.Convert(PlayerGold.ToString ());
		DamageText.text = Convert.Convert(PlayerDamage.ToString ());
		RubyText.text = Convert.Convert(PlayerRuby.ToString ());
		HpTextBar.text = Convert.Convert(Health.ToString ()) + "/" + Convert.Convert(MaxHealth.ToString ());
		AreaText.text = Area.ToString ();
		TimerText.text = Convert.Convert(Timer.ToString ());
		XpText.text = Convert.Convert(XpBar.value.ToString()) + "/" + Convert.Convert(XpBar.maxValue.ToString()) + "xp";
	}

	public void TakeRuby(float ruby)
	{
		PlayerRuby += ruby;

		GameObject rubyObj = Instantiate (RubyPrefab) as GameObject;
		rubyObj.transform.SetParent (parentRubyPrefab, true);
		rubyObj.transform.SetSiblingIndex (8);

		XpBar.value += xp + 4;

		Destroy (rubyObj, 3);
		SaveGame ();
	}

	public void TakeGold(float gold)
	{
		PlayerGold += gold;
		totalGold += gold;

		GameObject goldObj = Instantiate (GoldPrefab);
		goldObj.transform.SetParent (parentGoldPrefab, true);
		goldObj.GetComponent<Text>().text = "    +" + Convert.Convert(Gold.ToString());
		goldObj.transform.SetSiblingIndex (8);
		goldObj.transform.position = new Vector3 (Random.Range (PositionGold.position.x - 50, PositionGold.position.x + 50), Random.Range (PositionGold.position.y - 0, PositionGold.position.y +100));

		Destroy (goldObj, 2f);

        SpawnMonster ();

        var ma = particleSystemCoinDrop.GetComponent<ParticleSystem>().main;
        var col = particleSystemCoinDrop.GetComponent<ParticleSystem>().collision;
        col.SetPlane(0, plane);
        if (Area < 10)
        {
            ma.maxParticles = 1;
        }
        if (Area >= 10 && Area < 15)
        {
            ma.maxParticles = 2;
        }
        if (Area >= 15 && Area < 25)
        {
            ma.maxParticles = 3;
        }
        if (Area >= 25 && Area < 35)
        {
            ma.maxParticles = 4;
        }
        if (Area >= 35)
        {
            ma.maxParticles = 5;
        }
        GameObject coin = Instantiate(particleSystemCoinDrop);
        coin.transform.position = StartPosition.position;

        Destroy(coin, 2f);      

		XpLevelRank ();
		WaveSlider.value = _count;
		SaveGame ();//сохранение игры
	}

	public void XpLevelRank()
	{
		//xp = 1;
		//GameObject textobj = Instantiate (TextPrefab) as GameObject;
		//textobj.transform.SetParent (TextPrefabParentXp, true);
		//textobj.transform.position = TextPrefabPositionXp.position;
	    //textobj.GetComponent<Text> ().text = "+" + xp + "xp";

		XpBar.value += xp;
        SaveGame();

		if (XpBar.value >= XpBar.maxValue) 
		{
			XpBar.maxValue += 10;
			XpBar.value = 0;
			skillpoints += 1;
			_ranks.LevelUp ();
			SaveGame();
		}
	}

	public void SpawnMonster()
	{
		if (idle) 
		{
			SpawnMonsterIdle ();
		} 
		else 
		{
			int random = Random.Range (0, 100);
			if (random < ChestChance) 
			{
				_count++;
				if (_count <= 9)
				{
					ChestSpawn ();
                    MaxHealth = 10 * (Area - 1 + Mathf.Pow(1.55f, Area - 1));
					Health = MaxHealth;
                    Gold = MaxHealth / 15;
				}
			} 
			else 
			{
				_count++;          
                MaxHealth = 10 * (Area - 1 + Mathf.Pow(1.55f, Area - 1));
                Gold = MaxHealth / 15;
                indexMonster = Random.Range (0, MonstersPrefabs.Length);
				int indexBoss = Random.Range (0, BossPrefabs.Length);

				if (_count == 10) 
				{ //вызов босса	
					//WaveText.gameObject.SetActive(false);
					Timer = 20;
					TimerImg.fillAmount = 1;
					TimerBack.gameObject.SetActive (true);
					MaxHealth = (10 * (Area - 1 + Mathf.Pow(1.55f, Area - 1))) * 10;
                    if (boss)
                    {
                        StartCoroutine(TimerTick());
                    }
					boss = false;
					//mySaveGame1.MaxHealth = MaxHealth;
					BossObj = Instantiate (BossPrefabs [indexBoss]) as GameObject;
					BossObj.transform.position = StartPosition.position;
                    //TimerText.gameObject.SetActive(true);
                    Gold = MaxHealth / 15;
                    mySaveGame1.MaxHealth = MaxHealth;
				} 
				else 
				{ //иначе один из педиков
					//WaveText.gameObject.SetActive(true);
					GameObject monsterObj = Instantiate (MonstersPrefabs [indexMonster]) as GameObject;						
					monsterObj.transform.position = StartPosition.position;
                    //mySaveGame1.MaxHealth = MaxHealth;

                    mySaveGame1.MaxHealth = MaxHealth;
                }
				if (_count > 10) 
				{//смена арены
					Timer = Mathf.Infinity;
					//MaxHealth /= 2f;
					//mySaveGame1.MaxHealth = MaxHealth;
					//TimerText.gameObject.SetActive (false);
					TimerBack.gameObject.SetActive (false);
					_count = 1;
					Area++;    
					MaxHealth = 10 * (Area - 1 + Mathf.Pow(1.55f, Area - 1));
                    Gold = MaxHealth / 15;
                    mySaveGame1.MaxHealth = MaxHealth;
                }

				Health = MaxHealth;
                mySaveGame1.MaxHealth = MaxHealth;
                mySaveGame1.Health = Health;
            }
		}
	}

	public void SpawnMonsterIdle()
	{
		xp = 0;
		StopCoroutine (TimerTick ());
		BossFightButton.gameObject.SetActive (true);
		TimerBack.gameObject.SetActive (false);
        MaxHealth = 10 * (Area - 1 + Mathf.Pow(1.55f, Area - 1));
        Gold = MaxHealth / 15;	
        Health = MaxHealth;
		indexMonster = Random.Range (0, MonstersPrefabs.Length);
		GameObject monsterObj = Instantiate (MonstersPrefabs [indexMonster]) as GameObject;						
		monsterObj.transform.position = StartPosition.position;
		mySaveGame1.MaxHealth = MaxHealth;
		Timer = Mathf.Infinity;
	}

	IEnumerator TimerTick()
	{
		yield return new WaitForSeconds (0.1f);
		Timer -= 0.1f;
		TimerImg.fillAmount -= 1 / 20f * 0.1f;
        if (Timer <= 0)
        {
            SpawnMonsterIdle();
            TimerBack.gameObject.SetActive(false);
            idle = true;
        }
        else
        StartCoroutine (TimerTick ());
	}

	public void SaveGame()
	{
        mySaveGame1.MaxHealth = MaxHealth;
        mySaveGame1.Health = Health;
        mySaveGame1.skillpoints = skillpoints;
		mySaveGame1.PlayerGold = PlayerGold;
		mySaveGame1.totalGold = totalGold;
		mySaveGame1.Wave = _count;
		mySaveGame1.Area = Area;
		mySaveGame1.PlayerDamage = PlayerDamage;
		mySaveGame1.PriceButtonClick = _upButtonHelper.Price;
		mySaveGame1.PlayerRuby = PlayerRuby;
		mySaveGame1.Gold = Gold;
		mySaveGame1.DamageItem1 = _upButtonHelper.DamageItem1;
		mySaveGame1.CurXp = XpBar.value;
		mySaveGame1.MaxXp = XpBar.maxValue;
		mySaveGame1.level = _ranks.level;
		mySaveGame1.CritChance = _animationButtonClick.critChance;
		mySaveGame1.count = _upButtonHelper.count;
		mySaveGame1.PriceItem1 = _upButtonHelper.PriceItem1;
		mySaveGame1.DamageItem1 = _upButtonHelper.DamageItem1;
		mySaveGame1.PriceItem2 = _upButtonHelper.PriceItem2;
		mySaveGame1.DamageItem2 = _upButtonHelper.DamageItem2;

		//offline
		mySaveGame1.Seconds = System.DateTime.Now.Second;
		mySaveGame1.Minute = System.DateTime.Now.Minute;
		mySaveGame1.Hours = System.DateTime.Now.Hour;
		mySaveGame1.Months = System.DateTime.Now.Month;
		mySaveGame1.Year = System.DateTime.Now.Year;
		mySaveGame1.Day = System.DateTime.Now.Day;

		//skills
		mySaveGame1.costUpgrades = _skill1.costUpgrades;
		mySaveGame1.costUpgrades5 = _skill5.costUpgrades5;
		mySaveGame1.costUpgrades2 = _skill2.costUpgrades2;

		//language
		mySaveGame1.setLang = language.setLang;

		//items
		mySaveGame1.item1Show = _upButtonHelper.item1Show;
		mySaveGame1.item2Show = _upButtonHelper.item2Show;

        //modifiers
        mySaveGame1.Modifier = _upButtonHelper.Modifier;

		SaveGameSystem.SaveGame(mySaveGame1, "MySaveGame");
	}

	public void LoadGame()
	{
		MySaveGame mySaveGame2 = SaveGameSystem.LoadGame("MySaveGame") as MySaveGame;
		skillpoints = mySaveGame2.skillpoints;
		PlayerGold = mySaveGame2.PlayerGold;
		totalGold = mySaveGame2.totalGold;
		Area = mySaveGame2.Area;
		_count = mySaveGame2.Wave;
		MaxHealth = mySaveGame2.MaxHealth;
		Health = mySaveGame2.Health;
		Gold = mySaveGame2.Gold;
		PlayerDamage = mySaveGame2.PlayerDamage;
		_upButtonHelper.Price = mySaveGame2.PriceButtonClick;
		PlayerRuby = mySaveGame2.PlayerRuby;
		XpBar.value = mySaveGame2.CurXp;
		XpBar.maxValue = mySaveGame2.MaxXp;
		_ranks.level = mySaveGame2.level;
		_animationButtonClick.critChance = mySaveGame2.CritChance;
		_upButtonHelper.count = mySaveGame2.count;
		_upButtonHelper.PriceItem1 = mySaveGame2.PriceItem1;
		_upButtonHelper.DamageItem1 = mySaveGame2.DamageItem1;
		_upButtonHelper.PriceItem2 = mySaveGame2.PriceItem2;
		_upButtonHelper.DamageItem2 = mySaveGame2.DamageItem2;

		//offline
		seconds = mySaveGame2.Seconds;
		minute = mySaveGame2.Minute;
		hours = mySaveGame2.Hours;
		months = mySaveGame2.Months;
		year = mySaveGame2.Year;
		day = mySaveGame2.Day;

		//skills
		_skill1.costUpgrades = mySaveGame2.costUpgrades;
		_skill5.costUpgrades5 = mySaveGame2.costUpgrades5;
		_skill2.costUpgrades2 = mySaveGame2.costUpgrades2;

		//language
		language.setLang = mySaveGame2.setLang;

		//items
		_upButtonHelper.item1Show = mySaveGame2.item1Show;
		_upButtonHelper.item2Show = mySaveGame2.item2Show;

        //modifiers
        _upButtonHelper.Modifier = mySaveGame2.Modifier;

	}

	public void DeleteSave()
	{

		SaveGameSystem.DeleteSaveGame("MySaveGame");
		Application.LoadLevel (0);
	}

	public void ChestSpawn()
	{
		GameObject Chestobj = Instantiate (ChestPrefab) as GameObject;
		Chestobj.transform.position = StartPosition.position;
	}

	public void BossFight()
	{
		xp = 1;
		TimerImg.fillAmount = 1;
		BossFightButton.gameObject.SetActive (false);
		idle = false;
		GameObject obj = GameObject.FindGameObjectWithTag("Monster");
		Destroy (obj);
		SpawnMonster ();
	}

	public void OffButton()
	{
		PlayerGold += offGold;
		totalGold += offGold;

		OfflinePanel.gameObject.SetActive (false);
	}
	
}
