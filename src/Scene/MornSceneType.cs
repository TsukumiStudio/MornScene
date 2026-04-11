using System;

namespace MornLib
{
    [Serializable]
    public sealed class MornSceneType : MornEnumBase
    {
        public override string[] Values => MornSceneGlobal.I.RollbackKeys;
        public override UnityEngine.Object PingTarget => MornSceneGlobal.I;
    }

    public static class MornSceneTypeEx
    {
        public static MornSceneObject ToScene(this MornSceneType sceneType)
        {
            return MornSceneGlobal.I.ToScene(sceneType);
        }
    }
}