using System.Collections.Generic;

namespace Assets.Sources.Core.Infrastructure
{
    [System.Serializable]
    public class Response<T>
    {
        public List<T> Items;
        public T Item
        {
            get
            {
                if (Items != null && Items.Count == 1)
                {
                    return Items[0];
                }
                return default(T);
            }
        }
    }

}
