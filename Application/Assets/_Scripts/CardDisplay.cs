using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

	public Card card;
	public Text description;
	public Text	level;

	private GameObject player;
	private PlayerScript playerScript;

	private bool cardToggle = false;
	private bool cardPlayed;
	private Vector3 initPosition;
	private int index;

	// Use this for initialization
	void Start () {
		playerScript = player.GetComponent<PlayerScript> ();

		description.text = card.description;
		level.text = card.level.ToString ();
		initPosition = transform.position;
	}

	public void setCard(Card card){
		this.card = card;
	}

	public void setPlayer(GameObject player){
		this.player = player;
	}

	public void setIndex(int index){
		this.index = index;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter()
	{
		if (!cardToggle) {
			transform.Translate (new Vector3 (0, 100, 0));
		}
	}

	void OnMouseExit()
	{
		if (!cardToggle) {
			transform.Translate (new Vector3 (0, -100, 0));
		}
	}

	void OnMouseDown()
	{
		
		if(playerScript.getCardInMid() == false){
			if (!cardToggle) {
				transform.position = new Vector3(0, 50, 0);
				playerScript.setPlayedCard (card, index);
				playerScript.setPlayedGameObject (this.gameObject);
				playerScript.setCardInMid (true);
				cardToggle = !cardToggle;
			}
		} else if (cardToggle){
			transform.position = initPosition;
			transform.Translate (new Vector3 (0, 100, 0));
			playerScript.setPlayedCard (null, 0);
			playerScript.setCardInMid (false);
			cardToggle = !cardToggle;
		}

	}

	public void destroyCard(){
		Destroy (this);
	}
}
