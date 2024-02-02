using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixingManager : MonoBehaviour
{
    public void Fixing(GameObject tileToFix)
    {
        Debug.Log(tileToFix.name);
        switch (RandomNumber())
        {
            case <= 7:
                StartMinigame();
                break;
            case 8:
                UnlockFail();
                break;
            case <= 9:
                Unlock(tileToFix);
                break;
        }
    }

    private void Unlock(GameObject tile)
    {
        Debug.Log("unlocked");
        tile.GetComponentInParent<BrokenPuzzle>().enabled = false;
    }

    private void UnlockFail()
    {
        Debug.LogError("FAIL");
    }
    private void StartMinigame()
    {
        Debug.LogWarning("minigame");
    }

    private int RandomNumber()
    {
        return Random.Range(0, 10);
    }
}
