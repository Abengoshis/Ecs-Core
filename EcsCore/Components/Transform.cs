using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace EcsCore.Components
{
    public class Transform : IEcsComponent
    {
        [ContentSerializer(Optional = true)]
        public Vector2 Position;

        [ContentSerializer(Optional = true)]
        public float Rotation;

        [ContentSerializerIgnore]
        public Matrix LocalPose = Matrix.Identity;

        [ContentSerializerIgnore]
        public Matrix GlobalPose = Matrix.Identity;

        public Transform(float x, float y, float rotation = 0f)
        {
            Position.X = x;
            Position.Y = y;
            Rotation = rotation;
        }

        public Transform(Vector2 position, float rotation = 0f) : this(position.X, position.Y, rotation)
        {
        }

        public Transform() : this(0, 0, 0)
        {
        }

        public Transform(Transform transform) : this(transform.Position, transform.Rotation)
        {
            LocalPose = transform.LocalPose;
            GlobalPose = transform.GlobalPose;
        }
    }
}
