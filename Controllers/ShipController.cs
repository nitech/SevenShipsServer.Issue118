using CommunityToolkit.Datasync.Server.EntityFrameworkCore;
using CommunityToolkit.Datasync.Server;
using Microsoft.AspNetCore.Mvc;
using SevenShipsServer.Db;
using CommunityToolkit.Datasync.Server.LiteDb;
using LiteDB;

namespace SevenShipsServer.Controllers
{
    [Route("tables/[controller]")]
    public class ShipController : TableController<Ship>
    {
        public ShipController(LiteDatabase db) : base(new LiteDbRepository<Ship>(db, "ships"))
        {
        }
    }
}
