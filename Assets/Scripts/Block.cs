using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sokabon
{
    public class Block : MonoBehaviour
    {

        public Vector3 GetPosInDir(Vector2Int direction)
        {
            return transform.position + new Vector3(direction.x, direction.y, 0);
        }

        public void MoveInDirection(Vector2Int direction)
        {
            transform.position = GetPosInDir(direction);
        }

        public bool IsDirectionFree(Vector2Int direction)
        {
            Vector3 position = GetPosInDir(direction);
            Collider2D col2D = Physics2D.OverlapCircle(position, 0.3f);
            return col2D == null;
        }

        public Block BlockInDirection(Vector2Int direction)
        {
            Vector3 position = GetPosInDir(direction);
            Collider2D col2D = Physics2D.OverlapCircle(position, 0.3f);
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