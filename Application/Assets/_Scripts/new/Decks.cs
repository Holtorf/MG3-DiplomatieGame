using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decks : MonoBehaviour {

	public List<Card> regierung0;
	public List<Card> regierung1;
	public List<Card> forschungsinstitut0;
	public List<Card> forschungsinstitut1;
	public List<Card> umweltschutz0;
	public List<Card> umweltschutz1;
	public List<Card> unternehmen0;
	public List<Card> unternehmen1;

	public List<Card> getPlayerDeck0(PlayerManager.Fraktion fraktion){
		switch (fraktion) {
		case PlayerManager.Fraktion.Regierung:
			return regierung0;
		case PlayerManager.Fraktion.Forschungsinstitut:
			return forschungsinstitut0;
		case PlayerManager.Fraktion.Umweltschutz:
			return umweltschutz0;
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
			return forschungsinstitut1;
		case PlayerManager.Fraktion.Umweltschutz:
			return umweltschutz1;
		case PlayerManager.Fraktion.Unternehmen:
			return unternehmen1;
		default:
			return new List<Card> ();
		}
	}
}
