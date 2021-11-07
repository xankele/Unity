using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public int amount = 10;
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    public List<Material> materials;

    void Start()
    {
        GameObject plane = GameObject.FindGameObjectWithTag("Plane");
        Renderer rendOfBlock = block.GetComponent<Renderer>();
        Renderer rend = GetComponent<Renderer>();
        List<int> pozycje_x = new List<int>(Enumerable.Range(0, Convert.ToInt32(rend.bounds.size.x)).OrderBy(x => Guid.NewGuid()).Take(amount));
        List<int> pozycje_z = new List<int>(Enumerable.Range(0, Convert.ToInt32(rend.bounds.size.z)).OrderBy(x => Guid.NewGuid()).Take(amount));

        for (int i = 0; i < amount; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i] + transform.position.x - Convert.ToInt32(rend.bounds.size.x / 2) + +rendOfBlock.bounds.size.x / 2, 0, pozycje_z[i] + transform.position.z - Convert.ToInt32(rend.bounds.size.z / 2) + rendOfBlock.bounds.size.z / 2));
        }
        var random = new System.Random();
        int index = random.Next(materials.Count);
        rendOfBlock.material = materials[index];
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        Renderer rendOfBlock = block.GetComponent<Renderer>();
        var random = new System.Random();
        int index = random.Next(materials.Count);
        rendOfBlock.material = materials[index];
    }

    IEnumerator GenerujObiekt()
    {
        foreach (Vector3 pos in positions)
        {
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}