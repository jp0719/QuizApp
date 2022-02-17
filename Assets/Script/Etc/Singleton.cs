using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _Instance;

    protected static object _lock = new object();

    public static T Instance
    {
        get
        {
            lock (_lock)
            {
                if (_Instance == null)
                {
                    _Instance = (T)FindObjectOfType(typeof(T));

                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        return _Instance;
                    }

                    if (_Instance == null)
                    {
                        GameObject singleton = new GameObject();

                        _Instance = singleton.AddComponent<T>();
                        singleton.name = typeof(T).ToString();
                    }
                }
            }

            return _Instance;
        }

    }

    protected virtual void Awake()
    {
        if (Instance != this)
            Destroy(this.gameObject);
    }
}