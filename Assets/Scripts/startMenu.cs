using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startMenu : MonoBehaviour {
	public InputField Activate;
	public CanvasGroup ExitView,TestView,InputView;
	public Button buttonTest, buttonExit, button1, button2, button3, button4, button5, button6, button7, button8, button9, button10;

	void Start () {
		TestView.alpha = 0f;
		TestView.blocksRaycasts = false;
		TestView.interactable = false;
		InputField act = Activate.GetComponent<InputField> ();
		act.onEndEdit.AddListener (CheckCode);
		Button btnTest = buttonTest.GetComponent<Button> ();
		Button btnExit = buttonExit.GetComponent<Button> ();
		Button btn1 = button1.GetComponent<Button> ();
		Button btn2 = button2.GetComponent<Button> ();
		Button btn3 = button3.GetComponent<Button> ();
		Button btn4 = button4.GetComponent<Button> ();
		Button btn5 = button5.GetComponent<Button> ();
		Button btn6 = button6.GetComponent<Button> ();
		Button btn7 = button7.GetComponent<Button> ();
		Button btn8 = button8.GetComponent<Button> ();
		Button btn9 = button9.GetComponent<Button> ();
		Button btn10 = button10.GetComponent<Button> ();
		btnTest.onClick.AddListener (TaskOnTest);
		btnExit.onClick.AddListener (TaskOnExit);
		btn1.onClick.AddListener (LoadOne);
		btn2.onClick.AddListener (LoadTwo);
		btn3.onClick.AddListener (LoadThree);
		btn4.onClick.AddListener (LoadFour);
		btn5.onClick.AddListener (LoadFive);
		btn6.onClick.AddListener (LoadSix);
		btn7.onClick.AddListener (LoadSeven);
		btn8.onClick.AddListener (LoadEight);
		btn9.onClick.AddListener (LoadNine);
		btn10.onClick.AddListener (LoadTen);
	}
	void CheckCode(string actCode){
		if (actCode == "tanvirkalam120") {
			PlayerPrefs.SetInt("activated",1);
			InputView.alpha = 0f;
			InputView.blocksRaycasts = false;
			InputView.interactable = false;
			TestView.alpha = 1f;
			TestView.blocksRaycasts = true;
			TestView.interactable = true;
			ExitView.alpha = 0f;
			ExitView.blocksRaycasts = false;
			ExitView.interactable = false;
		}


	}
	void LoadOne(){
		SceneManager.LoadScene ("test",LoadSceneMode.Single);
	}
	void LoadTwo(){
		SceneManager.LoadScene ("test_2",LoadSceneMode.Single);
	}
	void LoadThree(){
		SceneManager.LoadScene ("test_3",LoadSceneMode.Single);
	}
	void LoadFour(){
		SceneManager.LoadScene ("test_4",LoadSceneMode.Single);
	}
	void LoadFive(){
		SceneManager.LoadScene ("test_5",LoadSceneMode.Single);
	}
	void LoadSix(){
		SceneManager.LoadScene ("test_6",LoadSceneMode.Single);
	}
	void LoadSeven(){
		SceneManager.LoadScene ("test_7",LoadSceneMode.Single);
	}
	void LoadEight(){
		SceneManager.LoadScene ("test_8",LoadSceneMode.Single);
	}
	void LoadNine(){
		SceneManager.LoadScene ("test_9",LoadSceneMode.Single);
	}
	void LoadTen(){
		SceneManager.LoadScene ("test_10",LoadSceneMode.Single);
	}
	void TaskOnTest(){
		int x=PlayerPrefs.GetInt ("activated", 0);
		if (x == 1) {
			TestView.alpha = 1f;
			TestView.blocksRaycasts = true;
			TestView.interactable = true;
			ExitView.alpha = 0f;
			ExitView.blocksRaycasts = false;
			ExitView.interactable = false;
		} else {
			InputView.alpha = 1f;
			InputView.blocksRaycasts = true;
			InputView.interactable = true;
			ExitView.alpha = 0f;
			ExitView.blocksRaycasts = false;
			ExitView.interactable = false;
		}
	}
	void TaskOnExit(){
		if (TestView.alpha == 1f) {
			InputView.alpha = 0f;
			InputView.blocksRaycasts = false;
			InputView.interactable = false;
			TestView.alpha = 0f;
			TestView.blocksRaycasts = false;
			TestView.interactable = false;
			ExitView.alpha = 1f;
			ExitView.blocksRaycasts = true;
			ExitView.interactable = true;
		} else {
			Application.Quit ();
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
