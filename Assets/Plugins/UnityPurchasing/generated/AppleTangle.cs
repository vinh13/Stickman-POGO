#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class AppleTangle
    {
        private static byte[] data = System.Convert.FromBase64String("TqU0cMrCGmmacY349tMGQyK2YrUQ7kxANV4JH1hXPZr+wmpyDuqcJjBpKDo6PCQsOmkoKiosOT0oJyosVtiSVw4ZokykFzDNZKJ/6x4FHKVET0BjzwHPvkRISExMSUrLSEhJFctISU9AY88Bz74qLUxIeci7eWNP/lL02gttW2OORlT/BNUXKoECyV49IC8gKig9LGkrMGkoJzBpOSg7PX/QBWQx/qTF0pW6PtK7P5s+eQaIgFA7vBRHnDYW0rtsSvMcxgQURLhNT1pLHBp4WnlYT0ocTUNaQwg5OUEXectIWE9KHFRpTctIQXnLSE15+HkRpRNNe8Uh+sZUlyw6ti4XLPVveW1PShxNQlpUCDk5JSxpCiw7PUxJSstIRkl5y0hDS8tISEmt2OBAkH82iM4ckO7Q8HsLspGcONc36BtPeUZPShxUWkhItk1MeUpISLZ5VCctaSomJy0gPSAmJzppJi9pPDosfHt4fXl6fxNeRHp8eXt5cHt4fXl6fxN5K3hCeUBPShxNT1pLHBp4Wi18alwCXBBU+t2+v9XXhhnziBEZiSp6Pr5zTmUfopNGaEeT8zpQBvw2COHRsJiDL9VtIliZ6vKtUmOKVgw3VgUiGd8IwI09K0JZygjOesPIZwnvvg4ENkEXeVZPShxUak1ReV8zectIP3lHT0ocVEZISLZNTUpLSBssJSAoJyosaSYnaT0hIDppKiw7AJE/1npdLOg+3YBkS0pISUjqy0g5JSxpGyYmPWkKCHlXXkR5f3l9e195XU9KHE1KWkQIOTklLGkbJiY93NczRe0OwhKdX356go1GBIddIJgrJSxpOj0oJy0oOy1pPSw7JDppKDklLGkKLDs9IC8gKig9ICYnaQg8wlDAl7ACJbxO4mt5S6FRd7EZQJolLGkAJypneG95bU9KHE1CWlQIOcldYpkgDt0/QLe9IsRnCe++DgQ2bauimP45lkYMqG6DuCQxpK78Xl5WzMrMUtB0Dn674NIJx2Wd+NlbkT4+Zyg5OSUsZyomJGYoOTklLCooT0ocVEdNX01dYpkgDt0/QLe9IsR5WE9KHE1DWkMIOTklLGkAJypneGkmL2k9ISxpPSEsJ2koOTklICooPSEmOyA9MHhfeV1PShxNSlpECDkgLyAqKD0gJidpCDw9ISY7ID0weGkKCHnLSGt5RE9AY88Bz75ESEhI4uo42w4aHIjmZgj6sbKqOYSv6gXGOsgpj1ISQGbb+7ENAbkpcddcvGPPAc++REhITExJeSt4QnlAT0ocQWJPSExMTktIX1chPT05OnNmZj78c+S9RkdJ20L4aF9nPZx1RJIrX3nLTfJ5y0rq6UpLSEtLSEt5RE9ARtR0umIAYVOBt4f88EeQF1WfgnQuxkH9ab6C5WVpJjn/dkh5xf4Khve9OtKnmy1GgjAGfZHrd7AxtiKBZnnIik9BYk9ITExOS0t5yP9TyPplaSosOz0gLyAqKD0saTkmJSAqMDsoKj0gKixpOj0oPSwkLCc9Omd5aSgnLWkqLDs9IC8gKig9ICYnaTl0by5pw3ojvkTLhpei6mawGiMSLeGVN2t8g2yckEafIp3rbWpYvujlGePDnJOttZlATn75PDxo");
        private static int[] order = new int[] { 51,52,40,15,47,34,59,39,48,19,40,33,26,40,14,58,29,43,39,48,20,57,43,25,31,28,38,27,59,38,39,42,47,38,58,47,53,49,53,39,48,41,58,53,48,58,55,52,52,59,51,53,57,53,59,57,57,58,58,59,60 };
        private static int key = 73;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
