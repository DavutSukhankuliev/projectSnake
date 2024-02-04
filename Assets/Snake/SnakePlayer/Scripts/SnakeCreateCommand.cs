using System;
using SDTCore;

namespace Snake
{
    public class SnakeCreateCommand : Command
    {
        private readonly SnakeView.Pool _pool;
        private readonly SnakeProtocol _protocol;

        private SnakeView _view;
        
        public SnakeCreateCommand(
            SnakeView.Pool pool, 
            SnakeProtocol protocol, 
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

        public SnakeView GetBody()
        {
            return _view;
            //todo: commandResult.Body
        }
    }
}