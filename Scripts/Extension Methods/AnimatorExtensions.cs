using System.Linq;
using UnityEngine;

namespace Project.ExtensionMethod
{
    public static class AnimatorExtensions
    {
        public static void ResetAllTriggers(this Animator animator)
        {
            foreach (var parameter in animator.parameters)
            {
                if (parameter.type == AnimatorControllerParameterType.Trigger)
                {
                    animator.ResetTrigger(parameter.name);
                }
            }
        }

        public static bool IsCurrentAnimationState(this Animator animator, string animationStateName)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            return stateInfo.IsName(animationStateName);
        }

        public static bool IsCurrentAnimationState(this Animator animator, params string[] animationStateNames)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            foreach (string name in animationStateNames)
            {
                if (stateInfo.IsName(name))
                {
                    return true;
                }
            }

            return false;
        }

        public static string GetCurrentAnimationName(this Animator animator)
        {
            AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
            return clipInfo.Length > 0 ? clipInfo[0].clip.name : "Unknown";
        }
    }
}
