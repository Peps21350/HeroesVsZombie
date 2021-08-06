namespace DefaultNamespace
{
    public class NpcHard_zombie : Npc
    {
        public NpcHard_zombie(string name, float health,float currentHealth,float speedOfMovement) : base(name, health, currentHealth,speedOfMovement)
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

            // $" Name: {Name}
            // Health: {Health}
            // Price to unlock: {Price}
            // Damage: 
        }
        
       // private IWeapon hard_bile = new PoisonousBile("Hard bile", 12,  3,  5);
    }
}