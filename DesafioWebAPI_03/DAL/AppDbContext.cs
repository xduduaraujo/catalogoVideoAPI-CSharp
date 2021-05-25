using Microsoft.EntityFrameworkCore;
using DesafioWebAPI_03.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI_03.DAL
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
	   : base(options)
		{
		}
		public virtual DbSet<Video> Videos { get; set; }
		public virtual DbSet<Responsavel> Responsaveis { get; set; }
		public virtual DbSet<Categoria> Categorias { get; set; }
		public virtual DbSet<VideoCategoria> VideoCategoria { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Video>(entity =>
			{
				entity.Property(x => x.Titulo).IsUnicode(false);
				entity.Property(x => x.URL).IsUnicode(false);
				entity.Property(x => x.IdadeMin).IsRequired(false);
				entity.HasOne(x => x.Responsavel).WithMany(y => y.Videos).HasForeignKey(x => x.IdResponsavel).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Responsavel>(entity =>
			{
				entity.Property(x => x.Nome).IsUnicode(false);
			});

			modelBuilder.Entity<Categoria>(entity =>
			{
				entity.Property(x => x.Nome).IsUnicode(false);
			});

			modelBuilder.Entity<VideoCategoria>(entity =>
			{
				entity.HasOne(x => x.Video).WithMany(y => y.VideoCategorias).HasForeignKey(x => x.IdVideo).OnDelete(DeleteBehavior.Restrict);
				
				entity.HasOne(x => x.Categoria).WithMany(y => y.VideoCategorias).HasForeignKey(x => x.IdCategoria).OnDelete(DeleteBehavior.Restrict);
			});
		}
	}
}