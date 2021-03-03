using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using BeautyStoreDL.Entities;
using System;
using BSBL = BeautyStoreBL;
using BSDL = BeautyStoreDL;
using BeautyStoreDL;
using BeautyStoreBL;

namespace BeautyStoreAppUI
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Context
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

            string connectionString = config.GetConnectionString("AB");
            DbContextOptions<ABContext> options = new DbContextOptionsBuilder<ABContext>()
            .UseSqlServer(connectionString).Options;

            using var context = new ABContext(options);
            //End context

            IBeautyStoreMenu menu = new BeautyStoreMenu(new beautyStoreBL(new BeautyStoreRepo(context, new BeautyStoreMapper())));
           menu.Start();
        }
    }
}
