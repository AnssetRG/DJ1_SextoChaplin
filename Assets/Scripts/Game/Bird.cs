using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private BirdState birdState { set; get; }
    private TrailRenderer trailRenderer;
    private Rigidbody2D body;
    private CircleCollider2D collider;
    private AudioSource source;
    void Awake()
    {
        InitVariables();
    }

    void InitVariables()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        source = GetComponent<AudioSource>();
        trailRenderer.enabled = false;
        body.isKinematic = true;
        collider.radius = GameVariables.birdColliderRadiusBig;
        birdState = BirdState.BeforeThrown;
    }

    public void OnThrow()
    {
        source.Play();
        trailRenderer.enabled = true;
        body.isKinematic = false;
        collider.radius = GameVariables.birdColliderRadiusNormal;
        birdState = BirdState.Thrown;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    void GoLevel()
    {
    }
}