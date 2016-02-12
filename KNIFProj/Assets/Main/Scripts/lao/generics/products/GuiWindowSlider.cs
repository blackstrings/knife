using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    /// <summary>
    /// GUI window slider. This class has its own fixedUpdate
    /// </summary>
    public class GuiWindowSlider : MObject {

        //var
        GameObject go;
        public float speed = 3f;
        //public float speed { get{return speed;} set{speed = value;} }

        //var
        public bool slideInward = true;
        public float maxDist = 10f;
        public float curDist { get; set; }
        public float origX { get; set; }
        public float origY { get; set; }
        bool slideComplete = true;

        private Transform stopOutPos;
        private Transform stopInPos;
        private bool canSetOut = true;
        private bool canSetIn = true;

        //one of these should be set in interface before runtime
        public bool slideRight;
        public bool slideLeft;
        public bool slideDown;
        public bool slideUp;

        enum Direction { SLIDERIGHT, SLIDELEFT, SLIDEUP, SLIDEDOWN }
        Direction dir;

        //hack var
        public bool canCheckSlideIn;

        private void test() {
            Debug.Log(canSetOut && canSetIn);
        }

        /// <summary>
        /// Start this instance.
        /// </summary>
        void Start() {

            //determin direction
            if (slideLeft)
                dir = Direction.SLIDELEFT;
            else if (slideRight)
                dir = Direction.SLIDERIGHT;
            else if (slideUp)
                dir = Direction.SLIDEUP;
            else if (slideDown)
                dir = Direction.SLIDEDOWN;

            go = this.gameObject;
            origX = go.transform.position.x;
            origY = go.transform.position.y;
        }

        /// <summary>
        /// Update this instance.
        /// </summary>
        void FixedUpdate() {
            animate();
        }

        void OnMouseDown() {
            //prevent user from clicking again before animation is over
            if (slideComplete) {
                //hack custom code for camerLerp
                if (canCheckSlideIn) {
                    CameraLerp.instance.slideIn = !CameraLerp.instance.slideIn;
                }

                setCanAnimate(true);
                slideComplete = false;
            }
        }

        /// <summary>
        /// Animate this instance.
        /// </summary>
        public override void animate() {
            if (canAnimate()) {
                //all animations go here
                slideAnimation();
            }
        }

        /// <summary>
        /// Slides the animation.
        /// </summary>
        private void slideAnimation() {

            //slide inward
            if (slideInward) {

                switch (dir) {
                    case Direction.SLIDELEFT:
                        go.transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
                        break;
                    case Direction.SLIDERIGHT:
                        go.transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
                        break;
                    case Direction.SLIDEUP:
                        go.transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
                        break;
                    case Direction.SLIDEDOWN:
                        go.transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
                        break;
                }

            } else {    // slide outward

                switch (dir) {
                    case Direction.SLIDELEFT:
                        go.transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
                        break;
                    case Direction.SLIDERIGHT:
                        go.transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
                        break;
                    case Direction.SLIDEUP:
                        go.transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
                        break;
                    case Direction.SLIDEDOWN:
                        go.transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
                        break;
                }

            }

            //udpate distance regardless of what direction was choosen
            switch (dir) {
                case Direction.SLIDELEFT:
                    curDist = go.transform.position.x - origX;
                    break;
                case Direction.SLIDERIGHT:
                    curDist = origX - go.transform.position.x;
                    break;
                case Direction.SLIDEUP:
                    curDist = go.transform.position.y - origY;
                    break;
                case Direction.SLIDEDOWN:
                    curDist = origY - go.transform.position.y;
                    break;
            }
            //check if max point reach
            if (curDist > maxDist) {
                toggleCanAnimate();
                slideInward = false;
                slideComplete = true;
            }

            //check if min point reach
            if (curDist < 0) {
                toggleCanAnimate();
                slideInward = true;
                slideComplete = true;
            }

        }


    }
}