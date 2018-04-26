[System.Serializable]  
public class WeaponDTO {

	// do not user the get; set; shorcut, as json utility breaks when used
	public string name;
	public int id;
	public int minDamage;
	public int maxDamage;
	public int rarity;
	public int quality;
	public int max_durability;


}
