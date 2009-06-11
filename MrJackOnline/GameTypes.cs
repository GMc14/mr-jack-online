using System;

namespace MrJack
{
    public static class GameTypes
    {
        public enum SideType { Observer, Inspector, MrJack }
        public enum HexType { None, Street, Manhole, Gasslight, Building, Exit }
        public enum ExitDirectionType { NW, NE, SW, SE }
        public enum GasslightType { None, Light1, Light2, Light3, Light4, Light5, Light6 }
        public enum CharacterTypet { None = 1, Bert, BertInnocent, Goodley, GoodleyInnocent, Gull, GullInnocent, Holmes, HolmesInnocent, Lestrade, LestradeInnocent, Smith, SmithInnocent, Stealthy, StealthyInnocent, Watson1, WatsonInnocent1, Watson2, WatsonInnocent2, Watson3, WatsonInnocent3, Watson4, WatsonInnocent4, Watson5, WatsonInnocent5, Watson6, WatsonInnocent6 }
    }
}
