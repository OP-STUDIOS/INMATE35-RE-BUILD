using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMaterialSlowMo : MonoBehaviour
{
    public Material EnemySlowMoMaterial;
    public Material EnemyDefaultMaterial;

    private SlowMotionManager slowMotionManager;

    
    // Start is called before the first frame update
    void Awake()
    {
        slowMotionManager = FindObjectOfType<SlowMotionManager>();

        if (slowMotionManager.UsingSlowMo)
        {
            GetComponentInChildren<SkinnedMeshRenderer>().material = EnemySlowMoMaterial;
        }
        else
        {
            GetComponentInChildren<SkinnedMeshRenderer>().material = EnemyDefaultMaterial;
        }
    }
}
