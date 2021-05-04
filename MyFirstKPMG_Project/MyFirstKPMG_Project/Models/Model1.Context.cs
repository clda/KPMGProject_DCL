﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyFirstKPMG_Project.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DARSHANEntities2 : DbContext
    {
        public DARSHANEntities2()
            : base("name=DARSHANEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblUserLoginDetail> tblUserLoginDetails { get; set; }
    
        public virtual ObjectResult<Proc_UserLogin_Result> Proc_UserLogin(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Proc_UserLogin_Result>("Proc_UserLogin", userNameParameter);
        }
    
        public virtual ObjectResult<Proc_ViewProductById_Result> Proc_ViewProductById(Nullable<int> productId)
        {
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Proc_ViewProductById_Result>("Proc_ViewProductById", productIdParameter);
        }
    
        public virtual ObjectResult<proc_ViewProducts_Result> proc_ViewProducts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_ViewProducts_Result>("proc_ViewProducts");
        }
    }
}