using UnityEngine.SceneManagement;

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
    }
}