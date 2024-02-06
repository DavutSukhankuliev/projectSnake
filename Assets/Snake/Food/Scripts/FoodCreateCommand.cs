using System;
using SDTCore;

namespace Snake
{
    public class FoodCreateCommand : Command
    {
        private readonly FoodView.Pool _pool;
        private readonly FoodObjectProtocol _protocol;

        private FoodView _view;
        
        public FoodCreateCommand(
            FoodView.Pool pool, 
            FoodObjectProtocol protocol,
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

        public FoodView Get()
        {
            return _view != null ? _view : null;
        }
    }
}