﻿using System;
using AlbumRating.Data;
using AlbumRating.Data.Models;
using AlbumRating.Models;
using AlbumRating.Services;
using AlbumRating.Services.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AlbumRating.Areas.Identity.IdentityHostingStartup))]
namespace AlbumRating.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AlbumRatingDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AlbumRatingContextConnection")));

                services.AddDefaultIdentity<User>()
                    .AddEntityFrameworkStores<AlbumRatingDbContext>();
            });
        }
    }
}