using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using MyCollageCardsMobileApp.Models;
using Xamarin.Essentials;

namespace MyCollageCardsMobileApp.Services
{
	public class DataContext : DbContext
	{
		public DbSet<Card> Cards { get; set; }
		public DbSet<Note> Notes { get; set; }

		public DataContext()
		{
			//this is needed to initiate SQLite on iOS
			SQLitePCL.Batteries_V2.Init();

			this.Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// sets up location of the SQLite db on the physical device
			string dbPath = Path.Combine(FileSystem.AppDataDirectory, "myCollageCards.db3");

			optionsBuilder.UseSqlite($"Filename={dbPath}");
		}
	}

}
