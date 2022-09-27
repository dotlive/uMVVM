using UnityEngine;

namespace Assets.Sources.Core.Log
{
    public class ConsoleContentWriter : IContentWriter
    {
        public void Write(string message)
        {
            Debug.Log("Console Log!:"+message);
        }
    }
}
