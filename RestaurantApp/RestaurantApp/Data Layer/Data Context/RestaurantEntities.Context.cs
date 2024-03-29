﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantApp.Data_Layer.Data_Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RestaurantEntities : DbContext
    {
        public RestaurantEntities()
            : base("name=RestaurantEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuProductJoin> MenuProductJoins { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonType> PersonTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
    
        public virtual ObjectResult<MenuProductJoin> SpFindAllProductsInMenu(Nullable<int> menu_id)
        {
            var menu_idParameter = menu_id.HasValue ?
                new ObjectParameter("menu_id", menu_id) :
                new ObjectParameter("menu_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MenuProductJoin>("SpFindAllProductsInMenu", menu_idParameter);
        }
    
        public virtual ObjectResult<MenuProductJoin> SpFindAllProductsInMenu(Nullable<int> menu_id, MergeOption mergeOption)
        {
            var menu_idParameter = menu_id.HasValue ?
                new ObjectParameter("menu_id", menu_id) :
                new ObjectParameter("menu_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MenuProductJoin>("SpFindAllProductsInMenu", mergeOption, menu_idParameter);
        }
    
        public virtual ObjectResult<Menu> SpFindMenuByCategory(string category)
        {
            var categoryParameter = category != null ?
                new ObjectParameter("category", category) :
                new ObjectParameter("category", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Menu>("SpFindMenuByCategory", categoryParameter);
        }
    
        public virtual ObjectResult<Menu> SpFindMenuByCategory(string category, MergeOption mergeOption)
        {
            var categoryParameter = category != null ?
                new ObjectParameter("category", category) :
                new ObjectParameter("category", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Menu>("SpFindMenuByCategory", mergeOption, categoryParameter);
        }
    
        public virtual ObjectResult<Menu> SpFindMenuByName(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Menu>("SpFindMenuByName", nameParameter);
        }
    
        public virtual ObjectResult<Menu> SpFindMenuByName(string name, MergeOption mergeOption)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Menu>("SpFindMenuByName", mergeOption, nameParameter);
        }
    
        public virtual ObjectResult<Order> SpFindOrderByUserId(Nullable<int> id_Person)
        {
            var id_PersonParameter = id_Person.HasValue ?
                new ObjectParameter("id_Person", id_Person) :
                new ObjectParameter("id_Person", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Order>("SpFindOrderByUserId", id_PersonParameter);
        }
    
        public virtual ObjectResult<Order> SpFindOrderByUserId(Nullable<int> id_Person, MergeOption mergeOption)
        {
            var id_PersonParameter = id_Person.HasValue ?
                new ObjectParameter("id_Person", id_Person) :
                new ObjectParameter("id_Person", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Order>("SpFindOrderByUserId", mergeOption, id_PersonParameter);
        }
    
        public virtual ObjectResult<Product> SpFindProductByCategory(string category)
        {
            var categoryParameter = category != null ?
                new ObjectParameter("category", category) :
                new ObjectParameter("category", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("SpFindProductByCategory", categoryParameter);
        }
    
        public virtual ObjectResult<Product> SpFindProductByCategory(string category, MergeOption mergeOption)
        {
            var categoryParameter = category != null ?
                new ObjectParameter("category", category) :
                new ObjectParameter("category", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("SpFindProductByCategory", mergeOption, categoryParameter);
        }
    
        public virtual ObjectResult<Product> SpFindProductByName(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("SpFindProductByName", nameParameter);
        }
    
        public virtual ObjectResult<Product> SpFindProductByName(string name, MergeOption mergeOption)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("SpFindProductByName", mergeOption, nameParameter);
        }
    
        public virtual ObjectResult<Person> SpFindUserByEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Person>("SpFindUserByEmail", emailParameter);
        }
    
        public virtual ObjectResult<Person> SpFindUserByEmail(string email, MergeOption mergeOption)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Person>("SpFindUserByEmail", mergeOption, emailParameter);
        }
    
        public virtual ObjectResult<Person> SpFindUserByEmailPassword(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Person>("SpFindUserByEmailPassword", emailParameter, passwordParameter);
        }
    
        public virtual ObjectResult<Person> SpFindUserByEmailPassword(string email, string password, MergeOption mergeOption)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Person>("SpFindUserByEmailPassword", mergeOption, emailParameter, passwordParameter);
        }
    
        public virtual int SpInsertMenuOrder(Nullable<int> id_Person, Nullable<int> id_Menu)
        {
            var id_PersonParameter = id_Person.HasValue ?
                new ObjectParameter("id_Person", id_Person) :
                new ObjectParameter("id_Person", typeof(int));
    
            var id_MenuParameter = id_Menu.HasValue ?
                new ObjectParameter("id_Menu", id_Menu) :
                new ObjectParameter("id_Menu", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpInsertMenuOrder", id_PersonParameter, id_MenuParameter);
        }
    
        public virtual int SpInsertProductOrder(Nullable<int> id_Product, Nullable<int> id_Person)
        {
            var id_ProductParameter = id_Product.HasValue ?
                new ObjectParameter("id_Product", id_Product) :
                new ObjectParameter("id_Product", typeof(int));
    
            var id_PersonParameter = id_Person.HasValue ?
                new ObjectParameter("id_Person", id_Person) :
                new ObjectParameter("id_Person", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpInsertProductOrder", id_ProductParameter, id_PersonParameter);
        }
    
        public virtual int SpInsertUser(string first_name, string last_name, string email, string password, string phone)
        {
            var first_nameParameter = first_name != null ?
                new ObjectParameter("first_name", first_name) :
                new ObjectParameter("first_name", typeof(string));
    
            var last_nameParameter = last_name != null ?
                new ObjectParameter("last_name", last_name) :
                new ObjectParameter("last_name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpInsertUser", first_nameParameter, last_nameParameter, emailParameter, passwordParameter, phoneParameter);
        }
    
        public virtual ObjectResult<Menu> SpSelectAllMenus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Menu>("SpSelectAllMenus");
        }
    
        public virtual ObjectResult<Menu> SpSelectAllMenus(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Menu>("SpSelectAllMenus", mergeOption);
        }
    
        public virtual ObjectResult<Product> SpSelectAllProducts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("SpSelectAllProducts");
        }
    
        public virtual ObjectResult<Product> SpSelectAllProducts(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("SpSelectAllProducts", mergeOption);
        }
    
        public virtual int SpDeleteOrderByProductId(Nullable<int> id_product)
        {
            var id_productParameter = id_product.HasValue ?
                new ObjectParameter("id_product", id_product) :
                new ObjectParameter("id_product", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpDeleteOrderByProductId", id_productParameter);
        }
    
        public virtual int SpUpdateOrderStatusByUserId(Nullable<int> user_id, Nullable<int> id_orderType)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(int));
    
            var id_orderTypeParameter = id_orderType.HasValue ?
                new ObjectParameter("id_orderType", id_orderType) :
                new ObjectParameter("id_orderType", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpUpdateOrderStatusByUserId", user_idParameter, id_orderTypeParameter);
        }
    }
}
