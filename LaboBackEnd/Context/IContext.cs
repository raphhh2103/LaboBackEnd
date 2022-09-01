using DbLabo.DbEntities;

namespace LaboBackEnd.Context
{
    public interface IContext
    {
        public UserEntity User { get; set; }
        public SkillEntity Skill { get; set; }
        public EquipmentEntity Equipment { get; set; }
        public ChampEntity Champ { get; set; }
        public BasicsStatisticEntity BasicsStatistic { get; set; }
        public AffinityChampEntity AffinityChamp { get; set; }
    }
}
