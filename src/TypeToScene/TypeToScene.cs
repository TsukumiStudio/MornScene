using System;

namespace MornLib
{
    [Serializable]
    internal struct TypeToScene
    {
        public MornSceneType SceneType;
        public MornSceneObject Scene;
    }
}