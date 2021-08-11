namespace DefaultNamespace
{
    public class NpcWizard : Npc
    {


        public IWeapon weapon => new WeaponWarder("Warder",  10,  3,  3);

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