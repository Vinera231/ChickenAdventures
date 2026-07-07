using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const KeyCode JumpKey = KeyCode.Space;
    public const KeyCode SettingKey = KeyCode.Escape;
    public const KeyCode BuyKey = KeyCode.E;
    
    private bool _enabled;
    
    public event Action Jumped;
    public event Action SettingOnShower;
    public event Action MovementChanged;
    public event Action Buyed;

    public float Movement {  get; private set; }

    private void Update()
    {
        if (_enabled == false)
            return;

        ReadJump();
        ReadSetting();
        ReadMovement();
        ReadBuy();
    }

    public void Enable() =>    
        _enabled = true;
    
   
    public void Disable() =>   
        _enabled = false;
    
    private void ReadJump()
    {
        if (Input.GetKeyDown(JumpKey))
            Jumped?.Invoke();
    }
  
    private void ReadMovement()
    {
        float movement = Input.GetAxis("Horizontal");

        if(movement != Movement)
        {
            Movement = movement;
            MovementChanged?.Invoke();
        }       
    }
   
    private void ReadSetting()
    {
        if (Input.GetKeyDown(SettingKey))
            SettingOnShower?.Invoke();
    }
  
    private void ReadBuy()
    {
        if (Input.GetKeyDown(BuyKey))
            Buyed?.Invoke();
    }
}
