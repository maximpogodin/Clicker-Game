using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class MySaveGame : SaveGame 
{
    public float[] Modifier;

	public float PlayerGold;
	public float totalGold;
	public float Gold;
	public float PlayerRuby;
	public int Area;
	public int Wave;
	public float MaxHealth;
	public float Health;
	public float PlayerDamage;
	public float PriceButtonClick;
	public float DamageItem1;
	public float CurXp;
	public float MaxXp;
	public int level;
	public int []count;
	public float PriceItem1;
	public float DamageItem2;
	public float PriceItem2;
	public int Seconds;
	public int Minute;
	public int Hours;
	public int Day;
	public int Months;
	public int Year;
	public int skillpoints;
	public int CritChance;
	public string setLang;
	public bool item1Show;
	public bool item2Show;

	//skills
	public int costUpgrades;
	public int costUpgrades5;
	public int costUpgrades2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
