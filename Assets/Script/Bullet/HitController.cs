using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class HitController : MonoBehaviour
{
    
    private void OnSpawned()
    {
        StartCoroutine(WaitHit());
    }

    IEnumerator WaitHit()
    {
        yield return new WaitForSeconds(0.5f);
        BYPoolManager.poolInstance.DeSpawn("hitEnemy", transform);
       
    }
}
