using Microsoft.EntityFrameworkCore;
using CollateralManagement.Collateral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollateralManagement.Models
{
    public class CollateralDbContext:DbContext
    {

        public CollateralDbContext(DbContextOptions<CollateralDbContext> options):base(options)
        {

        }

        public DbSet<Collaterals> CollateralLoans { get; set; }

        public DbSet<CollateralHouse> CollateralHouse { get; set; }
        public DbSet<CollateralLand> CollateralLand { get; set; }

        public DbSet<CollateralGold> CollateralGold { get; set; }


		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	ConfigureCollaterals(modelBuilder.Entity<Collaterals>());
		//	ConfigureLands(modelBuilder.Entity<CollateralLand>());
		//	ConfigureHouse(modelBuilder.Entity<CollateralHouse>());
		//	ConfigureGold(modelBuilder.Entity<CollateralGold>());

		//	base.OnModelCreating(modelBuilder);
		//}

    

  //      private void ConfigureCollaterals(EntityTypeBuilder<Collaterals> entityTypeBuilder)
  //      {
		//	entityTypeBuilder.ToTable("CollateralLoan");
		//	entityTypeBuilder.HasKey(c => c.Id);
		//	entityTypeBuilder.Property(c => c.Id).ValueGeneratedNever();

		//	entityTypeBuilder.Property(c => c.LoanId).IsRequired();
		//	entityTypeBuilder.Property(c => c.CustomerId).IsRequired();

		//	entityTypeBuilder.Property(c => c.CollateralType).IsRequired();

			
		//}

		//private void ConfigureLands(EntityTypeBuilder<CollateralLand> entityTypeBuilder)
		//{
		//	entityTypeBuilder.ToTable("CollateralLand");
		

		//	entityTypeBuilder.Property(c => c.LandOwner).IsRequired();

		//	entityTypeBuilder.Property(c => c.LandAddress).IsRequired();


		//	entityTypeBuilder.Property(c => c.LandArea).IsRequired();

		//	entityTypeBuilder.Property(c => c.Pricepersquarefeet).IsRequired();

		//	entityTypeBuilder.Property(c => c.LandDepriciationRate).IsRequired();

		//	entityTypeBuilder.Property(c => c.PledgedDate).IsRequired();




		//}

		//private void ConfigureHouse(EntityTypeBuilder<CollateralHouse> entityTypeBuilder)
		//{
		//	entityTypeBuilder.ToTable("CollateralHouse");
		

		//	entityTypeBuilder.Property(c => c.HouseOwner).IsRequired();

		//	entityTypeBuilder.Property(c => c.HouseAddress).IsRequired();

		//	entityTypeBuilder.Property(c => c.HouseArea).IsRequired();

		//	entityTypeBuilder.Property(c => c.YearinBuilt).IsRequired();

		//	entityTypeBuilder.Property(c => c.CurrentLandPricePerSqFt).IsRequired();

		//	entityTypeBuilder.Property(c => c.CurrentStructurePrice).IsRequired();

		//	entityTypeBuilder.Property(c => c.HouseDepriciationRate).IsRequired();

		//	entityTypeBuilder.Property(c => c.PledgedDate).IsRequired();



		//}

		//private void ConfigureGold(EntityTypeBuilder<CollateralGold> entityTypeBuilder)
		//{
		//	entityTypeBuilder.ToTable("CollateralGold");
		

		//	entityTypeBuilder.Property(c => c.GoldOwner).IsRequired();

		//	entityTypeBuilder.Property(c => c.GoldWeightinGrams).IsRequired();

		//	entityTypeBuilder.Property(c => c.GoldRateperGram).IsRequired();

		//	entityTypeBuilder.Property(c => c.GoldDepriciationRate).IsRequired();

		//	entityTypeBuilder.Property(c => c.GoldPledgedDate).IsRequired();





		//}



	}
}
