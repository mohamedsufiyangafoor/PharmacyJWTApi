using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PharmacyJWTApi.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetail>().HasData(
            new UserDetail() { User_id = 1, User_name = "varun", Email_id = "varun@abc.com", Password = "Varun@1234", Mobile_no = "9897124588", Address = "sector 25 delhi", Age = 20, Role= "Admin"},
            new UserDetail() { User_id = 2, User_name = "Nikhil", Email_id = "Nikhil@abc.com", Password = "Nikhil@1234", Mobile_no = "9897125599", Address = "sector 20 delhi", Age = 22, Role="User"}
            );
        }
    }
}
