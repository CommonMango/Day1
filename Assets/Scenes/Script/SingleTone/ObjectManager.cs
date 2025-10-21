using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager>
{
    [SerializedDictionary("ObjectPrefab", "ObjectPoolSize")]
    public SerializedDictionary<GameObject, int> _poolSizeDictionary; //pool size를 보관하는 딕셔너리 
 
    private Dictionary<GameObject, GameObject[]> _poolDictionary; //pool을 보관하는 딕셔너리
                                                                     
    protected override void Awake()
    {
        base.Awake();

        _poolDictionary = new Dictionary<GameObject, GameObject[]>();
        CreatePools();       
    }
    
    private void CreatePools() //오브젝트 풀 생성 
    {   
        foreach(var obj in _poolSizeDictionary.Keys)
        {
            var objects = new GameObject[_poolSizeDictionary[obj]];
       
            for (int i = 0; i < objects.Length; i++)
            {
                GameObject gameobj = Instantiate(obj);
                gameobj.SetActive(false);
                objects[i] = gameobj;
            }
            _poolDictionary.Add(obj, objects);
        }        
    }
    
    public void Spawn(GameObject prefab, Vector3 position, Quaternion rotation) //오브젝트풀의 객체를 해당 위치에 생성 
    {        
        var pool = _poolDictionary[prefab];
       
        foreach(var obj in pool)
        {
            if (obj.activeSelf == false)
            {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
                return;
            }
        }               
    }      
}




