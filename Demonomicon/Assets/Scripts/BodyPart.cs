using UnityEngine;
using System.Collections;

public class BodyPart {
	public string name;
	public int hp;
	public int offense;
	public int defense;
	public float temperament;
	//types: flesh -> iron -> ice -> flesh
	public int flesh;
	public int iron;
	public int ice;
	//event-changing boolean types
	public bool flight;
	public bool sight;
	public bool iq;
	public bool charm;
	public Skill[] skills;
	public float[] skill_probs;
}
