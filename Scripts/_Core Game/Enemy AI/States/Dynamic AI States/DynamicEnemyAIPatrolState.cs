using UnityEngine;
using System.Threading;
using Project.Tools.Help;
using Cysharp.Threading.Tasks;

namespace Project.EnemyAI.State
{
    public class DynamicEnemyAIPatrolState : DynamicEnemyAIAbstractState
    {
        private CancellationTokenSource cancellationToken;
        private float speed = 1.25f;
        private float distance = 10f;

        public override void Enter()
        {
            cancellationToken.TryAddTokenToPoolInLevel();
            Patrol();
        }

        public override void Exit()
        {
            cancellationToken?.Cancel();
            cancellationToken.TryRemoveThisTokenFromPool();
        }

        private async void Patrol()
        {
            Vector3 startPosition = behaviour.ParentGameObject.transform.position;
            cancellationToken = new CancellationTokenSource();

            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    float elapsedTime = 0f;
                    while (elapsedTime < 3f)
                    {
                        behaviour.ParentGameObject.transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.right * distance,
                                                                                     elapsedTime / 3f);
                        elapsedTime += Time.deltaTime * speed;
                        await UniTask.Yield(cancellationToken: cancellationToken.Token);
                    }

                    elapsedTime = 0f;
                    while (elapsedTime < 3f)
                    {
                        behaviour.ParentGameObject.transform.position = Vector3.Lerp(startPosition + Vector3.right * distance, startPosition,
                                                                                     elapsedTime / 3f);
                        elapsedTime += Time.deltaTime * speed;
                        await UniTask.Yield(cancellationToken: cancellationToken.Token);
                    }
                }
            }
            catch
            {

            }
        }
    }
}