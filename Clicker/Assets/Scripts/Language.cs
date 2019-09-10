using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Language : MonoBehaviour 
{
	GameObject gameobject;
	GameObject[] buy;
	public string setLang;
	GameHelper _gameHelper;

	// Use this for initialization
	void Start () 
	{
		_gameHelper = GameObject.FindObjectOfType<GameHelper> ();


		if (setLang == "ru") 
		{
			//titlescreen
			gameobject = GameObject.FindGameObjectWithTag ("TitleScreen");
			gameobject.GetComponent<Text> ().text = "Коснитесь экрана, чтобы начать";
		}
		if (setLang == "en") 
		{
			//titlescreen
			gameobject = GameObject.FindGameObjectWithTag ("TitleScreen");
			gameobject.GetComponent<Text>().text = "Touch screen to start";
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void ru_RU()
	{
		setLang = "ru";

		//settings
		gameobject = GameObject.FindGameObjectWithTag ("Settings");
		gameobject.GetComponent<Text>().text = "Настройки";

        //quality
        gameobject = GameObject.FindGameObjectWithTag("Quality");
        gameobject.GetComponent<Text>().text = "Качество";

        //delete save
        gameobject = GameObject.FindGameObjectWithTag ("Reset");
		gameobject.GetComponent<Text>().text = "Удалить данные";

		//quit
		gameobject = GameObject.FindGameObjectWithTag ("Quit");
		gameobject.GetComponent<Text>().text = "Выход";

		//area
		gameobject = GameObject.FindGameObjectWithTag ("Area");
		gameobject.GetComponent<Text>().text = "Зона:";

		//skilltree
		gameobject = GameObject.FindGameObjectWithTag ("Skill Tree");
		gameobject.GetComponent<Text>().text = "Навыки";

		//buyupgrade
		buy = GameObject.FindGameObjectsWithTag ("Buy");
		for (int i = 0; i < buy.Length; i++) 
		{
			buy [i].GetComponent<Text> ().text = "Цена:";
			buy [i].GetComponent<HorizontalLayoutGroup> ().padding.left = 60;
		}

		//dmg
		buy = GameObject.FindGameObjectsWithTag ("DMG");
		for (int i = 0; i < buy.Length; i++) 
		{
			buy [i].GetComponent<Text> ().text = "Урон:";
			buy [i].GetComponent<HorizontalLayoutGroup> ().padding.left = 60;
		}

		//statistic
		gameobject = GameObject.FindGameObjectWithTag ("Statistic");
		gameobject.GetComponent<Text>().text = "Статистика";
			
        
			
		_gameHelper.SaveGame ();
	}

	public void en_EN()
	{
		setLang = "en";

		//settings
		gameobject = GameObject.FindGameObjectWithTag ("Settings");
		gameobject.GetComponent<Text>().text = "Settings";

        //quality
        gameobject = GameObject.FindGameObjectWithTag("Quality");
        gameobject.GetComponent<Text>().text = "Quality";

        //delete save
        gameobject = GameObject.FindGameObjectWithTag ("Reset");
		gameobject.GetComponent<Text>().text = "Delete Save";

		//quit
		gameobject = GameObject.FindGameObjectWithTag ("Quit");
		gameobject.GetComponent<Text>().text = "Quit";

		//area
		gameobject = GameObject.FindGameObjectWithTag ("Area");
		gameobject.GetComponent<Text>().text = "Area:";

		//skilltree
		gameobject = GameObject.FindGameObjectWithTag ("Skill Tree");
		gameobject.GetComponent<Text>().text = "Skill Tree";

		//buyupgrade
		buy = GameObject.FindGameObjectsWithTag ("Buy");
		for (int i = 0; i < buy.Length; i++) 
		{
			buy [i].GetComponent<Text> ().text = "Buy:";
			buy [i].GetComponent<HorizontalLayoutGroup> ().padding.left = 50;
		}

		//dmg
		buy = GameObject.FindGameObjectsWithTag ("DMG");
		for (int i = 0; i < buy.Length; i++) 
		{
			buy [i].GetComponent<Text> ().text = "DMG:";
			buy [i].GetComponent<HorizontalLayoutGroup> ().padding.left = 54;
		}
	   
		//statistic
		gameobject = GameObject.FindGameObjectWithTag ("Statistic");
		gameobject.GetComponent<Text>().text = "Statistics";

		_gameHelper.SaveGame ();
	}
}
