using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    int currentBirdIndex;
    //SlingShot
    [HideInInspector]
    public GameState gameState;
    private List<GameObject> bricks;
    private List<GameObject> birds;
    private List<GameObject> pigs;

    void Awake()
    {
        gameState = GameState.Start;
        bricks = new List<GameObject>(GameObject.FindGameObjectsWithTag("Brick"));
        birds = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bird"));
        pigs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pig"));
    }

    void OnEnable()
    {
        //attatch bird
    }

    void OnDisable()
    {
        //dispatch bird
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.Start:
                if (Input.GetMouseButton(0))
                {
                    AnimateBirdToSingleShot();
                }
                break;
            case GameState.Playing:
                break;
            case GameState.Won:
                break;
            case GameState.Lost:
                break;
            default:
                break;
        }
    }

    void AnimateBirdToSingleShot()
    {
        gameState = GameState.BirdMovingToSlingShot;
        //birds[currentBirdIndex].transform.positionTo();

    }

    bool BricksBirdPigsStoppedMOving()
    {
        foreach (GameObject item in bricks.Union(birds).Union(pigs))
        {
            if (item != null && item.GetComponent<Rigidbody2D>().velocity.sqrMagnitude > GameVariables.minVelocity) return false;

        }
        return true;
    }

    bool AllPigsAreDestroyed()
    {
        return pigs.All(x => x == null);
    }

    private void SlingShotBirdThrow()
    {
        CameraFollow.instance.birdToFollow = birds[currentBirdIndex].transform;
        CameraFollow.instance.isFollowing = true;
    }

    private void AnimateCameraToStartPosition()
    {
        float duration = Vector2.Distance(Camera.main.transform.position, CameraFollow.instance.startPosition) / 10.0f;
        if (duration == 0.0f)
        {
            duration = 0.1f;
        }
    }
}
