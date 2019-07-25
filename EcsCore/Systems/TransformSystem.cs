using Microsoft.Xna.Framework;
using EcsCore.Components;

namespace EcsCore.Systems
{
    public class TransformSystemFilter
    {
        public Transform Transform;
    }

    public class TransformSystem : EcsSystem<TransformSystemFilter>
    {
        public TransformSystem(EcsWorld world) : base(world)
        {
        }

        protected override void Process(int entity, TransformSystemFilter components, GameTime gameTime)
        {
            var transform = components.Transform;

            var translation = Matrix.CreateTranslation(transform.Position.X, transform.Position.Y, 0);
            var rotation = Matrix.CreateRotationZ(transform.Rotation);
            Matrix.Multiply(ref rotation, ref translation, out transform.LocalPose);

            int parentEntity;
            if (world.TryGetParent(entity, out parentEntity))
            {
                // Calculate the global pose from the local position and rotation, and the parent's global pose.
                var parentTransform = world.GetComponent<Transform>(parentEntity);
                Matrix.Multiply(ref transform.LocalPose, ref parentTransform.GlobalPose, out transform.GlobalPose);
            }
            else
            {
                transform.GlobalPose = transform.LocalPose;
            }
        }
    }
}