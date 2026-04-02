using FungleAPI.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownOfTrailay.TotUtilities
{
    public static class TotTranslation
    {
        public static StringNames BaitName = new Translator("Bait")
            .AddTranslation(SupportedLangs.Brazilian, "Isca").StringName;
        public static StringNames BaitBlur = new Translator("If someone kills you, he will automaticlly self-report")
            .AddTranslation(SupportedLangs.Brazilian, "Se alguém te matar, essa pessoa ira reportar seu corpo automaticamente").StringName;


        public static StringNames VampireName = new Translator("Vampire")
            .AddTranslation(SupportedLangs.Brazilian, "Vampiro").StringName;
        public static StringNames VampireBlur = new Translator("You can bite others")
            .AddTranslation(SupportedLangs.Brazilian, "Você pode morder outros jogadores para eliminá-los com o tempo").StringName;
        public static StringNames VampireBite = new Translator("Bite")
            .AddTranslation(SupportedLangs.Brazilian, "Morder").StringName;

        public static Translator Vampire_BiteCooldown = new Translator("Bite Cooldown")
            .AddTranslation(SupportedLangs.Brazilian, "Recarga para morder");
        public static Translator Vampire_MurderDelay = new Translator("Murder Delay")
            .AddTranslation(SupportedLangs.Brazilian, "Demora para matar");


        public static void SetTranslationHelpers()
        {
            TranslationManager.TranslationIDs.Add("vampire_bitecooldown", Vampire_BiteCooldown);
            TranslationManager.TranslationIDs.Add("vampire_murderdelay", Vampire_MurderDelay);
        }
    }
}
