using FateGames.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwerveIndicator : MonoBehaviour
{
    [SerializeField] RectTransform outCircle, inCircle;
    
    public void SetOutCirclePosition(Swerve swerve)
    {
        outCircle.position = swerve.AnchorPosition;
    }

    public void SetInCirclePosition(Swerve swerve)
    {
        inCircle.position = swerve.MousePosition;
    }
}
