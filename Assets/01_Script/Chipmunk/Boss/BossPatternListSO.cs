using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "SO/BossPatternList", fileName = "BossPatternListSO")]
public class BossPatternListSO : ScriptableObject
{
    [SerializeField] public List<BossPattern> bossPatterns = new List<BossPattern>();
}
