using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public interface Animatable {
        void animate();
        bool canAnimate();
        void setCanAnimate(bool value);
        void toggleCanAnimate();
    }

}

