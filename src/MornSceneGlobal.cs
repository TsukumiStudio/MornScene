using System.Collections.Generic;
using UnityEngine;

namespace MornLib
{
    [CreateAssetMenu(fileName = nameof(MornSceneGlobal), menuName = "Morn/" + nameof(MornSceneGlobal))]
    public sealed class MornSceneGlobal : MornGlobalBase<MornSceneGlobal>
    {
        protected override string ModuleName => "MornScene";
        [SerializeField, NoLabel] private string[] _rollbackKeys;
        [SerializeField, NoLabel] private string[] _sceneKeys;
        [SerializeField, NoLabel] private List<TypeToScene> _toSceneList;
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
    }
}
