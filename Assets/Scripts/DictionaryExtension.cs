using System.Collections.Generic;
using TMPro;

public static class DictionaryExtension
{
    /// <summary>
    /// dictionary extension to reset value for all keys
    /// </summary>
    /// <param name="dict">dictionary</param>
    /// <param name="value">reset value for all keys</param>
    public static void ResetAllValues<TKey, TValue>(this Dictionary<TKey, TValue> dict, TValue value)
    {
        foreach (var key in dict.Keys)
        {
            dict[key] = value;
        }
    }
}