using System;
using Modding;

namespace U_tils
{
    public class U_tilsMod : Mod
    {

        public static float HeroX;
        public static float HeroY;
        public static float HeroZ;


        private static U_tilsMod? _instance;

        internal static U_tilsMod Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException($"An instance of {nameof(U_tilsMod)} was never constructed");
                }
                return _instance;
            }
        }

        public override string GetVersion() => GetType().Assembly.GetName().Version.ToString();

        public U_tilsMod() : base("U_tils")
        {
            _instance = this;
        }

        public override void Initialize()
        {
            Log("Initializing");

            // put additional initialization logic here
            On.HeroController.Update += SetHeroPos;
            Log("Initialized");
        }

        public void SetHeroPos(On.HeroController.orig_Update orig, HeroController self)
        {
            HeroX = self.transform.position.x;
            HeroY = self.transform.position.y;
            HeroZ = self.transform.position.z;
        }

    }
}
