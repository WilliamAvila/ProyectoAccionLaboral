﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Proyecto_AccionLaboral.Models;

namespace Proyecto_AccionLaboral.Controllers
{
    public class TrackingTypesController : ApiController
    {
        private Proyecto_AccionLaboralContext db = new Proyecto_AccionLaboralContext();

        // GET api/TrackingTypes
        public IQueryable<TrackingType> GetTrackingTypes()
        {
            return db.TrackingTypes;
        }

        // GET api/TrackingTypes/5
        [ResponseType(typeof(TrackingType))]
        public IHttpActionResult GetTrackingType(int id)
        {
            TrackingType trackingtype = db.TrackingTypes.Find(id);
            if (trackingtype == null)
            {
                return NotFound();
            }

            return Ok(trackingtype);
        }

        // PUT api/TrackingTypes/5
        public IHttpActionResult PutTrackingType(int id, TrackingType trackingtype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trackingtype.TrackingTypeId)
            {
                return BadRequest();
            }

            db.Entry(trackingtype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackingTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/TrackingTypes
        [ResponseType(typeof(TrackingType))]
        public IHttpActionResult PostTrackingType(TrackingType trackingtype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrackingTypes.Add(trackingtype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trackingtype.TrackingTypeId }, trackingtype);
        }

        // DELETE api/TrackingTypes/5
        [ResponseType(typeof(TrackingType))]
        public IHttpActionResult DeleteTrackingType(int id)
        {
            TrackingType trackingtype = db.TrackingTypes.Find(id);
            if (trackingtype == null)
            {
                return NotFound();
            }

            db.TrackingTypes.Remove(trackingtype);
            db.SaveChanges();

            return Ok(trackingtype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackingTypeExists(int id)
        {
            return db.TrackingTypes.Count(e => e.TrackingTypeId == id) > 0;
        }
    }
}