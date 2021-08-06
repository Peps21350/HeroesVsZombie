namespace DefaultNamespace
{
    public class NpcBowman : Npc
    {
        public NpcBowman(string name, float health,float currentHealth,float speedOfMovement, int price) : base(name, health, currentHealth,speedOfMovement)
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
        
        //private IWeapon bow = new Bow("Bow",  7,  3,  5);
    }
}