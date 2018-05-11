using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class MonsterGenerator : MonoBehaviour {

	private Dictionary<int, MonsterTemplate> monsterDB;

	// Use this for initialization
	void Start () {
		test ();
	}

	public void test(){
		MonsterTemplate m = new MonsterTemplate();
		m.baseHP = 5;
		m.name = "Jane";
		m.maxAtk = 9;
		m.minAtk = 2;
		m.id = 33;
		m.level = 2;

		Newtonsoft.Json.Linq.JsonLoadSettings setting = new Newtonsoft.Json.Linq.JsonLoadSettings ();

		Debug.Log ("---");
		string jsonStr = JsonConvert.SerializeObject (m);
		Debug.Log (jsonStr);

		//Newtonsoft.Json.Linq.JObject obj = JsonConvert.

	}
	

	public void loadMonsterDatabase(string monsterDBJson){
		//test
		List<MonsterTemplate> monsters = JsonConvert.DeserializeObject<List<MonsterTemplate>>(monsterDBJson);  //deserialized back to objects
		monsterDB = new Dictionary<int, MonsterTemplate>();
		monsters.ForEach (monster => {
			monsterDB.Add(monster.id, monster);
		});

		// parse
		//json ["monsters"] [0];
	}
}
