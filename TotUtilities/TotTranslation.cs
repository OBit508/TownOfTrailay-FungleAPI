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
    }
}
