using System;
using SDTCore;

namespace Snake
{
    public class GridCellCreateCommand : Command
    {
        private readonly GridCellView.Pool _pool;
        private readonly GridCellProtocol _protocol;

        private GridCellView _view;
        
        public GridCellCreateCommand(
            GridCellView.Pool pool, 
            GridCellProtocol protocol, 
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
    }
}