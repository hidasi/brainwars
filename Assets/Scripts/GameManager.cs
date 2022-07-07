using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefab;
    public Transform location;
    public List<GameObject> listOfObjects;
    public int amount;

    private void Awake()
    {
        StartPool();
    }
    public void StartPool()
    {
        listOfObjects = new List<GameObject>();
        for (int i = 0; i < amount; i++)
        {
            var obj = Instantiate(prefab, new Vector3(0,0,0),Quaternion.identity);
            obj.SetActive(false);
            listOfObjects.Add(obj);
        }
    }

    public GameObject GetPooled()
    {
        for (int i = 0; i < amount; i++)
        {
            if (!listOfObjects[i].activeInHierarchy)
            {
                return listOfObjects[i];
            }
        }
        return null;
    }

    public void SpawnObject()
    {
        var obj = GetPooled();
        obj.SetActive(true);
        StartCoroutine(wait(obj));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnObject();
        }
    }

    IEnumerator wait(GameObject ob)
    {
        yield return new WaitForSeconds(4f);
        ob.SetActive(false);
    }
}
