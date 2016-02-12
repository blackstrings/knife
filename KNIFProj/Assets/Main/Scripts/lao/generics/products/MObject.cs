using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public abstract class MObject : MonoBehaviour, Animatable {

        //var
        private bool _canAnimate;

        /// <summary>
        /// Initializes a new instance of the <see cref="MObject"/> class.
        /// </summary>
        public MObject() {
            _canAnimate = false;
        }

        public abstract void animate();

        /// <summary>
        /// Check if can animate
        /// </summary>
        /// <returns><c>true</c>, if animate was caned, <c>false</c> otherwise.</returns>
        public bool canAnimate() {
            if (_canAnimate) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sets the can animate.
        /// </summary>
        /// <param name="value">If set to <c>true</c> value.</param>
        public void setCanAnimate(bool value) {
            _canAnimate = value;
        }

        /// <summary>
        /// Toggles the can animate.
        /// </summary>
        public void toggleCanAnimate() {
            if (_canAnimate)
                setCanAnimate(false);
            else
                setCanAnimate(true);
        }

    }
}