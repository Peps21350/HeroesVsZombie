namespace DefaultNamespace
{
    public class NpcWizard : Npc
    {
        public NpcWizard(string name, float health,float current_health,float speedOfMovement ,int price) : base(name, health, current_health, speedOfMovement)
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

        //private IWeapon warder = new Warder("Warder",  10,  3,  3);
    }
}