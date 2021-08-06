namespace DefaultNamespace
{
    public class WeaponWarder : IWeapon //посох
    {
        private string name { get; set; }
        public float damage { get; set; }
        public float speedOfDamage { get; set; }
        public float rangeOfDamage { get; set; }

        public WeaponWarder(string name, float damage, float speedOfDamage,float rangeOfDamage)
        {
            this.name = name;
            this.damage = damage;
            this.speedOfDamage = speedOfDamage;
            this.rangeOfDamage = rangeOfDamage;
        }
    }
}