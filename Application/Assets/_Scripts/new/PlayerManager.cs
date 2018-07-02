using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour {
	
	public enum Fraktion {Regierung, Unternehmen, Umweltschutz, Forschungsinstitut};
	public Fraktion fraktion;
	public Decks decks;
	//GUI
	public TextMeshProUGUI cardCountText;
	public TextMeshProUGUI geldText;
	public TextMeshProUGUI einflussText;
	public TextMeshProUGUI ansehenText;
	public Canvas canvas;

	//Card Settings
	private Vector3 position1 = new Vector3(-140, -210, 0);
	private Vector3 position2 = new Vector3(0, -210, 0);
	private Vector3 position3 = new Vector3(140, -210, 0);
	private bool position1Free = true;
	private bool position2Free = true;
	private bool position3Free = true;
	private Quaternion rotation1 =  Quaternion.Euler(0, 0, 0);
	private Quaternion rotation2 =  Quaternion.Euler(0, 0, 0);
	private Quaternion rotation3 =  Quaternion.Euler(0, 0, 0);
	private GameObject newCard;

	//statics
	public static int geld = 0;
	public static int ansehen = 0;
	public static int einfluss = 0;
	public static List<GameObject> handCardObjects = new List<GameObject>();

	//references
	public CardManager cardManager;
	public GlobalManager globalManager;
	public GameObject cardPrefab;
	private CardScript cardScript;
	public LocalParamsManager localParamsManager;

	private List<Card> playerDeck = new List<Card> ();
	private int handCardCount = 0;

	void Start() {
		initPlayer ();
		startTurn ();
		updateLocalStats ();
	}

	private void initPlayer(){
		playerDeck = new List<Card> (decks.getPlayerDeck0 (fraktion));
	}

	private void startTurn(){
		StartCoroutine(drawCards());
		cardManager.resetCardIndexes();
	}

	public void endTurn(){
		if (cardManager.canEndTurn ()) {
			if (cardManager.getSellMode ()) {
				handleSellMode ();
			} else {
				updateLocalStats ();
				handlePlayCard ();
				handleDropCard ();
			}
			globalManager.endTurn ();
			localParamsManager.updateLayer ();
			openPositions ();
			StartCoroutine(drawCards());
		} else {
			print ("Can not end turn");
		}
	}

	private void handlePlayCard(){
		if (cardManager.getPlayCard()) {
			handCardCount--;
			globalManager.getPlayedCards().Add (cardManager.getPlayCard());
			Destroy (cardManager.getPlayCard().gameObject);
			PlayerManager.handCardObjects.Remove(cardManager.getPlayCard().gameObject);
			cardManager.setPlayCard(null);
			cardManager.setAnyCardGreen(false);
		}
	}

	private void handleDropCard(){
		if (cardManager.getDropCard()) {
			handCardCount--;
			Destroy (cardManager.getDropCard().gameObject);
			PlayerManager.handCardObjects.Remove (cardManager.getDropCard().gameObject);
			cardManager.setDropCard(null);
			cardManager.setAnyCardRed(false);
		}
	}

	private void handleSellMode(){
		if (cardManager.getSellCards().Count != 0) {
			handCardCount -= cardManager.getSellCards().Count;
			foreach (CardScript sellCard in cardManager.getSellCards()){
				PlayerManager.geld += 1;
				geldText.text = PlayerManager.geld.ToString ();
				switch (sellCard.getPositionIndex()) {
				case 1: 
					position1Free = true;
					break;
				case 2: 
					position2Free = true;
					break;
				case 3:
					position3Free = true;
					break;
				default:
					break;
				}
				Destroy(sellCard.gameObject);
				PlayerManager.handCardObjects.Remove (sellCard.gameObject);
			}
			cardManager.setSellCards(new List<CardScript>());
		}
	}

	private void openPositions(){
		if (cardManager.getPlayCardIndex() == 1 || cardManager.getDropCardIndex() == 1) {
			position1Free = true;
		} 
		if (cardManager.getPlayCardIndex() == 2 || cardManager.getDropCardIndex() == 2) {
			position2Free = true;
		}
		if (cardManager.getPlayCardIndex() == 3 || cardManager.getDropCardIndex() == 3) {
			position3Free = true;
		}
	}

	private void updateLocalStats() {
		if (cardManager.getPlayCard () != null) {
			PlayerManager.geld += cardManager.getPlayCard ().getCard ().geld;
			PlayerManager.ansehen += cardManager.getPlayCard ().getCard ().ansehen;
			PlayerManager.einfluss += cardManager.getPlayCard ().getCard ().einfluss;
		}
		geldText.text = PlayerManager.geld.ToString ();
		ansehenText.text = PlayerManager.ansehen.ToString ();
		einflussText.text = PlayerManager.einfluss.ToString ();
	}
		
	IEnumerator drawCards() {
		while (handCardCount < 3) {
			yield return new WaitForSeconds(1);
			this.drawCard ();
			handCardCount++;
			cardCountText.text = playerDeck.Count.ToString ();
		}
	}

	private void drawCard() {
		if (playerDeck.Count > 0) {
			int cardNumber = Random.Range (0, playerDeck.Count);
			if (position1Free == true) {
				newCard = Instantiate (cardPrefab, position1, rotation1) as GameObject;
				cardScript = newCard.GetComponent<CardScript> ();
				cardScript.setCardManager (cardManager);
				cardScript.setPositionIndex (1);
				position1Free = false;
			} else if (position2Free == true) {
				newCard = Instantiate (cardPrefab, position2, rotation2) as GameObject;
				cardScript = newCard.GetComponent<CardScript> ();
				cardScript.setCardManager (cardManager);
				cardScript.setPositionIndex (2);
				position2Free = false;
			} else if (position3Free == true) {
				newCard = Instantiate (cardPrefab, position3, rotation3) as GameObject;
				cardScript = newCard.GetComponent<CardScript> ();
				cardScript.setCardManager (cardManager);
				cardScript.setPositionIndex (3);
				position3Free = false;
			}
			cardScript.setCard (playerDeck [cardNumber]);
			newCard.GetComponent<Transform> ().SetParent (canvas.transform);
			playerDeck.RemoveAt (cardNumber);
			PlayerManager.handCardObjects.Add (newCard);
		} else {
			if (GlobalManager.gameRound < 3) {
				playerDeck = new List<Card> (decks.getPlayerDeck0 (fraktion));
			} else if (GlobalManager.gameRound < 6) {
				playerDeck = new List<Card> (decks.getPlayerDeck0 (fraktion));
				playerDeck.AddRange (decks.getPlayerDeck1 (fraktion));
			} else {
				playerDeck = new List<Card> (decks.getPlayerDeck0 (fraktion));
				playerDeck.AddRange (decks.getPlayerDeck1 (fraktion));
			}
			drawCard ();
		}
	}

	//Getter/Setter

	public List<GameObject> getHandCardObjects(){
		return handCardObjects;
	}
}
