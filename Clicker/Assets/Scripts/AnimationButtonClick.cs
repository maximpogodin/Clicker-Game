using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class AnimationButtonClick : MonoBehaviour 
{
    public Converter Convert;
	public Transform parent;
	public GameHelper _gameHelper;
    PlayerHelper _playerHelper;
	public HealthHelper _healthHelper;
	public Image HealthBar;
	public GameObject ImagePrefab;
	public Transform position;
	public GameObject Fill;
	public GameObject TextDamagePrefab; 
	public Transform ParentText;
	public int critChance = 1;

	public GameObject audio1;

	// Use this for initialization
	void Start () 
	{
		Fill = GameObject.FindGameObjectWithTag ("Fill");
		_gameHelper = GameObject.FindObjectOfType<GameHelper> ();
		_playerHelper = GameHelper.FindObjectOfType<PlayerHelper> ();
		_healthHelper = HealthHelper.FindObjectOfType<HealthHelper> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		_healthHelper = HealthHelper.FindObjectOfType<HealthHelper> ();

	}

	public void MouseDown()
	{
		GetComponent<Animator> ().SetBool ("Clicked", true);

	}

	public void MouseUp()
	{
		GetComponent<Animator> ().SetBool ("Clicked", false);

		_playerHelper.RunAttack ();

		GameObject textObj = Instantiate (TextDamagePrefab) as GameObject;
		textObj.transform.SetParent (ParentText, true);
		textObj.transform.position = new Vector3 (Random.Range (_gameHelper.PositionGold.position.x - 30, _gameHelper.PositionGold.position.x + 100), 
		                                          Random.Range (_gameHelper.PositionGold.position.y - 50, _gameHelper.PositionGold.position.y + 100));
        textObj.GetComponent<Text> ().text = _gameHelper.PlayerDamage.ToString();

		if (Random.Range (0, 100) < critChance) 
		{ 											//крит шанс
			textObj.GetComponent<Text> ().color = Color.red;
			textObj.transform.localScale= new Vector3 (2, 2, 2);
			_healthHelper.GetHit (_gameHelper.PlayerDamage * 2);
			textObj.GetComponent<Text> ().text = (_gameHelper.PlayerDamage * 2).ToString();

		} 
		else 
		{
			textObj.GetComponent<Text> ().color = Color.white;
			textObj.transform.localScale= new Vector3 (1.2f, 1.2f, 1.2f);
			_healthHelper.GetHit (_gameHelper.PlayerDamage);
			textObj.GetComponent<Text> ().text = _gameHelper.PlayerDamage.ToString();
		}

		Destroy (textObj, 1f);
		audio1.GetComponent<AudioSource> ().Play ();

		//HealthBar.transform.position.x, HealthBar.transform.position.y, _gameHelper.PlayerDamage, _gameHelper.PlayerDamage);
		//GameObject image = Instantiate (ImagePrefab) as GameObject;
		//image.transform.SetParent (parent, true);
		//image.transform.localScale = new Vector3 (_gameHelper.PlayerDamage/20f, 0.27f, 1f);
		//image.transform.localPosition = position.transform.localPosition;
		//Destroy (image, 2);
	}
}
