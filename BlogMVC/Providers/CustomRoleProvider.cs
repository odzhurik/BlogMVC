using BlogMVC.IoC;
using DAL.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogMVC.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
           IBlogRepository repository = DependencyResolver.Current.GetService<IBlogRepository>();
            return repository.GetRolesForUser(username).ToArray();
        }
        public override void CreateRole(string roleName)
        {
            IBlogRepository repository = DependencyResolver.Current.GetService<IBlogRepository>();
            repository.AddRole(roleName);
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            IBlogRepository repository = DependencyResolver.Current.GetService<IBlogRepository>();
            User user = repository.FindByName(username);
            if (user != null)
            {
                Role role = repository.GetRole(user.RoleID);
                if (role != null && role.Name == roleName)
                    outputResult = true;
            }
            return outputResult;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}