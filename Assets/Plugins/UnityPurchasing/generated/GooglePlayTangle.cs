#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("72xibV3vbGdv72xsbeiwbQonbw725h8+ZEhbS2qs5tzxtX0ZibpyfyB1ONQSly/Pk54+shbWiETRWkUcgfyCefIz8Q+0HeC//LaBalPpT8XWx5OSqtOnh+dyEZLsKpTTHvMi013vbE9dYGtkR+sl65pgbGxsaG1uzLd7fAmnJi7pnrZhMYWV5H90iu9fHx/00w60hdp3MBLzrEh7hhMVMyJLcEerjF6I6lE4MnTPU+P64OojAa0fXlwywSHR7r9aY5/h8J12iLCIeabFVHTmVeewhgHus8yhfWq+H8ucpi3QItcsnb/q7a4ZNKZdgc/0qSXEgPhWLiGVjM1NvGnFy4yOAkdqHkl0Tg259fOPVL9kJD0KAUTJcNNcjIzSf/Yynm9ubG1s");
        private static int[] order = new int[] { 1,2,5,11,10,5,10,13,9,12,13,12,12,13,14 };
        private static int key = 109;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
