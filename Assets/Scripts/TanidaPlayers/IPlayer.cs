namespace TanidaPlayers
{
    public interface IPlayer
    {
        public void Jump();
        public void Heal(int value = 1);
        public void Damage(int value);
        public void IncreasePossibleDoubleJumpCount(int value = 1);
    }
}