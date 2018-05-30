using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

	//References
	private GameObject player;
	private PlayerScript playerScript;

	//GUI
	public Card card;
	public Text description;
	public Text	level;

	//card
	private bool cardToggle = false;
	private bool cardPlayed;
	private Vector3 initPosition;
	private int index;

	// Use this for initialization
	void Start () {
		initReferences ();
		initCard ();
	}

	void initReferences() {
		playerScript = player.GetComponent<PlayerScript> ();
	}

	void initCard() {
		description.text = card.description;
		level.text = card.level.ToString ();

		initPosition = transform.position;
	}
		
	//Eventlistener
	void OnMouseEnter() {
		if (!cardToggle) {
			transform.Translate (new Vector3 (0, 100, 0));
		}
	}

	void OnMouseExit() {
		if (!cardToggle) {
			transform.Translate (new Vector3 (0, -100, 0));
		}
	}

	void OnMouseDown() {
		if(playerScript.getCardInMid() == false) {
			if (!cardToggle) {
				transform.position = new Vector3(0, 50, 0);
				playerScript.setPlayedCard (card, index);
				playerScript.setPlayedGameObject (this.gameObject);
				playerScript.setCardInMid (true);
				cardToggle = !cardToggle;
			}
		} else if (cardToggle) {
			transform.position = initPosition;
			transform.Translate (new Vector3 (0, 100, 0));
			playerScript.setPlayedCard (null, index);
			playerScript.setCardInMid (false);
			cardToggle = !cardToggle;
		}
	}

	//setter/getter
	public void setCard(Card card) {
		this.card = card;
	}

	public void setPlayer(GameObject player) {
		this.player = player;
	}

	public void setIndex(int index) {
		this.index = index;
	}
}
