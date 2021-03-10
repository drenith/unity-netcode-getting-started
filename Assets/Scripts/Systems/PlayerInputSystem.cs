using Unity.Entities;
using System;
using UnityEngine;

public class PlayerInputSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref MoveData moveData, in InputData inputData) => {
            bool isRightPressed = Input.GetKey(inputData.rightKey);
            bool isLeftPressed = Input.GetKey(inputData.leftKey);
            bool isForwardPressed = Input.GetKey(inputData.forwardKey);
            bool isBackPressed = Input.GetKey(inputData.backKey);
            bool isUpPressed = Input.GetKey(inputData.upKey);
            bool isResetPressed = Input.GetKey(inputData.resetKey);

            moveData.direction.x = Convert.ToInt32(isRightPressed);
            moveData.direction.x -= Convert.ToInt32(isLeftPressed);
            moveData.direction.z = Convert.ToInt32(isForwardPressed);
            moveData.direction.z -= Convert.ToInt32(isBackPressed);
            moveData.direction.y = Convert.ToInt32(isUpPressed);

            moveData.reset = isResetPressed;
        }).Run();
    }
}