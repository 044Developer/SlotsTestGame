using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomGeneratorHelper 
{
    private const float ProbabilityLuck = 0.25f;
    public static int GetRandomId(int maxCount)
    {
        float probability = Random.Range(0, 1f);
        if (probability < ProbabilityLuck)
            return 1;

        return Random.Range(0, maxCount);
    }
}
