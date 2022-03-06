namespace LcDevPack_TeamDamonA.Tools
{
    public class tLucky
    {
#pragma warning disable CS0649 // Field 'tLucky.a_index' is never assigned to, and will always have its default value 0
        readonly int a_index;
#pragma warning restore CS0649 // Field 'tLucky.a_index' is never assigned to, and will always have its default value 0
#pragma warning disable CS0649 // Field 'tLucky.a_name' is never assigned to, and will always have its default value null
        readonly string a_name;
#pragma warning restore CS0649 // Field 'tLucky.a_name' is never assigned to, and will always have its default value null
#pragma warning disable CS0169 // The field 'tLucky.a_enable' is never used
        readonly char a_enable;
#pragma warning restore CS0169 // The field 'tLucky.a_enable' is never used
#pragma warning disable CS0169 // The field 'tLucky.a_random' is never used
        readonly int a_random;
#pragma warning restore CS0169 // The field 'tLucky.a_random' is never used
        public string list_name
        {
            get
            {
                return a_index.ToString() + " - " + a_name;

            }
        }
    }
    public class TLuckyResult : tLucky
    {
#pragma warning disable CS0169 // The field 'TLuckyResult.a_prob' is never used
#pragma warning disable CS0169 // The field 'TLuckyResult.a_index' is never used
#pragma warning disable CS0169 // The field 'TLuckyResult.a_upgrade' is never used
#pragma warning disable CS0169 // The field 'TLuckyResult.a_luckydraw_idx' is never used
#pragma warning disable CS0169 // The field 'TLuckyResult.a_category' is never used
#pragma warning disable CS0169 // The field 'TLuckyResult.a_item_idx' is never used
#pragma warning disable CS0169 // The field 'TLuckyResult.a_flag' is never used
#pragma warning disable CS0169 // The field 'TLuckyResult.a_count' is never used
        readonly int a_index, a_luckydraw_idx, a_item_idx, a_count, a_upgrade, a_prob, a_flag, a_category;
#pragma warning restore CS0169 // The field 'TLuckyResult.a_count' is never used
#pragma warning restore CS0169 // The field 'TLuckyResult.a_flag' is never used
#pragma warning restore CS0169 // The field 'TLuckyResult.a_item_idx' is never used
#pragma warning restore CS0169 // The field 'TLuckyResult.a_category' is never used
#pragma warning restore CS0169 // The field 'TLuckyResult.a_luckydraw_idx' is never used
#pragma warning restore CS0169 // The field 'TLuckyResult.a_upgrade' is never used
#pragma warning restore CS0169 // The field 'TLuckyResult.a_index' is never used
#pragma warning restore CS0169 // The field 'TLuckyResult.a_prob' is never used
    }

    public class TLuckyNeed : tLucky
    {
#pragma warning disable CS0169 // The field 'TLuckyNeed.a_luckydraw_idx' is never used
#pragma warning disable CS0169 // The field 'TLuckyNeed.a_item_idx' is never used
#pragma warning disable CS0169 // The field 'TLuckyNeed.a_index' is never used
#pragma warning disable CS0169 // The field 'TLuckyNeed.a_count' is never used
        readonly int a_index, a_luckydraw_idx, a_item_idx, a_count;
#pragma warning restore CS0169 // The field 'TLuckyNeed.a_count' is never used
#pragma warning restore CS0169 // The field 'TLuckyNeed.a_index' is never used
#pragma warning restore CS0169 // The field 'TLuckyNeed.a_item_idx' is never used
#pragma warning restore CS0169 // The field 'TLuckyNeed.a_luckydraw_idx' is never used
    }
}
