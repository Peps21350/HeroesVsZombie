namespace DefaultNamespace
{
    public class NpcInfantryman : Npc
    {
        public NpcInfantryman(string name, float health,float currentHealth,float speedOfMovement, int price, int priceToSpawn) : base(name, health, currentHealth,speedOfMovement, priceToSpawn)
        {
            priceToUnlock = price;
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
        
       // private IWeapon m4 = new PoisonousBile("M4", 6,  4,  6);
    }
}