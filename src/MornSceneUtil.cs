using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

namespace MornLib
{
    public static class MornSceneUtil
    {
        public static bool TryGetRollbackScene(this MornSceneRollbackKey key, out string sceneName)
        {
            return MornSceneService.I.TryGetRollbackScene(key, out sceneName);
        }

        public static void RegisterRollbackScene(this MornSceneRollbackKey key, Scene scene)
        {
            MornSceneService.I.RegisterRollbackScene(key, scene);
        }

        /// <summary>シーンを追加読み込みする。Editor ではビルド設定に無いシーンも読み込める</summary>
        /// <param name="scenePath">Assets/....unity 形式の完全パス</param>
        /// <param name="ct">待機の中断のみで、読み込み自体は止まらない。中断した場合に読み込まれたシーンは呼び出し側で破棄すること</param>
        public static async UniTask<Scene> LoadAdditiveAsync(string scenePath, CancellationToken ct = default)
        {
#if UNITY_EDITOR
            var operation = EditorSceneManager.LoadSceneAsyncInPlayMode(scenePath, new LoadSceneParameters(LoadSceneMode.Additive));
#else
            var operation = SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Additive);
#endif
            if (operation == null)
            {
                throw new InvalidOperationException($"シーンを読み込めません (ビルド設定に無い可能性): {scenePath}");
            }

            await operation.ToUniTask(cancellationToken: ct);
            // 同じパスを複数読み込んでいる場合に備え、後から読み込んだものを優先して返す
            for (var i = SceneManager.sceneCount - 1; i >= 0; i--)
            {
                var scene = SceneManager.GetSceneAt(i);
                if (scene.path == scenePath && scene.isLoaded)
                {
                    return scene;
                }
            }

            throw new InvalidOperationException($"読み込んだシーンが見つかりません: {scenePath}");
        }

        /// <summary>追加読み込みしたシーンを破棄する</summary>
        public static UniTask UnloadAdditiveAsync(Scene scene, CancellationToken ct = default)
        {
            if (!scene.IsValid() || !scene.isLoaded)
            {
                return UniTask.CompletedTask;
            }

            var operation = SceneManager.UnloadSceneAsync(scene);
            if (operation == null)
            {
                throw new InvalidOperationException($"シーンを破棄できません (最後のシーンの可能性): {scene.path}");
            }

            return operation.ToUniTask(cancellationToken: ct);
        }
    }
}
