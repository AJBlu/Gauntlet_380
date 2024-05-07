public interface IDamageable
{
    void assignDamageStats();
    void onDamage(int damageValue, Attacks attack);

    void onDeath(Attacks attackType);
}
