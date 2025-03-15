using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Project.Tools.Help
{
    public static class CancellationTokenPool
    {
        private static Dictionary<CancellationTokenPoolType, List<CancellationTokenSource>> tokenPools =
                       new Dictionary<CancellationTokenPoolType, List<CancellationTokenSource>>()
                       {
                           { CancellationTokenPoolType.InLevel, new List<CancellationTokenSource>() },
                           { CancellationTokenPoolType.InScene, new List<CancellationTokenSource>() }
                       };

        public static int PoolCount(CancellationTokenPoolType poolName)
        {
            return tokenPools[poolName].Count;
        }

        /// <summary>
        /// This will cancel token on destroy with method <see cref="KillPoolInLevelTokens()"/> on current level destroy
        /// </summary>
        /// <param name="token"></param>
        public static void TryAddTokenToPoolInLevel(this CancellationTokenSource token)
        {
            token.TryAddTokenToPool(CancellationTokenPoolType.InLevel);
        }

        public static void KillPoolInLevelTokens()
        {
            KillPoolTokens(CancellationTokenPoolType.InLevel);
            Debug.Log($"{CancellationTokenPoolType.InLevel} pool tokens killed");
        }

        /// <summary>
        /// This will cancel token on destroy with method <see cref="KillPoolInLevelTokens()"/> on scene close
        /// </summary>
        /// <param name="token"></param>
        public static void TryAddTokenToPoolInScene(this CancellationTokenSource token)
        {
            token.TryAddTokenToPool(CancellationTokenPoolType.InScene);
        }

        public static void KillPoolInSceneTokens()
        {
            KillPoolTokens(CancellationTokenPoolType.InScene);
            Debug.Log($"{CancellationTokenPoolType.InScene} pool tokens killed");
        }

        public static void TryAddTokenToPool(this CancellationTokenSource token, CancellationTokenPoolType poolName)
        {
            if (tokenPools[poolName].Contains(token) == false)
            {
                tokenPools[poolName].Add(token);
            }
            else
            {
                //Debug.LogWarning("Can't add multiple times same token");
            }
        }

        /// <summary>
        ///Tip: First cancel token then remove
        /// </summary>
        /// <param name="token"></param>
        public static void TryRemoveThisTokenFromPool(this CancellationTokenSource token)
        {
            foreach (var pool in tokenPools)
            {
                if (pool.Value.Contains(token))
                {
                    pool.Value.Remove(token);
                    //Debug.Log($"{token} removed from pool {pool.Key}");
                }
            }
        }

        public static void KillPoolTokens(CancellationTokenPoolType poolName)
        {
            foreach (var token in tokenPools[poolName])
            {
                token?.Cancel();
            }

            tokenPools[poolName].Clear();
        }
    }
}
