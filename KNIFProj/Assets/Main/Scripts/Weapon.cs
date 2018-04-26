using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : MonoBehaviour {

	public int id;
	public string weaponName;
	public int minDamage;
	public int maxDamage;
	public int rarity;
	public int quality;

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
		return dto;
	}
	

}
