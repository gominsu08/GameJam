using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossPatternStop : MonoBehaviour
{
    [SerializeField] private List<GameObject> BossPaternList = new List<GameObject>();

    

    List<GameObject> gameObjects = new List<GameObject>();


    private void Update()
    {
        if(FindAnyObjectByType<BossPattern>() == null) return;

        Destroy(FindAnyObjectByType<BossPattern>().gameObject);
    }



}
