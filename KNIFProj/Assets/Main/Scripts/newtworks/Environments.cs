using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rainkey.Network{
	
	public class Environments{

		private string domain;

		public Environments(string env){
			if (env == "prod"){
				domain = prodDomain;
			} else{
				domain = stageDomain;
			}
		}

		private string stageDomain = "http://localhost:3000/";
		private string prodDomain = "http://weapons.herokuapp.com/";

		public string getUri (URI key){
			switch (key){
				case URI.LOGIN:
					return domain + "api/v1/login/";
				case URI.WEAPON:
					return domain + "api/v1/weapons/";
				case URI.CREATE_NEW_USER:
					return domain + "api/v1/sign_up/";
				case URI.CREATE_RANDOM_WEAPON:
					return domain + "api/v1/weapons_generator/";
				default:
					return null;
			}
		}

	}
}
