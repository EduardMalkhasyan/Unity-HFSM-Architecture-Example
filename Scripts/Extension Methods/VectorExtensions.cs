using UnityEngine;

namespace Project.ExtensionMethod
{
    public static class VectorExtensions
    {
        public static Vector3Int ToVector3Int(this Vector3 vector)
        {
            return new Vector3Int(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y), Mathf.FloorToInt(vector.z));
        }

        public static float GetRandomRange(this Vector2 vector2)
        {
            return UnityEngine.Random.Range(vector2.x, vector2.y);
        }

        public static int GetRandomRange(this Vector2Int vector2)
        {
            return UnityEngine.Random.Range(vector2.x, vector2.y);
        }
    }
}
