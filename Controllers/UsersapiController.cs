﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using AirLine;

namespace AirLine.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using AirLine;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<User>("Usersapi");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class UsersapiController : ODataController
    {
        private Ado db = new Ado();

        // GET: odata/Usersapi
        [EnableQuery]
        public IQueryable<User> GetUsersapi()
        {
            return db.Users;
        }

        // GET: odata/Usersapi(5)
        [EnableQuery]
        public SingleResult<User> GetUser([FromODataUri] int key)
        {
            return SingleResult.Create(db.Users.Where(user => user.UserID == key));
        }

        // PUT: odata/Usersapi(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<User> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = db.Users.Find(key);
            if (user == null)
            {
                return NotFound();
            }

            patch.Put(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(user);
        }

        // POST: odata/Usersapi
        public IHttpActionResult Post(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return Created(user);
        }

        // PATCH: odata/Usersapi(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<User> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = db.Users.Find(key);
            if (user == null)
            {
                return NotFound();
            }

            patch.Patch(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(user);
        }

        // DELETE: odata/Usersapi(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            User user = db.Users.Find(key);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int key)
        {
            return db.Users.Count(e => e.UserID == key) > 0;
        }
    }
}
