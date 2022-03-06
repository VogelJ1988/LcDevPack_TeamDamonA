namespace LcDevPack_TeamDamonA.Tools.MemoryWorker
{
    internal class StrucAction

    {
#pragma warning disable CS0649 // Field 'StrucAction.index' is never assigned to, and will always have its default value 0
#pragma warning disable CS0649 // Field 'StrucAction.job' is never assigned to, and will always have its default value 0
#pragma warning disable CS0649 // Field 'StrucAction.iconRow' is never assigned to, and will always have its default value 0
#pragma warning disable CS0649 // Field 'StrucAction.iconID' is never assigned to, and will always have its default value 0
#pragma warning disable CS0649 // Field 'StrucAction.iconCol' is never assigned to, and will always have its default value 0
#pragma warning disable CS0649 // Field 'StrucAction.type' is never assigned to, and will always have its default value 0
        public int index, type, job, iconID, iconRow, iconCol;
#pragma warning restore CS0649 // Field 'StrucAction.type' is never assigned to, and will always have its default value 0
#pragma warning restore CS0649 // Field 'StrucAction.iconCol' is never assigned to, and will always have its default value 0
#pragma warning restore CS0649 // Field 'StrucAction.iconID' is never assigned to, and will always have its default value 0
#pragma warning restore CS0649 // Field 'StrucAction.iconRow' is never assigned to, and will always have its default value 0
#pragma warning restore CS0649 // Field 'StrucAction.job' is never assigned to, and will always have its default value 0
#pragma warning restore CS0649 // Field 'StrucAction.index' is never assigned to, and will always have its default value 0

#pragma warning disable CS0649 // Field 'StrucAction.name' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'StrucAction.descr' is never assigned to, and will always have its default value null
        public string name, descr;
#pragma warning restore CS0649 // Field 'StrucAction.descr' is never assigned to, and will always have its default value null
#pragma warning restore CS0649 // Field 'StrucAction.name' is never assigned to, and will always have its default value null



        public string menu //Nymp code
        {
            get
            {
                return this.index.ToString() + " - " + name;
            }
        }
    }
}
