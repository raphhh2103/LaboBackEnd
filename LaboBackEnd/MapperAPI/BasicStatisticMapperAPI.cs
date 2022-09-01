using LaboBackEnd.ModelsAPI;
using LaboBLL.ModelsBLL;

namespace LaboBackEnd.MapperAPI
{
    public static class BasicStatisticMapperAPI
    {

        public static BasicsStatisticBLL ToBLL(this BasicStatisticAPI basicStatistic)
        {
            return new BasicsStatisticBLL()
            {
                Atk = basicStatistic.Atk,
                Def= basicStatistic.Def,
                CriticalDamage = basicStatistic.CriticalDamage,
                CriticalRate = basicStatistic.CriticalRate,
                Hp = basicStatistic.Hp,
                IdBasicsStatistic = basicStatistic.IdBasicsStatistic,
                Precision = basicStatistic.Precision,
                Resistor = basicStatistic.Resistor,
                Vit=basicStatistic.Vit,

            };
        }
        public static BasicStatisticAPI ToAPI(this BasicsStatisticBLL basicsStatistic)
        {
            return new BasicStatisticAPI()
            {
                Atk = basicStatistic.Atk,
                Def = basicStatistic.Def,
                CriticalDamage = basicStatistic.CriticalDamage,
                CriticalRate = basicStatistic.CriticalRate,
                Hp = basicStatistic.Hp,
                IdBasicsStatistic = basicStatistic.IdBasicsStatistic,
                Precision = basicStatistic.Precision,
                Resistor = basicStatistic.Resistor,
                Vit = basicStatistic.Vit,
            };
        }

    }
}
