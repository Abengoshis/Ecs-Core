using Microsoft.Xna.Framework;

namespace EcsCore.Components
{
    public class Transform : IEcsComponent
    {
        public Matrix LocalPose;
        public Matrix GlobalPose;

        public Vector2 Position;
        public float Rotation;

        public Transform(Vector2 position, float rotation = 0f)
        {
            LocalPose = Matrix.Identity;
            GlobalPose = Matrix.Identity;

            Position = position;
            Rotation = rotation;
        }

        public Transform(float x, float y, float rotation = 0f) : this(new Vector2(x, y), rotation)
        {
        }
    }
}
