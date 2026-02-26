using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject runtimePlatforms;
    [SerializeField] GameObject startPlatformPoint;

    // Start is called before the first frame update
    void Start()
    {
        GameObject currentPlatform = 
            Instantiate(platformPrefab, startPlatformPoint.transform.position, quaternion.identity);
        OffsetPlatform(currentPlatform);

    }

    void OffsetPlatform(GameObject currentplatform)
    {
        var entryAnchor = currentplatform.transform.Find("EntryAnchor");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
