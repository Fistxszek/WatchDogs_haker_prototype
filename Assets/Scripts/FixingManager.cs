using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FixingManager : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> OnMinigameStart;
    private GameObject _tileToFix;
    public void Fixing(GameObject tileToFix)
    {
        _tileToFix = tileToFix;
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

    public void Unlock(GameObject tile)
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
        OnMinigameStart.Invoke(_tileToFix);
    }

    private int RandomNumber()
    {
        return Random.Range(0, 10);
    }
}
