using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardManager : MonoBehaviour {

	//Cards
	private bool anyCardGreen = false;
	private bool anyCardRed = false;
	private CardScript playCard;
	private CardScript dropCard;
	private int playCardIndex;
	private int dropCardIndex;
	private List<CardScript> sellCards = new List<CardScript> ();
	private List<int> sellCardsIndexes = new List<int> ();

	//GUI
	public TextMeshProUGUI statusText;
	public GameObject statusFrame;
	public GameObject sellModeObject;

	private bool sellMode = false;

	public PlayerManager playerManager;


	public void onClick (CardScript card){
		if (!sellMode) {
			if (card.getGreen ()) {
				anyCardGreen = false;
				card.toggleGreen ();
				playCard = null;
			} else if (card.getRed ()) {
				anyCardRed = false;
				card.toggleRed ();
				dropCard = null;
			} else if (!anyCardGreen) {
				if (checkPlayable (card)) {
					anyCardGreen = true;
					card.toggleGreen ();
					playCard = card;
					playCardIndex = card.getPositionIndex ();
				}
			} else if (!anyCardRed) {
				anyCardRed = true;
				card.toggleRed ();
				dropCard = card;
				dropCardIndex = card.getPositionIndex ();
			} 
		} else if (sellMode) {
			if (card.red) {
				print (card.getPositionIndex ());
				sellCardsIndexes.Remove (card.getPositionIndex());
				sellCards.Remove (card);
			} else {
				sellCards.Add (card);
				sellCardsIndexes.Add (card.getPositionIndex());
			}
			card.toggleRed ();
		}
	}

	private bool checkPlayable(CardScript card) {
		if (PlayerManager.ansehen >= card.getCard ().vorraussetzungAnsehen) {
			if (PlayerManager.geld >= card.getCard ().vorraussetzungGeld) {
				if (PlayerManager.einfluss >= card.getCard ().vorraussetzungEinfluss) {
					return true;
				} else {
					statusText.text = "Nicht genug Einfluss";
					StartCoroutine(displayStatus(false));
					return false;
				}
			} else {
				statusText.text = "Nicht genug Geld";
				StartCoroutine(displayStatus(true));
				return false;
			}
		} else {
			statusText.text = "Nicht genug Ansehen";
			StartCoroutine(displayStatus(false));
			return false;
		}
	}

	IEnumerator displayStatus(bool highlightSellMode) {
		statusFrame.SetActive(true);
		if (highlightSellMode) {
			sellModeObject.GetComponent<Image> ().enabled = true;
		}
		yield return new WaitForSeconds(3);
		statusFrame.SetActive(false);
		sellModeObject.GetComponent<Image> ().enabled = false;
	}

	public void resetCardIndexes(){
		playCardIndex = 0;
		dropCardIndex = 0;
		sellCardsIndexes = new List<int> ();
	}

	public bool canEndTurn () {
		if ((playCard != null && dropCard != null) || (sellCards.Count >= 1)) {
			
			return true;
		}	
		return false;
	}

	public void toggleSellMode() {
		sellMode = !sellMode;
		resetCardIndexes ();
		resetCardPosition ();
		sellCards = new List<CardScript>();
		playCard = null;
		dropCard = null;
	}

	private void resetCardPosition(){
		foreach (GameObject card in playerManager.getHandCardObjects ()) {
			if (card.GetComponent<CardScript> ().getRed ()) {
				card.GetComponent<CardScript> ().toggleRed ();
				card.transform.Translate (new Vector3 (0, -100, 0));
				anyCardRed = false;
			} else if (card.GetComponent<CardScript> ().getGreen()){
				card.GetComponent<CardScript> ().toggleGreen();
				card.transform.Translate (new Vector3 (0, -100, 0));
				anyCardGreen = false;
			}
		};
	}

	//Getter/Setter
	public bool getSellMode(){
		return sellMode;
	}

	public CardScript getPlayCard() {
		return playCard;
	}

	public CardScript getDropCard() {
		return dropCard;
	}

	public List<CardScript> getSellCards() {
		return sellCards;
	}

	public void setPlayCard(CardScript playCard) {
		this.playCard = playCard;
	}

	public void setDropCard(CardScript dropCard) {
		this.dropCard = dropCard;
	}

	public void setSellCards(List<CardScript> sellCards){
		this.sellCards = sellCards;
	}

	public void setAnyCardGreen (bool anyCardGreen){
		this.anyCardGreen = anyCardGreen;
	}

	public void setAnyCardRed (bool anyCardRed){
		this.anyCardRed = anyCardRed;
	}

	public int getPlayCardIndex() {
		return playCardIndex;
	}

	public int getDropCardIndex() {
		return dropCardIndex;
	}

	public int getSellCardIndex(int i){
		try {
			print (sellCardsIndexes[i]);
			return sellCardsIndexes [i];
		} catch {
			return -1;
		}
	}
}
