using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sokabon
{
    public class Block : MonoBehaviour
    {
        public Action AtNewPositionEvent;
        
        [SerializeField] private LayerSettings layerSettings;
        public Vector3 GetPosInDir(Vector2Int direction)
        {
            return transform.position + new Vector3(direction.x, direction.y, 0);
        }

        public void MoveInDirection(Vector2Int direction)
        {
            transform.position = GetPosInDir(direction);
            AtNewPositionEvent?.Invoke();
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