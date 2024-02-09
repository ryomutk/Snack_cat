using System.Collections.Generic;
using UnityEngine;


public class ObjectPool<T> where T : MonoBehaviour
{
    List<T> _pool;
    int _currentIndex = 0;
    T prefab;

    public ObjectPool(T prefab, int poolSize, Transform parent = null)
    {
        this.prefab = prefab;
        _pool = new List<T>();
        for (int i = 0; i < poolSize; i++)
        {
            _pool.Add(Object.Instantiate(prefab));
            _pool[i].gameObject.SetActive(false);
            if (parent != null)
            {
                _pool[i].transform.SetParent(parent);
            }
        }
    }

    T GenerateObject()
    {
        T obj = Object.Instantiate(prefab);
        _pool.Add(obj);
        return obj;
    }


    public T GetObject()
    {
        foreach (var obj in _pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        return GenerateObject();
    }


}