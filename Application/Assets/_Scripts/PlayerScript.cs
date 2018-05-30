using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour {

	public int playerNumber;
	public bool isTurn;
	public GameObject card;
	public Canvas canvas;



	public TextMeshProUGUI geldText;
	public TextMeshProUGUI einflussText;
	public TextMeshProUGUI ansehenText;
	public TextMeshProUGUI cardCountText;


	public GameObject decks;
	public GameObject playerStats;
	public GameObject game;
	private Decks decksScript;
	private PlayerStats playerStatsScript;
	private GameScript gameScript;

	private List<Card> deck;
	private Card playedCard;
	private bool cardInMid = false;
	private string fraktion;
	private int cardCount = 0;
	private GameObject newCard;
	private CardDisplay cardDisplayScript;
	private int cardNumber;
	private GameObject playedGameObject;
	private Vector3 position1 = new Vector3(-256, -490, 0);
	private Vector3 position2 = new Vector3(27, -490, 0);
	private Vector3 position3 = new Vector3(310, -490, 0);
	private bool position1Free = true;
	private bool position2Free = true;
	private bool position3Free = true;
	private Quaternion rotation1 =  Quaternion.Euler(0, 0, 0);
	private Quaternion rotation2 =  Quaternion.Euler(0, 0, 0);
	private Quaternion rotation3 =  Quaternion.Euler(0, 0, 0);




	// Use this for initialization
	void Start () {
		playerStatsScript = playerStats.GetComponent<PlayerStats>();
		decksScript = decks.GetComponent<Decks> ();
		gameScript = game.GetComponent<GameScript> ();

		fraktion = playerStatsScript.fraktion;
		if (fraktion == "Regierung") {
			deck = new List<Card>(decksScript.getRegierung());
		}
		this.startTurn ();
	}

	void startTurn() {
		StartCoroutine(drawCards());
	}

	public void endTurn(){
		if (playedCard != null) {
			cardCount--;
			GameScript.playedCards.Add (playedCard);
			this.updateLocalStats ();
			Destroy (playedGameObject);
			cardInMid = false;
			StartCoroutine(drawCards());
		} else {
//			getMoney ();
		}

		gameScript.endTurn ();
	}

	public void setPlayedGameObject(GameObject playedGameObject){
		this.playedGameObject = playedGameObject;
	}

		
	public List<Card> getDeck(){
		return this.deck;
	}

	public void setPlayedCard(Card card, int index){
		this.playedCard = card;
		if (index == 1) {
			position1Free = true;
		}
		if (index == 2) {
			position2Free = true;
		}
		if (index == 3) {
			position3Free = true;
		}
	}

	public Card getPlayedCard(){
		return playedCard;
	}

	public void setCardInMid(bool cardInMid){
		this.cardInMid = cardInMid;
	}

	public bool getCardInMid(){
		return cardInMid;
	}


	void updateLocalStats(){
		PlayerStats.geld += playedCard.geld;
		PlayerStats.ansehen += playedCard.ansehen;
		PlayerStats.einfluss += playedCard.einfluss;

		geldText.text = PlayerStats.geld.ToString ();
		ansehenText.text = PlayerStats.ansehen.ToString ();
		einflussText.text = PlayerStats.einfluss.ToString ();
	}

	void generateCard(){
		if (this.deck.Count > 0) {
			cardNumber = Random.Range (0, deck.Count);

			if (position1Free == true) {
				newCard = Instantiate (this.card, position1, rotation1) as GameObject;
				cardDisplayScript = newCard.GetComponent<CardDisplay> ();
				cardDisplayScript.setIndex (1);
				position1Free = false;
			} else if (position2Free == true) {
				newCard = Instantiate (this.card, position2, rotation2) as GameObject;
				cardDisplayScript = newCard.GetComponent<CardDisplay> ();
				cardDisplayScript.setIndex (2);
				position2Free = false;
			} else if (position3Free == true) {
				newCard = Instantiate (this.card, position3, rotation3) as GameObject;
				cardDisplayScript = newCard.GetComponent<CardDisplay> ();
				cardDisplayScript.setIndex (3);
				position3Free = false;
			}
			cardDisplayScript.setCard (deck [cardNumber]);
			cardDisplayScript.setPlayer (this.gameObject);
			newCard.GetComponent<Transform> ().SetParent (canvas.transform);
			deck.RemoveAt (cardNumber);
		} else {
			print ("keine karten mehr");
		}
	}

	IEnumerator drawCards() {
		while (cardCount < 3) {
			yield return new WaitForSeconds(1);
			this.generateCard ();
			cardCount++;
			cardCountText.text = deck.Count.ToString ();
		}
	}
}
