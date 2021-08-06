namespace DefaultNamespace
{
    public class WeaponSpear : IWeapon
    {
        private string name { get; set; }
        public float damage { get; set; }
        public float speedOfDamage { get; set; }
        public float rangeOfDamage { get; set; }

        public WeaponSpear(string name, float damage, float speedOfDamage,float rangeOfDamage)
        {
            this.name = name;
            this.damage = damage;
            this.speedOfDamage = speedOfDamage;
            this.rangeOfDamage = rangeOfDamage;
        }
    }
}