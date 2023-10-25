using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPooling : MonoBehaviour
{
    public static PlayerPooling instance;
    List<GameObject> PooledObj = new List<GameObject>();
    public GameObject bullet;
    [SerializeField] int AmountToPool;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;


        for(int i = 0; i < AmountToPool; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            PooledObj.Add(obj);
        }
    }

   public GameObject GetPooledBullet()
    {
        for(int i = 0;i < PooledObj.Count; i++)
        {
            if (!PooledObj[i].gameObject.activeInHierarchy)
            {
                return PooledObj[i];
            }
        }

        return null;
    }
}
