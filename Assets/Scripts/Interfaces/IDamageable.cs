public interface IDamageable
{
    void assignDamageStats();
    void onDamage(int damageValue, Attacks attack, Hero hero);

    void onDeath(Attacks attackType, Hero hero);
}
