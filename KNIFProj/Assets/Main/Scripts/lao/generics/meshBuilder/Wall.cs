using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public class Wall : Object {

        private double width { get; set; }
        private double height { get; set; }
        private double length { get; set; }

        public Wall(double width, double height, double length) {
            this.width = width;
            this.height = height;
            this.length = length;
        }
        
    }
}