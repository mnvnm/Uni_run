using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] List<GameObject> m_platformsPrefabs;
    [SerializeField] List<GameObject> m_platforms;

    float m_spawnInterval = 2.5f;
    float m_spawnDelay = 0f;
    void Start()
    {
    }
    public void Init()
    {
        m_spawnDelay = 0f;
        ClearPlatformList();
        SpawnFirstPlatform();
        SpawnPlatform();
    }

    void SpawnFirstPlatform()
    {
        var platform = Instantiate(m_platformsPrefabs[1], new Vector2(0, -3), Quaternion.identity, transform);
        m_platforms.Add(platform);
    }
    void SpawnPlatform()
    {
        var platform = Instantiate(m_platformsPrefabs[Random.Range(0, m_platformsPrefabs.Count)], new Vector2(20.48f, (int)Random.Range(-3, 2)), Quaternion.identity, transform);
        m_platforms.Add(platform);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGameBegin()) return;

        m_spawnDelay += Time.deltaTime;
        if (m_spawnDelay >= m_spawnInterval)
        {
            m_spawnDelay = 0f;
            SpawnPlatform();
        }
    }

    public void RemovePlatform(GameObject platform)
    {
        m_platforms.Remove(platform);
    }

    void ClearPlatformList()
    {
        foreach (var plat in m_platforms)
        {
            Destroy(plat.gameObject);
        }
        m_platforms.Clear();
    }
}
