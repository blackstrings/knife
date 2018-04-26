
namespace Rainkey.Network{

	public class LoginAuth{

		public string user { get; set; }

		public string email { get; set; }

		public string pass { get; set; }

		public string auth_token { get; set; }

		public LoginAuth (string email, string pass, string user){ 
			this.email = email;
			this.pass = pass;
			this.user = user;
		}

	}
	
}