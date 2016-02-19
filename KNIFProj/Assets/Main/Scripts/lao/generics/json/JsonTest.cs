using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LAO.Generic {

    //test
    public class Foo {
        public int id { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Foo() { }
    }

    public class JsonTest : MonoBehaviour {

        // Use this for initialization
        void Start() {
            //single json object
            
            Foo f = new Foo();
            f.id = 22;
            f.full_name = "tom";
            f.email = "tom@mail";
            f.phone = "9999-999";

            string jsonstr = JsonConvert.SerializeObject(f);

            Foo f2 = JsonConvert.DeserializeObject<Foo>(jsonstr);

            Debug.Log(f2.id);

            //if you have multiple objects use list
            //-----------------------------------------------------------------------------------------------------------------
            List<Foo> foo4Serializing = new List<Foo>();
            for(int i=0; i<5; i++) {
                Foo foo = new Foo();
                foo.id = i;
                foo.full_name = "name_" + i;
                foo.email = "email" + i + "@hotmail.com";
                foo.phone = "222-" + i * 1000;
                foo4Serializing.Add(foo);
            }
            string jsonArrStr = JsonConvert.SerializeObject(foo4Serializing);   //serialized into json
            List<Foo> foosDeserialized = JsonConvert.DeserializeObject<List<Foo>>(jsonArrStr);  //deserialized back to objects
            //------------------- end of serializing and deserializing arrays
            
        }
        
    }
}