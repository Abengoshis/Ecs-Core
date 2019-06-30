using Microsoft.Xna.Framework;

namespace EcsCore.Systems
{
    public interface IEcsSystem
    {
        void Process(GameTime gameTime);
    }
}
