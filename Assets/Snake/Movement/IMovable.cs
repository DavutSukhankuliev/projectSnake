namespace Snake
{
    public interface IMovable
    {
        MovementDirection CurrentDirection { get; }
        void MoveTo(MovementDirection movementDirection);
    }
}