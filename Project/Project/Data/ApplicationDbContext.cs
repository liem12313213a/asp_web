﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TheLoai> TheLoai { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<GioHang> GioHang { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public DbSet<NhaCungCap> NhaCungCap { get; set; }

    }
}
