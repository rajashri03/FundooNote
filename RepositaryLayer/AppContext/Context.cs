using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RepositaryLayer.Entities;

namespace RepositaryLayer.AppContext
{
	public class Context : DbContext
	{
		public Context(DbContextOptions options): base(options)
		{
		}
		public DbSet<UserEntity> Users { get; set; }
		public DbSet<NoteEntity> Notes { get; set; }
		public DbSet<CollabEntity> Collaborator { get; set; }
	}
}
