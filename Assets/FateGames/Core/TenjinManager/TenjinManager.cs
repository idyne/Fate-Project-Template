using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Fate/Tenjin Manager")]
public class TenjinManager : ScriptableObject
{
    [SerializeField] private string key = "VSGFVVVMXTFLPXSB64TTEDC6O5Q2YQKJ";
    public void Connect()
    {
        BaseTenjin instance = Tenjin.getInstance(key);

        // Sends install/open event to Tenjin
        instance.Connect();
    }
}
