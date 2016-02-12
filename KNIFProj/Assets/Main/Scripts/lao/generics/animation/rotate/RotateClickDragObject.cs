using UnityEngine;
using System.Collections;

namespace LAO.Generic {

    public class RotateClickDragObject : MonoBehaviour {

        private float _sensitivity;
        private Vector3 _mouseReference;
        private Vector3 _mouseOffset;
        private Vector3 _rotation;
        private bool _isRotating;

        void Start() {
            _sensitivity = 0.4f;
            _rotation = Vector3.zero;
        }

        void Update() {
            /* //roate on x-axis only
            if(_isRotating)
            {
                // offset
                _mouseOffset = (Input.mousePosition - _mouseReference);

                // apply rotation
                _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;

                // rotate
                transform.Rotate(_rotation);

                // store mouse
                _mouseReference = Input.mousePosition;
            }
            */

            //rotate on both y and x axis
            if (_isRotating) {
                // offset
                _mouseOffset = (Input.mousePosition - _mouseReference);
                // apply rotation
                //_rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
                _rotation.y = -(_mouseOffset.x) * _sensitivity;
                _rotation.x = -(_mouseOffset.y) * _sensitivity;
                // rotate
                //transform.Rotate(_rotation);
                transform.eulerAngles -= _rotation;
                // store mouse
                _mouseReference = Input.mousePosition;
            }
        }

        void OnMouseDown() {
            // rotating flag
            _isRotating = true;

            // store mouse
            _mouseReference = Input.mousePosition;
        }

        void OnMouseUp() {
            // rotating flag
            _isRotating = false;
        }

    }
}