using System;
using System.Collections;
using System.Diagnostics;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;
using Random = System.Random;

public class TreeGrower : MonoBehaviour
{
    public AnimationCurve growCurve;
    public Transform branchTransform;
    public float maxSpawnVariation;

    public float duration;
    public GameObject applePrefab;
    public float appleGrowDuration;
    private Coroutine treeGrowCoroutine;
    private Coroutine appleCoroutine;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private IEnumerator TreeGrowUpdate()
    {
        float progress = 0f;
        // contents of while run when condition is true
        while (progress < duration)
        {
            progress += Time.deltaTime;
            transform.localScale = growCurve.Evaluate(progress / duration) * Vector3.one;
            yield return null; // return an amount of time so everything else runs.
        }
        //yield return new WaitForSeconds(appleGrowDuration);
        appleCoroutine = StartCoroutine(appleGrowUpdate());

        yield return appleCoroutine;
        appleCoroutine = StartCoroutine(appleGrowUpdate());
        yield return appleCoroutine;
        appleCoroutine = StartCoroutine(appleGrowUpdate());
        yield return appleCoroutine;
    }
    private IEnumerator appleGrowUpdate() {
        Vector3 spawnPos = branchTransform.position;
        spawnPos += (Vector3)UnityEngine.Random.insideUnitCircle * maxSpawnVariation;
        float progress = 0f;
        GameObject spawnedApple = Instantiate(applePrefab, spawnPos, Quaternion.identity);
        spawnedApple.transform.localScale = Vector3.zero;

        while (progress < appleGrowDuration)
        {
            progress += Time.deltaTime;
            spawnedApple.transform.localScale = growCurve.Evaluate(progress / appleGrowDuration) * Vector3.one;
            yield return null;
        }

    }
    public void onGrowPress()
    {
        //Important!
        treeGrowCoroutine =  StartCoroutine(TreeGrowUpdate());
    }
    public void onStopPress()
    {
        //Important!
        if (treeGrowCoroutine != null)
        {
            StopCoroutine(treeGrowCoroutine);
            
        }
        if(appleCoroutine != null)
        {
            StopCoroutine(appleCoroutine);
        }
    }
}
