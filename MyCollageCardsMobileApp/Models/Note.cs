using System;
namespace MyCollageCardsMobileApp.Models
{
	public class Note
	{
		public int Id { get; set; }
		public DateTime DateCreated { get; set; }
		public string Text { get; set; }
		public Card Card { get; set; }
		public int CardId { get; set; }

	}
}
