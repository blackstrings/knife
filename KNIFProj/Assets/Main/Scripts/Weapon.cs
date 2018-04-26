using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : MonoBehaviour {

	//whitelisted
	public int id;
	public int rarity;
	public int quality;
	public int max_durability;

	// not yet white listed or exist
	public string weaponName;	// cannot use name as name is already taken for gameObject
	public int minDamage;
	public int maxDamage;

	public int max_quality;

	// Use this for initialization
	void Start () {
		
	}

	/// <summary>
	/// Deserialize from dto
	/// </summary>
	/// <param name="dto">Dto.</param>
	public void loadFromDTO(WeaponDTO dto){
		id = dto.id;
		weaponName = dto.name;
		rarity = dto.rarity;
		minDamage = dto.minDamage;
		maxDamage = dto.maxDamage;
		quality = dto.quality;
		max_durability = dto.max_durability;
	}

	/// <summary>
	/// Serialize this instance and return a weaponDTO
	/// </summary>
	public WeaponDTO serialize(){
		WeaponDTO dto = new WeaponDTO ();
		dto.id = id;
		dto.name = name;
		dto.rarity = rarity;
		dto.minDamage = minDamage;
		dto.maxDamage = maxDamage;
		dto.quality = quality;
		dto.max_durability = max_durability;
		return dto;
	}
	

}
