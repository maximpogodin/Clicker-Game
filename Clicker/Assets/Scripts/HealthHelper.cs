using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class HealthHelper : MonoBehaviour 
{
	public int RubyChance;
	public GameObject TextDamagePrefab;

	//public float MaxHealth;
	//public float Health;

	bool _isDead;

	GameHelper _gameHelper;
	Color color = Color.green;

	float r=0.1f,g=1f,b=0f,a=1f;



	// Use this for initialization
	void Start () 
	{
		_gameHelper = GameObject.FindObjectOfType<GameHelper> ();
		_gameHelper.HealthSlider.maxValue = _gameHelper.MaxHealth;
		_gameHelper.HealthSlider.value = _gameHelper.MaxHealth;

	}
	
	// Update is called once per frame
	void Update () 
	{	
		if (_gameHelper._count == 10) 
		{
			if (_gameHelper.idle)
			{
				Destroy(gameObject);
				_gameHelper._count--;
			}
		}

	}

	public void GetHit(float damage)
	{
		var fill = (_gameHelper.HealthSlider as UnityEngine.UI.Slider).GetComponentsInChildren<UnityEngine.UI.Image>()
			.FirstOrDefault(t => t.name == "Fill");
		if (_gameHelper.HealthSlider.value <= _gameHelper.HealthSlider.maxValue) 
		{
			color.r += 1/_gameHelper.HealthSlider.maxValue*damage;
			color.g -= 1/_gameHelper.HealthSlider.maxValue*damage;
			fill.color = color;
		}


		if (_isDead)
			return;

		_gameHelper.Health -= damage;


		if (_gameHelper.Health <= 0) 
		{
			_isDead = true;
			_gameHelper.TakeGold(_gameHelper.Gold);

			int random = Random.Range (0, 100);
			if (random < RubyChance)
				_gameHelper.TakeRuby(1);


			Destroy(gameObject);
			fill.color = Color.green;
		}


		GetComponent<Animator>().SetTrigger("Hit");
		_gameHelper.HealthSlider.value = _gameHelper.Health;
	}

}
