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
        public static async UniTask<Scene> LoadAdditiveAsync(string scenePath)
        {
#if UNITY_EDITOR
            await EditorSceneManager.LoadSceneAsyncInPlayMode(scenePath, new LoadSceneParameters(LoadSceneMode.Additive)).ToUniTask();
#else
            await SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Additive).ToUniTask();
#endif
            return SceneManager.GetSceneByPath(scenePath);
        }

        /// <summary>追加読み込みしたシーンを破棄する</summary>
        public static UniTask UnloadAdditiveAsync(Scene scene)
        {
            return SceneManager.UnloadSceneAsync(scene).ToUniTask();
        }
    }
}
