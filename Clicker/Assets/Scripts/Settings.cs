using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Settings : MonoBehaviour 
{
	public GameHelper _gameHelper;
	bool setopen;
	public PanelAnim _panelAnim;
	public GameObject PanelSettings;
	public Slider QualitySlider;
	public Text QualityText;

	public GameObject cnocksound;

	// Use this for initialization
	void Start () 
	{
		QualitySettings.currentLevel = QualityLevel.Beautiful;
		setopen = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _gameHelper.SaveGame();
            Exit();
        }
	}

	public void Exit()
	{
		Application.Quit ();
	}

	public void OpenSettings()
	{
		if (setopen) 
		{
			cnocksound.GetComponent<AudioSource> ().Play ();
			_panelAnim.OpenPanel();
			GetComponent<Animator>().SetBool("Settings", true);
			setopen = false;
		} 
		else 
		{
			cnocksound.GetComponent<AudioSource> ().Play ();
			_panelAnim.ClosePanel();
			GetComponent<Animator>().SetBool("Settings", false);
			setopen = true;
		}
	}

	public void QualityBeautiful()
	{
		if (QualitySlider.value == 2) 
		{
			QualitySettings.currentLevel = QualityLevel.Beautiful;
			//QualityText.text = "Quality: High";
		}
	}

	public void QualityGood()
	{
		if (QualitySlider.value == 1) 
		{
			QualitySettings.currentLevel = QualityLevel.Good;
			//QualityText.text = "Quality: Normal";
		}
	}

	public void QualityFastest()
	{
		if (QualitySlider.value == 0) 
		{
			QualitySettings.currentLevel = QualityLevel.Fastest;
			//QualityText.text = "Quality: Low";
		}
	}

}
