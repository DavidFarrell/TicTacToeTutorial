using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text[] buttonList;

	public GameObject gameOverPanel;
	public Text gameOverText;
	public GameObject restartButton;

	private string playerSide;
	private int moveCount;


	public void Awake() {
		SetGameControllerReferenceOnButtons ();
		playerSide = "X";
		gameOverPanel.SetActive (false);
		moveCount = 0;
		restartButton.SetActive (false);

	}

	public void SetGameControllerReferenceOnButtons () {
		for (int i = 0; i < buttonList.Length; i++) {
			// we want to let the parent of the text item know about 'this'
			buttonList[i].GetComponentInParent<GridSpace>().setGameController(this);
		}
	}

	public string GetPlayerSide() {
		return playerSide;
	}

	public void EndTurn() {

		if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide) {
			GameOver ();
		} else if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide) {
			GameOver ();
		} else if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide) {
			GameOver ();
		} else if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide) {
			GameOver ();
		} else if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide) {
			GameOver ();
		} else if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide) {
			GameOver ();
		} else if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide) {
			GameOver ();
		} else if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide) {
			GameOver ();
		} else {

			moveCount++;
			if (moveCount >= 9) {
				GameOver (true);
			}
			ChangeSides ();
		}
	}


	void GameOver(bool draw = false) {
		for (int i = 0; i < buttonList.Length; i++)	{
			buttonList [i].GetComponentInParent<Button> ().interactable = false;
		}

		if (!draw) {
			gameOverText.text = playerSide + " Wins!";
		} else {
			gameOverText.text = "Draw Game!";
		}

		gameOverPanel.SetActive (true);

		restartButton.SetActive (true);
	}

	void ChangeSides() {
		playerSide = (playerSide == "X") ? "O" : "X";
	}

	public void RestartGame() {
		playerSide = "X";
		moveCount = 0;
		gameOverPanel.SetActive (false);

		restartButton.SetActive (false);

		for (int i = 0; i < buttonList.Length; i++)	{
			buttonList [i].GetComponentInParent<Button> ().interactable = true;
			buttonList [i].text = "";
		}
	}

}
