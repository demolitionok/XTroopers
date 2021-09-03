using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hero/Config")]
public class HeroProp : ScriptableObject
{
	public bool isDead = false;
	public string hiroName;
	public int lvl = 1;
	public int health;
	public int defense;
	public int magicRes;
	public int damage;
	public int critVer;
	public int critMultiple;
	public int exp;
	public string hiroType;
}
