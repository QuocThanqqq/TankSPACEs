using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BYPoolManager : MonoBehaviour
{
    public static BYPoolManager poolInstance;

    [SerializeField]
    private List<BYPool> pools;
    public Dictionary<string, BYPool> dic_pool = new Dictionary<string, BYPool>();
    
    public BYPoolManager()
    {
        //if(poolInstance == null)
        poolInstance = this;
    }

    void Start()
    {

        foreach (BYPool e in pools)
        {
            CreatePool(e);
            dic_pool.Add(e.namePool, e);
            // dic_pool[e.namePool] = e;
        }

    }

    /// Them Pool moi
    public void AddNewPool(BYPool pool)
    {
        if (!dic_pool.ContainsKey(pool.namePool))
        {
            CreatePool(pool);
            dic_pool.Add(pool.namePool, pool);
        }
    }
    /// Tao pool moi
    public void CreatePool(BYPool pool)
    {
        for (int i = 0; i < pool.total; i++)
        {
            Transform trans = Instantiate(pool.prefab_, Vector3.zero, Quaternion.identity);
            pool.elements.Add(trans);
            trans.gameObject.SetActive(false);
        }
    }
    /// Xuat hien ra Object theo ten
    public Transform Spawn(string name_pool)
    {
        return dic_pool[name_pool].OnSpawned();
    }
    /// An Object  da duoc spawn ra
    public void DeSpawn(string name_pool, Transform trans_)
    {
        dic_pool[name_pool].OnDeSpawned(trans_);
    }
}

[Serializable]
public class BYPool
{
    public int total;
    public string namePool;
    public Transform prefab_;
    [NonSerialized]
    public List<Transform> elements = new List<Transform>();
    private int index = -1;
    public BYPool()
    {

    }
    public BYPool(string name, int total, Transform prefab)
    {
        this.namePool = name;
        this.total = total;
        this.prefab_ = prefab;

    }

    /// Hien cac object co ten  phuong thuc  la OnSpawned
    public Transform OnSpawned()
    {
        index++;
        if (index >= elements.Count)
        {
            index = 0;
        }
        Transform trans = elements[index];
        trans.gameObject.SetActive(true);
        trans.gameObject.SendMessage("OnSpawned", SendMessageOptions.DontRequireReceiver); /// Không yêu cầu đối tượng nhận thông điệp phải có phương thức được gọi.
        return trans;

    }
    /// An cac object co ten  phuong thuc  la OnDeSpawned
    public void OnDeSpawned(Transform trans_)
    {
        if (elements.Contains(trans_))
        {
            trans_.gameObject.SendMessage("OnDeSpawned", SendMessageOptions.DontRequireReceiver); ///Không yêu cầu đối tượng nhận thông điệp phải có phương thức được gọi.
            trans_.gameObject.SetActive(false);
        }
    }
}