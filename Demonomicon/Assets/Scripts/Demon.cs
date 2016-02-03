using UnityEngine;
using System.Collections;

public class Demon {
	public string name;
	// Demon is built up of BodyPart's
	public BodyPart head;
	public BodyPart body;
	public BodyPart legs;
	public BodyPart appendages;
	public BodyPart decor;

	// generated from BodyPart's
	public int hp;
	public int maxHp;
	public int offense;
	public int defense;
	public float temperament;
	//types: flesh -> iron -> ice -> flesh
	public int flesh;
	public int iron;
	public int ice;
	//event-changing boolean types
	public bool flight = false;
	public bool sight = false;
	public bool iq = false;
	public bool charm = false;
	public Skill[] skills;

	public Demon(BodyPart _head, BodyPart _body, BodyPart _legs,
		BodyPart _appendages, BodyPart _decor)
	{
		head = _head;
		body = _body;
		legs = _legs;
		appendages = _appendages;
		decor = _decor;

		//build up other attributes
		hp = head.hp + body.hp + legs.hp + appendages.hp + decor.hp;
		offense = head.offense + body.offense + legs.offense + 
			appendages.offense + decor.offense;
		defense = head.defense + body.defense + legs.defense + 
			appendages.defense + decor.defense;
		//TODO: same for other attributes, including flesh/iron/ice
		//...
		maxHp = hp;
		flight = head.flight || body.flight || legs.flight || 
			appendages.flight || decor.flight;
		sight = head.sight || body.sight || legs.sight || 
			appendages.sight || decor.sight;
		iq = head.iq || body.iq || legs.iq || appendages.iq || decor.iq;
		charm = head.charm || body.charm || legs.charm || appendages.charm || 
			decor.charm;

		//determine skills randomly
		//TODO: rand() 0-1 and determine skill from each BodyPart


	}
}
