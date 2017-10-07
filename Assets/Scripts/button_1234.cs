using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;

public class button_1234 : MonoBehaviour {
	public CanvasGroup dropdownView,listeningView,nextView,listeningView2,adView,scoreView;
	public Text Next,QuestionNo,TimerText,scoreText;
	public AudioClip intro,qs21,qs22,qs23,qs24,qs25,qs26,qs27,qs28,qs29,qs30,qs31,qs32,qs33,qs34,qs35,qs36,qs37,qs38,qs39,qs40;
	private AudioSource s;
	public Sprite spriteRight,spriteOne,spriteTwo,spriteThree,spriteFour,questionP2,option2_1,option2_2,option2_3,option2_4,
	questionP3,option3_1,option3_2,option3_3,option3_4,questionP4,option4_1,option4_2,option4_3,option4_4,questionP5,option5_1,option5_2,option5_3,option5_4,
	questionP6,option6_1,option6_2,option6_3,option6_4,questionP7,option7_1,option7_2,option7_3,option7_4,questionP8,option8_1,option8_2,option8_3,option8_4,
	questionP9,option9_1,option9_2,option9_3,option9_4,questionP10,option10_1,option10_2,option10_3,option10_4,questionP11,option11_1,option11_2,option11_3,option11_4
	,questionP12,option12_1,option12_2,option12_3,option12_4,questionP13,option13_1,option13_2,option13_3,option13_4,questionP14,option14_1,option14_2,option14_3,option14_4
	,questionP15,option15_1,option15_2,option15_3,option15_4,questionP16,option16_1,option16_2,option16_3,option16_4,questionP17,option17_1,option17_2,option17_3,option17_4
	,questionP18,option18_1,option18_2,option18_3,option18_4,questionP19,option19_1,option19_2,option19_3,option19_4,questionP20,option20_1,option20_2,option20_3,option20_4
	,option21_1,option21_2,option21_3,option21_4,option22_1,option22_2,option22_3,option22_4,option23_1,option23_2,option23_3,option23_4,questionP24,questionP25,questionP26
	,questionP27,questionP28,option29_1,option29_2,option29_3,option29_4,option30_1,option30_2,option30_3,option30_4,option31_1,option31_2,option31_3,option31_4,option32_1,option32_2,option32_3,option32_4
	,option33_1,option33_2,option33_3,option33_4,questionP34,option34_1,option34_2,option34_3,option34_4,questionP35,option35_1,option35_2,option35_3,option35_4
	,questionP36,option36_1,option36_2,option36_3,option36_4,questionP37,option37_1,option37_2,option37_3,option37_4,questionP38,option38_1,option38_2,option38_3,option38_4
	,questionP39,option39_1,option39_2,option39_3,option39_4,questionP40,option40_1,option40_2,option40_3,option40_4,blank,ex6_10,ex11_15,ex16_20,ex21_23,ex24_28,ex29_30,ex31_33,ex34_40;
	public Button buttonOne,buttonTwo,buttonThree,buttonFour,buttonNext,buttonExit,buttonListening,sc0,sc1,sc2,sc3,sc4,sc5,sc6,sc7,sc8,sc9,sc10,sc11,sc12,sc13,sc14,sc15,
	sc16,sc17,sc18,sc19,sc20,sc21,sc22,sc23,sc24,sc25,sc26,sc27,sc28,sc29,sc30,sc31,sc32,sc33,sc34,sc35,sc36,sc37,sc38,sc39,BackScene;
	public Image optionOne, optionTwo, optionThree, optionFour,questionP,example;
	public Dropdown questions;
	public int select = 0,question = 20,minuteLeft=9,listening=0;
	public int[] answer = new int[40];
	public int[] result = new int[40];
	public float timeLeft = 60.0f;

	void Start (){
		s = gameObject.AddComponent<AudioSource>();
		s.clip = intro;
		s.Play ();
		timeLeft = 60.0f;
		question = 20;
		minuteLeft = 9;
		listening = 0;
		listeningView.alpha = 0f;
		listeningView.blocksRaycasts = false;
		listeningView.interactable = false;
		scoreView.alpha = 0f;
		scoreView.blocksRaycasts = false;
		scoreView.interactable = false;
		Button btnOne = buttonOne.GetComponent<Button>();
		Button btnTwo = buttonTwo.GetComponent<Button>();
		Button btnThree = buttonThree.GetComponent<Button>();
		Button btnFour = buttonFour.GetComponent<Button>();
		Button btnNext = buttonNext.GetComponent<Button> ();
		Button btnExit = buttonExit.GetComponent<Button> ();
		Button btnListening = buttonListening.GetComponent<Button> ();
		Button btnBS = BackScene.GetComponent<Button> ();
		Dropdown qIndex = questions.GetComponent<Dropdown> ();
		btnOne.onClick.AddListener (TaskOnClickOne);
		btnTwo.onClick.AddListener (TaskOnClickTwo);
		btnThree.onClick.AddListener (TaskOnClickThree);
		btnFour.onClick.AddListener (TaskOnClickFour);
		btnNext.onClick.AddListener (NextQuestion);
		btnExit.onClick.AddListener (ShowScore);
		btnBS.onClick.AddListener (LoadMain);
		btnListening.onClick.AddListener (goToListening);
		qIndex.onValueChanged.AddListener(delegate{QuestionSelector();});
		LoadResult ();
		StartCoroutine (WaitForAd ());

	}
	void LoadResult(){
		if (SceneManager.GetActiveScene ().name == "test") {
			result = new int[]{ 1, 3, 2, 4, 2, 3, 1, 1, 2, 4, 1, 4, 3, 2, 2, 2, 3, 1, 3, 4, 4, 1, 2, 1, 3, 3, 2, 1, 4, 3, 2, 3, 4, 2, 1, 4, 2, 4, 1, 3 };
		}else if(SceneManager.GetActiveScene ().name == "test_2"){
			result = new int[]{ 2, 3, 2, 4, 1, 3, 2, 4, 1, 3, 2, 3, 4, 1, 3, 1, 4, 2, 4, 1, 1, 2, 3, 2, 3, 1, 3, 2, 2, 1, 4, 3, 1, 2, 4, 4, 2, 4, 1, 2 };
		}else if(SceneManager.GetActiveScene ().name == "test_3"){
			result = new int[]{ 2, 4, 1, 3, 1, 4, 3, 2, 3, 1, 1, 4, 2, 2, 3, 1, 3, 1, 4, 2, 2, 3, 2, 1, 3, 2, 4, 3, 1, 3, 1, 2, 3, 4, 3, 2, 3, 2, 1, 3 };
		}else if(SceneManager.GetActiveScene ().name == "test_4"){
			result = new int[]{ 3, 1, 3, 3, 1, 3, 4, 2, 4, 2, 1, 4, 3, 4, 4, 4, 4, 3, 4, 4, 2, 1, 3, 1, 3, 4, 2, 4, 2, 2, 1, 2, 1, 3, 4, 3, 3, 2, 2, 2 };
		}else if(SceneManager.GetActiveScene ().name == "test_5"){
			result = new int[]{ 3, 1, 4, 2, 1, 2, 3, 4, 1, 3, 2, 3, 4, 1, 3, 2, 4, 2, 3, 4, 3, 2, 1, 3, 1, 3, 2, 4, 2, 1, 1, 3, 1, 4, 2, 4, 3, 2, 1, 2 };
		}else if(SceneManager.GetActiveScene ().name == "test_6"){
			result = new int[]{ 1, 2, 1, 3, 4, 2, 4, 3, 2, 3, 1, 1, 3, 3, 1, 2, 1, 4, 3, 1, 4, 3, 3, 2, 3, 1, 4, 2, 2, 4, 3, 2, 1, 2, 3, 2, 4, 1, 2, 3 };
		}else if(SceneManager.GetActiveScene ().name == "test_7"){
			result = new int[]{ 3, 1, 3, 2, 4, 3, 1, 3, 2, 4, 2, 4, 1, 1, 3, 3, 1, 3, 2, 4, 1, 2, 4, 4, 2, 1, 3, 4, 3, 2, 3, 4, 2, 2, 2, 2, 4, 1, 4, 4 };
		}else if(SceneManager.GetActiveScene ().name == "test_8"){
			result = new int[]{ 1, 2, 3, 1, 4, 2, 3, 4, 2, 4, 2, 3, 3, 2, 2, 1, 3, 1, 1, 3, 1, 4, 3, 2, 1, 2, 3, 4, 4, 1, 3, 1, 3, 4, 1, 4, 2, 1, 2, 4 };
		}else if(SceneManager.GetActiveScene ().name == "test_9"){
			result = new int[]{ 1, 3, 3, 2, 1, 2, 4, 1, 3, 1, 2, 4, 4, 4, 1, 2, 1, 4, 3, 1, 2, 3, 4, 1, 3, 4, 3, 1, 3, 4, 2, 4, 1, 3, 4, 4, 1, 4, 3, 1 };
		}else if(SceneManager.GetActiveScene ().name == "test_10"){
			result = new int[]{ 2, 2, 4, 1, 3, 4, 1, 3, 2, 4, 4, 2, 4, 1, 3, 1, 1, 2, 4, 2, 3, 4, 2, 3, 3, 4, 1, 1, 3, 4, 1, 3, 1, 2, 3, 3, 2, 3, 4, 4 };
		}
	}
	void LoadMain(){
		SceneManager.LoadScene ("startMenu",LoadSceneMode.Single);

	}
	void ShowScore(){
		s.Stop ();
		int score = 0;
		int i;
		string temp="sc";
		for (i = 0; i < 40; i++) {
			if (answer [i] == result [i]) {
				score++;
				temp = temp + i;
				Button tempo = (Button)this.GetType ().GetField (temp).GetValue (this);
				Button btnTemp = tempo.GetComponent<Button> ();
				btnTemp.image.overrideSprite = spriteRight;
				temp = "sc";
			} else {
			}
		}
		score = score * 5;
		scoreText.text="Score: "+score+"/ 200";
		scoreView.alpha = 1f;
		scoreView.blocksRaycasts = true;
		scoreView.interactable = true;
	}
	void goToListening(){
		listening = 1;
		NextQuestion();
	}
	void NextQuestion(){
		if (questions.value == 19) {
			listening = 1;
		}
		if(listening==1){
			question = question+1;
			QuestionNo.text = "Question #" + question;
			if (question == 21) {
				showPanelL ();
				hidePanelD ();
				StartCoroutine (WaitForAd ());
			} else {
				QuestionSelector ();
			}
			if (question == 40) {
				nextView.alpha = 0f;
				nextView.blocksRaycasts = false;
				nextView.interactable = false;
			}
		} else {
			questions.value = 1 + questions.value;
		}
		//QuestionSelector ();
	}

	void TaskOnClickOne(){
		int decider;
		if (question == 20) {
			decider = questions.value;
		} else {
			decider = question-1;
		}
		if (select!=1){
			buttonTwo.image.overrideSprite = null;
			buttonThree.image.overrideSprite = null;
			buttonFour.image.overrideSprite = null;
			// If you want to change the sprite for only a short time,
			// and use a default whenever your condition is false
			buttonOne.image.overrideSprite = spriteOne;
			select = 1;
			answer [decider] = 1;
			// But if you really want the source image,
			// use the following line instead
			// button.image.sprite = newsprite;
		}
		else{
			// Setting the overrideSprite back to null will cause
			// the image to display the original value of image.sprite again
			buttonOne.image.overrideSprite = null;
			select = 0;
			answer [decider] = 0;
		}
	}
	void TaskOnClickTwo(){
		int decider;
		if (question == 20) {
			decider = questions.value;
		} else {
			decider = question-1;
		}
		if (select!=2){
			buttonOne.image.overrideSprite = null;
			buttonThree.image.overrideSprite = null;
			buttonFour.image.overrideSprite = null;
			buttonTwo.image.overrideSprite = spriteTwo;
			select = 2;
			answer [decider] = 2;
		}
		else{
			buttonTwo.image.overrideSprite = null;
			select = 0;
			answer [decider] = 0;
		}
	}
	void TaskOnClickThree(){
		int decider;
		if (question == 20) {
			decider = questions.value;
		} else {
			decider = question-1;
		}
		if (select!=3){
			buttonOne.image.overrideSprite = null;
			buttonTwo.image.overrideSprite = null;
			buttonFour.image.overrideSprite = null;
			buttonThree.image.overrideSprite = spriteThree;
			select = 3;
			answer [decider] = 3;
		}
		else{
			buttonThree.image.overrideSprite = null;
			select = 0;
			answer [decider] = 0;
		}
	}
	void TaskOnClickFour(){
		int decider;
		if (question == 20) {
			decider = questions.value;
		} else {
			decider = question-1;
		}
		if (select!=4){
			buttonOne.image.overrideSprite = null;
			buttonTwo.image.overrideSprite = null;
			buttonThree.image.overrideSprite = null;
			buttonFour.image.overrideSprite = spriteFour;
			select = 4;
			answer [decider] = 4;
		}
		else{
			buttonFour.image.overrideSprite = null;
			select = 0;
			answer [decider] = 0;
		}
	}
	public void showAd(){
		adView.alpha = 1f;
		adView.blocksRaycasts = true;
		adView.interactable = true;
	}
	public void hideAd(){
		adView.alpha = 0f;
		adView.blocksRaycasts = false;
		adView.interactable = false;
	}
	public void showPanelL(){
		listeningView.alpha = 1f;
		listeningView.blocksRaycasts = true;
		listeningView.interactable = true;
		listeningView2.alpha = 0f;
		listeningView2.blocksRaycasts = false;
		listeningView2.interactable = false;
	}
	public void showPanelD(){
		dropdownView.alpha = 1f;
		dropdownView.blocksRaycasts = true;
		dropdownView.interactable = true;
	}
	public void hidePanelL(){
		listeningView.alpha = 0f;
		listeningView.blocksRaycasts = false;
		listeningView.interactable = false;
	}
	public void hidePanelD(){
		dropdownView.alpha = 0f;
		dropdownView.blocksRaycasts = false;
		dropdownView.interactable = false;
	}

	void QuestionSelector(){
		int decider;
		if (question == 20) {
			decider = questions.value;
		} else {
			decider = question-1;
		}
		if (decider == 0) {
			example.overrideSprite = null;
			questionP.overrideSprite = null;
			optionOne.overrideSprite = null;
			optionTwo.overrideSprite = null;
			optionThree.overrideSprite = null;
			optionFour.overrideSprite = null;
		}
		else if (decider == 1) {
			example.overrideSprite = null;
			questionP.overrideSprite = questionP2;
			optionOne.overrideSprite=option2_1;
			optionTwo.overrideSprite = option2_2;
			optionThree.overrideSprite = option2_3;
			optionFour.overrideSprite = option2_4;
		}
		else if (decider == 2) {
			example.overrideSprite = null;
			questionP.overrideSprite = questionP3;
			optionOne.overrideSprite=option3_1;
			optionTwo.overrideSprite = option3_2;
			optionThree.overrideSprite = option3_3;
			optionFour.overrideSprite = option3_4;
		}else if (decider == 3) {
			example.overrideSprite = null;
			questionP.overrideSprite = questionP4;
			optionOne.overrideSprite=option4_1;
			optionTwo.overrideSprite = option4_2;
			optionThree.overrideSprite = option4_3;
			optionFour.overrideSprite = option4_4;
		}else if (decider == 4) {
			example.overrideSprite = null;
			questionP.overrideSprite = questionP5;
			optionOne.overrideSprite=option5_1;
			optionTwo.overrideSprite = option5_2;
			optionThree.overrideSprite = option5_3;
			optionFour.overrideSprite = option5_4;
		}else if (decider == 5) {
			example.overrideSprite = ex6_10;
			questionP.overrideSprite = questionP6;
			optionOne.overrideSprite=option6_1;
			optionTwo.overrideSprite = option6_2;
			optionThree.overrideSprite = option6_3;
			optionFour.overrideSprite = option6_4;
		}else if (decider == 6) {
			example.overrideSprite = ex6_10;
			questionP.overrideSprite = questionP7;
			optionOne.overrideSprite=option7_1;
			optionTwo.overrideSprite = option7_2;
			optionThree.overrideSprite = option7_3;
			optionFour.overrideSprite = option7_4;
		}else if (decider == 7) {
			example.overrideSprite = ex6_10;
			questionP.overrideSprite = questionP8;
			optionOne.overrideSprite=option8_1;
			optionTwo.overrideSprite = option8_2;
			optionThree.overrideSprite = option8_3;
			optionFour.overrideSprite = option8_4;
		}else if (decider == 8) {
			example.overrideSprite = ex6_10;
			questionP.overrideSprite = questionP9;
			optionOne.overrideSprite=option9_1;
			optionTwo.overrideSprite = option9_2;
			optionThree.overrideSprite = option9_3;
			optionFour.overrideSprite = option9_4;
		}else if (decider == 9) {
			example.overrideSprite = ex6_10;
			questionP.overrideSprite = questionP10;
			optionOne.overrideSprite=option10_1;
			optionTwo.overrideSprite = option10_2;
			optionThree.overrideSprite = option10_3;
			optionFour.overrideSprite = option10_4;
		}else if (decider == 10) {
			example.overrideSprite = ex11_15;
			questionP.overrideSprite = questionP11;
			optionOne.overrideSprite=option11_1;
			optionTwo.overrideSprite = option11_2;
			optionThree.overrideSprite = option11_3;
			optionFour.overrideSprite = option11_4;
		}else if (decider == 11) {
			example.overrideSprite = ex11_15;
			questionP.overrideSprite = questionP12;
			optionOne.overrideSprite=option12_1;
			optionTwo.overrideSprite = option12_2;
			optionThree.overrideSprite = option12_3;
			optionFour.overrideSprite = option12_4;
		}else if (decider == 12) {
			example.overrideSprite = ex11_15;
			questionP.overrideSprite = questionP13;
			optionOne.overrideSprite=option13_1;
			optionTwo.overrideSprite = option13_2;
			optionThree.overrideSprite = option13_3;
			optionFour.overrideSprite = option13_4;
		}else if (decider == 13) {
			example.overrideSprite = ex11_15;
			questionP.overrideSprite = questionP14;
			optionOne.overrideSprite=option14_1;
			optionTwo.overrideSprite = option14_2;
			optionThree.overrideSprite = option14_3;
			optionFour.overrideSprite = option14_4;
		}else if (decider == 14) {
			example.overrideSprite = ex11_15;
			questionP.overrideSprite = questionP15;
			optionOne.overrideSprite=option15_1;
			optionTwo.overrideSprite = option15_2;
			optionThree.overrideSprite = option15_3;
			optionFour.overrideSprite = option15_4;
		}else if (decider == 15) {
			example.overrideSprite = ex16_20;
			questionP.overrideSprite = questionP16;
			optionOne.overrideSprite=option16_1;
			optionTwo.overrideSprite = option16_2;
			optionThree.overrideSprite = option16_3;
			optionFour.overrideSprite = option16_4;
		}else if (decider == 16) {
			example.overrideSprite = ex16_20;
			questionP.overrideSprite = questionP17;
			optionOne.overrideSprite=option17_1;
			optionTwo.overrideSprite = option17_2;
			optionThree.overrideSprite = option17_3;
			optionFour.overrideSprite = option17_4;
		}else if (decider == 17) {
			example.overrideSprite = ex16_20;
			questionP.overrideSprite = questionP18;
			optionOne.overrideSprite=option18_1;
			optionTwo.overrideSprite = option18_2;
			optionThree.overrideSprite = option18_3;
			optionFour.overrideSprite = option18_4;
		}else if (decider == 18) {
			example.overrideSprite = ex16_20;
			questionP.overrideSprite = questionP19;
			optionOne.overrideSprite=option19_1;
			optionTwo.overrideSprite = option19_2;
			optionThree.overrideSprite = option19_3;
			optionFour.overrideSprite = option19_4;
		}else if (decider == 19) {
			example.overrideSprite = ex16_20;
			questionP.overrideSprite = questionP20;
			optionOne.overrideSprite=option20_1;
			optionTwo.overrideSprite = option20_2;
			optionThree.overrideSprite = option20_3;
			optionFour.overrideSprite = option20_4;
		}else if (decider == 20) {
			s.clip = qs21;
			s.Play ();
			example.overrideSprite = ex21_23;
			questionP.overrideSprite = blank;
			optionOne.overrideSprite=option21_1;
			optionTwo.overrideSprite = option21_2;
			optionThree.overrideSprite = option21_3;
			optionFour.overrideSprite = option21_4;
		}else if (decider == 21) {
			s.Stop ();
			s.clip = qs22;
			s.Play ();
			example.overrideSprite = ex21_23;
			questionP.overrideSprite = blank;
			optionOne.overrideSprite=option22_1;
			optionTwo.overrideSprite = option22_2;
			optionThree.overrideSprite = option22_3;
			optionFour.overrideSprite = option22_4;
		}else if (decider == 22) {
			s.Stop ();
			s.clip = qs23;
			s.Play ();
			example.overrideSprite = ex21_23;
			questionP.overrideSprite = blank;
			optionOne.overrideSprite=option23_1;
			optionTwo.overrideSprite = option23_2;
			optionThree.overrideSprite = option23_3;
			optionFour.overrideSprite = option23_4;
		}else if (decider == 23) {
			s.Stop ();
			s.clip = qs24;
			s.Play ();
			example.overrideSprite = ex24_28;
			questionP.overrideSprite = questionP24;
			optionOne.overrideSprite=blank;
			optionTwo.overrideSprite = blank;
			optionThree.overrideSprite = blank;
			optionFour.overrideSprite = blank;
		}else if (decider == 24) {
			s.Stop ();
			s.clip = qs25;
			s.Play ();
			example.overrideSprite = ex24_28;
			questionP.overrideSprite = questionP25;
			optionOne.overrideSprite=blank;
			optionTwo.overrideSprite = blank;
			optionThree.overrideSprite = blank;
			optionFour.overrideSprite = blank;
		}else if (decider == 25) {
			s.Stop ();
			s.clip = qs26;
			s.Play ();
			example.overrideSprite = ex24_28;
			questionP.overrideSprite = questionP26;
			optionOne.overrideSprite=blank;
			optionTwo.overrideSprite = blank;
			optionThree.overrideSprite = blank;
			optionFour.overrideSprite = blank;
		}else if (decider == 26) {
			s.Stop ();
			s.clip = qs27;
			s.Play ();
			example.overrideSprite = ex24_28;
			questionP.overrideSprite = questionP27;
			optionOne.overrideSprite=blank;
			optionTwo.overrideSprite = blank;
			optionThree.overrideSprite = blank;
			optionFour.overrideSprite = blank;
		}else if (decider == 27) {
			s.Stop ();
			s.clip = qs28;
			s.Play ();
			example.overrideSprite = ex24_28;
			questionP.overrideSprite = questionP28;
			optionOne.overrideSprite=blank;
			optionTwo.overrideSprite = blank;
			optionThree.overrideSprite = blank;
			optionFour.overrideSprite = blank;
		}else if (decider == 28) {
			s.Stop ();
			s.clip = qs29;
			s.Play ();
			example.overrideSprite = ex29_30;
			questionP.overrideSprite = blank;
			optionOne.overrideSprite=option29_1;
			optionTwo.overrideSprite = option29_2;
			optionThree.overrideSprite = option29_3;
			optionFour.overrideSprite = option29_4;
		}else if (decider == 29) {
			s.Stop ();
			s.clip = qs30;
			s.Play ();
			example.overrideSprite = ex29_30;
			questionP.overrideSprite = blank;
			optionOne.overrideSprite=option30_1;
			optionTwo.overrideSprite = option30_2;
			optionThree.overrideSprite = option30_3;
			optionFour.overrideSprite = option30_4;
		}else if (decider == 30) {
			s.Stop ();
			s.clip = qs31;
			s.Play ();
			example.overrideSprite = ex31_33;
			questionP.overrideSprite = blank;
			optionOne.overrideSprite=option31_1;
			optionTwo.overrideSprite = option31_2;
			optionThree.overrideSprite = option31_3;
			optionFour.overrideSprite = option31_4;
		}else if (decider == 31) {
			s.Stop ();
			s.clip = qs32;
			s.Play ();
			example.overrideSprite = ex31_33;
			questionP.overrideSprite = blank;
			optionOne.overrideSprite=option32_1;
			optionTwo.overrideSprite = option32_2;
			optionThree.overrideSprite = option32_3;
			optionFour.overrideSprite = option32_4;
		}else if (decider == 32) {
			s.Stop ();
			s.clip = qs33;
			s.Play ();
			example.overrideSprite = ex31_33;
			questionP.overrideSprite = blank;
			optionOne.overrideSprite=option33_1;
			optionTwo.overrideSprite = option33_2;
			optionThree.overrideSprite = option33_3;
			optionFour.overrideSprite = option33_4;
		}else if (decider == 33) {
			s.Stop ();
			s.clip = qs34;
			s.Play ();
			example.overrideSprite = ex34_40;
			questionP.overrideSprite = questionP34;
			optionOne.overrideSprite=option34_1;
			optionTwo.overrideSprite = option34_2;
			optionThree.overrideSprite = option34_3;
			optionFour.overrideSprite = option34_4;
		}else if (decider == 34) {
			s.Stop ();
			s.clip = qs35;
			s.Play ();
			example.overrideSprite = ex34_40;
			questionP.overrideSprite = questionP35;
			optionOne.overrideSprite=option35_1;
			optionTwo.overrideSprite = option35_2;
			optionThree.overrideSprite = option35_3;
			optionFour.overrideSprite = option35_4;
		}else if (decider == 35) {
			s.Stop ();
			s.clip = qs36;
			s.Play ();
			example.overrideSprite = ex34_40;
			questionP.overrideSprite = questionP36;
			optionOne.overrideSprite=option36_1;
			optionTwo.overrideSprite = option36_2;
			optionThree.overrideSprite = option36_3;
			optionFour.overrideSprite = option36_4;
		}else if (decider == 36) {
			s.Stop ();
			s.clip = qs37;
			s.Play ();
			example.overrideSprite = ex34_40;
			questionP.overrideSprite = questionP37;
			optionOne.overrideSprite=option37_1;
			optionTwo.overrideSprite = option37_2;
			optionThree.overrideSprite = option37_3;
			optionFour.overrideSprite = option37_4;
		}else if (decider == 37) {
			s.Stop ();
			s.clip = qs38;
			s.Play ();
			example.overrideSprite = ex34_40;
			questionP.overrideSprite = questionP38;
			optionOne.overrideSprite=option38_1;
			optionTwo.overrideSprite = option38_2;
			optionThree.overrideSprite = option38_3;
			optionFour.overrideSprite = option38_4;
		}else if (decider == 38) {
			s.Stop ();
			s.clip = qs39;
			s.Play ();
			example.overrideSprite = ex34_40;
			questionP.overrideSprite = questionP39;
			optionOne.overrideSprite=option39_1;
			optionTwo.overrideSprite = option39_2;
			optionThree.overrideSprite = option39_3;
			optionFour.overrideSprite = option39_4;
		}else if (decider == 39) {
			s.Stop ();
			s.clip = qs40;
			s.Play ();
			example.overrideSprite = ex34_40;
			questionP.overrideSprite = questionP40;
			optionOne.overrideSprite=option40_1;
			optionTwo.overrideSprite = option40_2;
			optionThree.overrideSprite = option40_3;
			optionFour.overrideSprite = option40_4;
		}
		questionP.preserveAspect=true;
		optionOne.preserveAspect=true;
		optionTwo.preserveAspect=true;
		optionThree.preserveAspect=true;
		optionFour.preserveAspect=true;
		buttonOne.image.overrideSprite = null;
		buttonTwo.image.overrideSprite = null;
		buttonThree.image.overrideSprite = null;
		buttonFour.image.overrideSprite = null;
		select = 0;
		if (answer [decider] == 1) {
			buttonOne.image.overrideSprite = spriteOne;
			select = 1;
		}else if (answer [decider] == 2) {
			buttonTwo.image.overrideSprite = spriteTwo;
			select = 2;
		}else if (answer [decider] == 3) {
			buttonThree.image.overrideSprite = spriteThree;
			select = 3;
		}else if (answer [decider] == 4) {
			buttonFour.image.overrideSprite = spriteFour;
			select = 4;
		}
	}

	IEnumerator WaitForAd(){
		showAd ();
		yield return new WaitForSeconds (5);
		hideAd ();
		timeLeft = 59;
		minuteLeft = 9;
		QuestionSelector ();
	}

	void Update (){
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0) {
			if (minuteLeft != 0) {
				minuteLeft--;
				timeLeft = 59.9f;
			} else {
				ShowScore ();
			}
		}
		if (timeLeft < 10) {
			TimerText.text = minuteLeft + ":0" + (int)timeLeft;
		} else {
			TimerText.text = minuteLeft + ":" + (int)timeLeft;
		}
	}
}