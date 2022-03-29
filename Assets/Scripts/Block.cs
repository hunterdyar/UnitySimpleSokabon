using System;
using System.Collections;
using System.Collections.Generic;
using Sokabon.CommandSystem;
using UnityEngine;

namespace Sokabon
{
    public class Block : MonoBehaviour
    {
        public Action AtNewPositionEvent;
        [SerializeField] private MovementSettings movementSettings;
        public bool IsAnimating => _animating; 
        private bool _animating;
        
        [SerializeField] private LayerSettings layerSettings;
        public Vector3 GetPosInDir(Vector2Int direction)
        {
            return transform.position + new Vector3(direction.x, direction.y, 0);
        }

        public void MoveInDirection(Vector2Int direction, bool instant, Action onComplete)
        {
            Vector3 destination = GetPosInDir(direction);

            if (instant)
            {
                transform.position = destination;
                AtNewPositionEvent?.Invoke();
                onComplete?.Invoke();
            }
            else
            {
                StartCoroutine(AnimateMove(destination,onComplete));
            }
        }

        public IEnumerator AnimateMove(Vector3 destination, Action onComplete)
        {
            _animating = true;
            Vector3 start = transform.position;
            float t = 0;
            while (t < 1)
            {
                t = t + Time.deltaTime/movementSettings.timeToMove;
                transform.position = Vector3.Lerp(start, destination, movementSettings.movementCurve.Evaluate(t));
                yield return null;
            }

            transform.position = destination;
            AtNewPositionEvent?.Invoke();
            onComplete?.Invoke();
            _animating = false;
        }

        public bool IsDirectionFree(Vector2Int direction)
        {
            Vector3 position = GetPosInDir(direction);
            //the ^ combines the two bitmaps with an OR (the pipe symbol) bitwise operation. 0011 and 0110 becomes 0111. 
            //It means we are checking for blocks AND solid stuff, and have the flexibility to differentiate.
            Collider2D col2D = Physics2D.OverlapCircle(position, 0.3f, layerSettings.solidLayerMask | layerSettings.blockLayerMask);
            return col2D == null;
        }

        public Block BlockInDirection(Vector2Int direction)
        {
            Vector3 position = GetPosInDir(direction);
            Collider2D col2D = Physics2D.OverlapCircle(position, 0.3f, layerSettings.blockLayerMask);
            if (col2D != null)
            {
                return col2D.GetComponent<Block>();
            }
            else
            {
                return null;
            }
        }
    }
}