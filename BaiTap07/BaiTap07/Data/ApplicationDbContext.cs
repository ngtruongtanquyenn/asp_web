﻿using Microsoft.EntityFrameworkCore;
namespace BaiTap07.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        {

        }
    }
}
