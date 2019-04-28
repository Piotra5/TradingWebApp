using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TradingApp.Models.Instruments;
using TradingApp.Models.InstrumentsMarketData;
using TradingApp.Models.Trades;

namespace TradingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<InstrumentMarketDataService> InstrumentsMarketData { get; set; }
        public DbSet<Trade> Trades { get; set; }
    }
}
