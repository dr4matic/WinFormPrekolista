using System.Formats.Asn1;

namespace GameEngine.Common.Entitys
{
    public record UserInfo(int Id, string Name, uint score)
    {

        public UserInfo(string name) : this(0, name, 0)
        {

        }
    }

}
