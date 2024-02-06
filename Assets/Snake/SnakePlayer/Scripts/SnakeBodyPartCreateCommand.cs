using System;
using SDTCore;

namespace Snake
{
    public class SnakeBodyPartCreateCommand : Command
    {
        private readonly SnakeBodyPartView.Pool _pool;
        private readonly SnakeProtocol _bodyPartProtocol;

        private SnakeBodyPartView _bodyPartView;
        
        public SnakeBodyPartCreateCommand(
            SnakeBodyPartView.Pool pool, 
            SnakeProtocol bodyPartProtocol, 
            CommandStorage commandStorage) : base(commandStorage)
        {
            _pool = pool;
            _bodyPartProtocol = bodyPartProtocol;
        }

        public override CommandResult Execute()
        {
            _bodyPartView = _pool.Spawn(_bodyPartProtocol);
            
            Done?.Invoke(this, EventArgs.Empty);
            return base.Execute();
        }

        public override CommandResult Redo()
        {
            _pool.Despawn(_bodyPartView);
            _bodyPartView = null;
            
            Done?.Invoke(this, EventArgs.Empty);
            return base.Redo();
        }

        public SnakeBodyPartView GetBody()
        {
            return _bodyPartView;
            //todo: commandResult.Body
        }
    }
}