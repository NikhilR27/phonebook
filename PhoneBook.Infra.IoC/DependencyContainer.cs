﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;
using PhoneBook.Infra.Data.Context;
using PhoneBook.Infra.Data.Repository;

namespace PhoneBook.Infra.IoC
{
    public class DependencyContainer
    {
        public static IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //Data
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            services.AddDbContext<DbContext, PhoneBookContext>(options => options.UseNpgsql(connectionString));
            services.AddTransient<IRepositoryBase<Phonebook>, RepositoryBase<Phonebook>>();
            services.AddTransient<IRepositoryBase<Entry>, RepositoryBase<Entry>>();

            //Application
            services.AddTransient<IPhoneBookService, PhoneBookService>();
            return services;
        }
    }
}
