using System;

namespace MornLib
{
    [Serializable]
    public sealed class MornSceneRollbackKey : MornEnumBase
    {
        public override string[] Values => MornSceneGlobal.I.RollbackKeys;
        public override UnityEngine.Object PingTarget => MornSceneGlobal.I;
    }
}