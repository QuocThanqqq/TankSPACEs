using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public DataGun DataGun;


    public DataManager()
    {
        Instance = this;
    }
}
