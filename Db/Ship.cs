using CommunityToolkit.Datasync.Server.EntityFrameworkCore;
using CommunityToolkit.Datasync.Server.LiteDb;
using System.ComponentModel.DataAnnotations;

namespace SevenShipsServer.Db
{
    public class Ship : LiteDbTableData
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public bool Operational { get; set; } = false;

    }
}
