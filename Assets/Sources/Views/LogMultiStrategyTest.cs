using Assets.Sources.Core.Log;
using UnityEngine;

namespace Assets.Sources.Views
{
    public class LogMultiStrategyTest : MonoBehaviour
    {
        void Start()
        {
            LogFactory.Instance.Resolve<ConsoleLogStrategy>().Log("Welcome", true);
        }
    }
}
