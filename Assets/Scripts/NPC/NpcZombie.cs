namespace DefaultNamespace
{
    public class NpcZombie : Npc
    {
        public NpcZombie(string name, float health,float currentHealth,float speedOfMovement) : base(name, health, currentHealth,speedOfMovement)
        {
        }

        public override void Give_damage()
        {
            throw new System.NotImplementedException();
        }

        public override void Take_damage()
        {
            throw new System.NotImplementedException();
        }
        public override IWeapon weapon { get; set; }
        
        public override void Display_information()
        {
            throw new System.NotImplementedException();
            // $" Name: {Name}
            // Health: {Health}
            // Price to unlock: {Price}
            // Damage: 
        }
       // private IWeapon bile = new PoisonousBile("Bile",  8,  3,  4);
    }
}
