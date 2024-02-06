using System;
using SDTCore;

namespace Snake
{
    public class ObstacleCreateCommand : Command
    {
        private readonly ObstacleView.Pool _pool;
        private readonly ObstacleProtocol _protocol;

        private ObstacleView _view;
        
        public ObstacleCreateCommand(
            ObstacleView.Pool pool, 
            ObstacleProtocol protocol, 
            CommandStorage commandStorage) : base(commandStorage)
        {
            _pool = pool;
            _protocol = protocol;
        }

        public override CommandResult Execute()
        {
            _view = _pool.Spawn(_protocol);
            
            Done?.Invoke(this, EventArgs.Empty);
            return base.Execute();
        }

        public override CommandResult Redo()
        {
            _pool.Despawn(_view);
            _view = null;
            
            Done?.Invoke(this, EventArgs.Empty);
            return base.Redo();
        }

        public ObstacleView GetBody()
        {
            return _view;
        }
    }
}