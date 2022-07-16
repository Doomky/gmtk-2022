namespace Code.Enums
{
    public enum ProjectileStates
    {
        /// <summary>
        /// The projectile is spawned, do any spawn anims etc
        /// </summary>
        Spawning,
        
        /// <summary>
        /// The projectile is moving
        /// </summary>
        Moving,
        
        /// <summary>
        /// The projectile is colling (anim?)
        /// </summary>
        Colliding,
        
        /// <summary>
        /// The projectile is dead and should be cleaned up
        /// </summary>
        Dead
    }
}