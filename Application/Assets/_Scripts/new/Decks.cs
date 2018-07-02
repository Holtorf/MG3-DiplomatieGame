using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decks : MonoBehaviour {

	public List<Card> regierung0;
	public List<Card> regierung1;
	public List<Card> forschungsinstitut;
	public List<Card> umweltschutz;
	public List<Card> unternehmen0;
	public List<Card> unternehmen1;

	public List<Card> getPlayerDeck0(PlayerManager.Fraktion fraktion){
		switch (fraktion) {
		case PlayerManager.Fraktion.Regierung:
			return regierung0;
		case PlayerManager.Fraktion.Forschungsinstitut:
			return forschungsinstitut;
		case PlayerManager.Fraktion.Umweltschutz:
			return umweltschutz;
		case PlayerManager.Fraktion.Unternehmen:
			return unternehmen0;
		default:
			return new List<Card> ();
		}
	}

	public List<Card> getPlayerDeck1(PlayerManager.Fraktion fraktion){
		switch (fraktion) {
		case PlayerManager.Fraktion.Regierung:
			return regierung1;
		case PlayerManager.Fraktion.Forschungsinstitut:
			return forschungsinstitut;
		case PlayerManager.Fraktion.Umweltschutz:
			return umweltschutz;
		case PlayerManager.Fraktion.Unternehmen:
			return unternehmen1;
		default:
			return new List<Card> ();
		}
	}
}
