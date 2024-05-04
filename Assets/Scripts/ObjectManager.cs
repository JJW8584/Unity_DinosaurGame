using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject CactusAPrefab;
    public GameObject CactusBPrefab;
    public GameObject CactusCPrefab;

    GameObject[] CactusA;
    GameObject[] CactusB;
    GameObject[] CactusC;

    GameObject[] targetPool;
    private void Awake()
    {
        CactusA = new GameObject[5];
        CactusB = new GameObject[5];
        CactusC = new GameObject[5];

        Generate();
    }
    void Generate()
    {
        for (int i = 0; i < CactusA.Length; i++)
        {
            CactusA[i] = Instantiate(CactusAPrefab);
            CactusA[i].SetActive(false);
        }
        for (int i = 0; i < CactusB.Length; i++)
        {
            CactusB[i] = Instantiate(CactusBPrefab);
            CactusB[i].SetActive(false);
        }
        for (int i = 0; i < CactusC.Length; i++)
        {
            CactusC[i] = Instantiate(CactusCPrefab);
            CactusC[i].SetActive(false);
        }

    }
    public GameObject MakeObject(string type)
    {
        switch (type)
        {
            case "CactusA":
                targetPool = CactusA;
                break;
            case "CactusB":
                targetPool = CactusB;
                break;
            case "CactusC":
                targetPool = CactusC;
                break;
        }

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                return targetPool[i];
            }
        }

        return null;
    }
}
