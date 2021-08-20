using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] MoveController moveController;
    [SerializeField] PlayerController playerController;
    [SerializeField] CollisionHandler collisionHandler;
    [SerializeField] ShelterActor shelterActor;

    public CharacterController CharacterController => characterController;
    public MoveController MoveController => moveController;
    public PlayerController PlayerController => playerController;
    public CollisionHandler CollisionHandler => collisionHandler;
    public ShelterActor ShelterActor => shelterActor;
}
