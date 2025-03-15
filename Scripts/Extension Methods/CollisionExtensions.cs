using System.Collections.Generic;
using UnityEngine;

namespace Project.ExtensionMethod
{
    public static class CollisionExtensions
    {
        public static void SetIgnoreCollision(this Collider collider, Collider otherCollider, bool ignore)
        {
            Physics.IgnoreCollision(collider, otherCollider, ignore);
        }

        public static void SetIgnoreCollision(this Collider collider, Collider[] otherColliders, bool ignore)
        {
            foreach (var otherCollider in otherColliders)
            {
                Physics.IgnoreCollision(collider, otherCollider, ignore);
            }
        }

        public static void SetIgnoreCollision(this Collider collider, List<Collider> otherColliders, bool ignore)
        {
            foreach (var otherCollider in otherColliders)
            {
                Physics.IgnoreCollision(collider, otherCollider, ignore);
            }
        }
    }
}
