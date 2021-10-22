using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random : MonoBehaviour
{
    public GameObject myPrefab;
    private int squareside = 10;
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> tab = new List<Vector3>();
        for (int i = 0; i < squareside; i++)
        {
            for (int j = 0; j < squareside; j++)
            {
                tab.Add(new Vector3(i, 0, j));
            }
        }
        var rand = new System.Random();
        for (int i = 0; i < 10; i++)
        {
            int x = rand.Next(tab.Count);
            Instantiate(myPrefab, tab[x], Quaternion.identity);
            tab.RemoveAt(x);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
