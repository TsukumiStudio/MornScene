using System.Collections.Generic;
using MornGlobal;
using UnityEngine;

namespace MornScene
{
    [CreateAssetMenu(fileName = nameof(MornSceneGlobal), menuName = "Morn/" + nameof(MornSceneGlobal))]
    public sealed class MornSceneGlobal : MornGlobalBase<MornSceneGlobal>
    {
        protected override string ModuleName => nameof(MornScene);
        [SerializeField] private string[] _rollbackKeys;
        [SerializeField] private string[] _sceneKeys;
        [SerializeField] private List<TypeToScene> _toSceneList;
        internal string[] RollbackKeys => _rollbackKeys;
        internal string[] SceneKeys => _sceneKeys;

        public MornSceneObject ToScene(MornSceneType scene)
        {
            foreach (var toScene in _toSceneList)
            {
                if (toScene.SceneType.Key == scene.Key)
                {
                    return toScene.Scene;
                }
            }

            return null;
        }

        internal static void Log(string message)
        {
            I.LogInternal(message);
        }

        internal static void LogWarning(string message)
        {
            I.LogWarningInternal(message);
        }

        internal static void LogError(string message)
        {
            I.LogErrorInternal(message);
        }
    }
}