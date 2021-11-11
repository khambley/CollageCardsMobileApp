using System;
using System.Collections.Generic;

namespace MyCollageCardsMobileApp.Models
{
	public class Card
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Suit { get; set; }
		public string Description { get; set; }
		public string ImagePath { get; set; }
		public DateTime DateCreated { get; set; }
		public List<Note> Notes { get; set; }

	}
}
