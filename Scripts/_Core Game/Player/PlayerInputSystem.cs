using PlayerInputMap;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.InputSystem
{
    public class PlayerInputSystem : MonoBehaviour
    {
        public PlayerInputSystemMap playerInputSystemMap;
        public InputAction LookInputAction { get; private set; }
        public InputAction MoveInputAction { get; private set; }
        public InputAction ShootInputAction { get; private set; }
        public InputAction AimInputAction { get; private set; }
        public InputAction RunInputAction { get; private set; }
        public InputAction JumpInputAction { get; private set; }
        public InputAction InventoryInputAction { get; private set; }
        public InputAction CrouchInputAction { get; private set; }
        public InputAction InteractInputAction { get; private set; }
        public InputAction FlashlightInputAction { get; private set; }
        public InputAction ReloadInputAction { get; private set; }
        public InputAction HealInputAction { get; private set; }
        public InputAction Item_1_InputAction { get; private set; }
        public InputAction Item_2_InputAction { get; private set; }
        public InputAction Item_3_InputAction { get; private set; }
        public InputAction Item_4_InputAction { get; private set; }
        public InputAction Item_5_InputAction { get; private set; }
        public InputAction Item_6_InputAction { get; private set; }
        public InputAction Item_7_InputAction { get; private set; }
        public InputAction Item_8_InputAction { get; private set; }
        public InputAction Item_9_InputAction { get; private set; }
        public InputAction MouseScroll { get; private set; }
        public InputAction GamepadLeftShoulder { get; private set; }
        public InputAction GamepadRightShoulder { get; private set; }

        public void Setup()
        {
            playerInputSystemMap = new PlayerInputSystemMap();

            LookInputAction = playerInputSystemMap.Player.Look;
            MoveInputAction = playerInputSystemMap.Player.Move;
            ShootInputAction = playerInputSystemMap.Player.Shoot;
            AimInputAction = playerInputSystemMap.Player.Aim;
            RunInputAction = playerInputSystemMap.Player.Run;
            JumpInputAction = playerInputSystemMap.Player.Jump;
            InventoryInputAction = playerInputSystemMap.Player.Inventory;
            CrouchInputAction = playerInputSystemMap.Player.Crouch;
            InteractInputAction = playerInputSystemMap.Player.Interact;
            FlashlightInputAction = playerInputSystemMap.Player.Flashlight;
            ReloadInputAction = playerInputSystemMap.Player.Reload;
            HealInputAction = playerInputSystemMap.Player.Heal;
            Item_1_InputAction = playerInputSystemMap.Player.Item_1;
            Item_2_InputAction = playerInputSystemMap.Player.Item_2;
            Item_3_InputAction = playerInputSystemMap.Player.Item_3;
            Item_4_InputAction = playerInputSystemMap.Player.Item_4;
            Item_5_InputAction = playerInputSystemMap.Player.Item_5;
            Item_6_InputAction = playerInputSystemMap.Player.Item_6;
            Item_7_InputAction = playerInputSystemMap.Player.Item_7;
            Item_8_InputAction = playerInputSystemMap.Player.Item_8;
            Item_9_InputAction = playerInputSystemMap.Player.Item_9;
            MouseScroll = playerInputSystemMap.Player.MouseScroll;
            GamepadLeftShoulder = playerInputSystemMap.Player.GamepadLeftShoulder;
            GamepadRightShoulder = playerInputSystemMap.Player.GamepadRightShoulder;
        }

        public bool IsShootPressed()
        {
            return ShootInputAction.IsPressed();
        }

        public bool IsAimPressed()
        {
            return AimInputAction.IsPressed();
        }

        public void Enable()
        {
            playerInputSystemMap.Enable();
        }

        public void Disable()
        {
            playerInputSystemMap.Disable();
        }
    }
}
