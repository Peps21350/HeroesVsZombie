namespace DefaultNamespace
{
    public class NpcWizard : Npc
    {
        public void init(string name, float health, float current_health,float speed_of_movement, int price_to_spawn, int price)
        {
            this.name = name;
            this.health = health;
            this.current_health = current_health;
            this.speed_of_movement = speed_of_movement;
            this.price_to_spawn = price_to_spawn;
            price_to_unlock = price;
        }

        public override void Give_damage()
        {
            throw new System.NotImplementedException();
        }

        public override void Take_damage()
        {
            throw new System.NotImplementedException();
        }

        public IWeapon weapon { get; set; }

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