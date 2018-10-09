using UnityEngine;
using System.Collections;


namespace ObserverPattern
{
    //Events
    public abstract class BoxEvents
    {
        public abstract float GetJumpForce();
    }


    public class JumpLittle : BoxEvents
    {
        public override float GetJumpForce()
        {
            return 180f;
        }
    }


    public class JumpMedium : BoxEvents
    {
        public override float GetJumpForce()
        {
            return 300f;
        }
    }


    public class JumpHigh : BoxEvents
    {
        public override float GetJumpForce()
        {
            return 890f;
        }
    }
}