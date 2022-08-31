using DbLabo.DbEntities;
using LaboBLL.ModelsBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboBLL.MapperBLL
{
    public static class BasicsStatisticMapper
    {
        public static BasicsStatisticEntity ToEntity(this BasicsStatisticBLL basicsStatistic)
        {
            return new BasicsStatisticEntity()
            {
                Atk = basicsStatistic.Atk,
                Def = basicsStatistic.Def,
                CriticalDamage = basicsStatistic.CriticalDamage,
                CriticalRate = basicsStatistic.CriticalRate,
                Hp = basicsStatistic.Hp,
                Precision = basicsStatistic.Precision,
                Resistor = basicsStatistic.Resistor,
                Vit = basicsStatistic.Vit,
                IdBasicsStatistic = basicsStatistic.IdBasicsStatistic,

            };
        }

        public static BasicsStatisticBLL ToBLL(this BasicsStatisticEntity basicsStatistic)
        {
            return new BasicsStatisticBLL()
            {
                Atk = basicsStatistic.Atk,
                Def = basicsStatistic.Def,
                CriticalDamage = basicsStatistic.CriticalDamage,
                CriticalRate = basicsStatistic.CriticalRate,
                Hp = basicsStatistic.Hp,
                Precision = basicsStatistic.Precision,
                Resistor = basicsStatistic.Resistor,
                Vit = basicsStatistic.Vit,
                IdBasicsStatistic = basicsStatistic.IdBasicsStatistic,
            };
        }



    }
}
