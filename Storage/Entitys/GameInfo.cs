using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Entitys
{
    public record GameInfo
    {
        
        public int Id { get; init; }
        
        public string Name { get; init; }
        
        public int GameType { get; init; }
        
        public string Json { get; init; }

        
        
    }
}
