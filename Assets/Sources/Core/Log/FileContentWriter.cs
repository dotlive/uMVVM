using UnityEngine;

namespace Assets.Sources.Core.Log
{
    public class FileContentWriter : IContentWriter
    {
        public void Write(string message)
        {
            //IO
            Debug.Log("File Log!：{0}"+message);
        }
    }
}
