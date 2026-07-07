using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Detector : MonoBehaviour
{
    public event Action<Collider2D> Detected;
    public event Action<Collider2D> Missing;

    private void OnTriggerEnter2D(Collider2D collision) =>
        Detected?.Invoke(collision);

    private void OnTriggerExit2D(Collider2D collision) =>
        Missing?.Invoke(collision);

    private void OnCollisionEnter2D(Collision2D collision) =>
         Detected?.Invoke(collision.collider);

    private void OnCollisionExit2D(Collision2D collision) =>
          Missing?.Invoke(collision.collider);
}