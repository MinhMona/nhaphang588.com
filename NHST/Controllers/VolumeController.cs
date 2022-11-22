using NHST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using Telerik.Web.Data.Extensions;

namespace NHST.Controllers
{
    public class VolumeController 
    {
        public static List<GetVolumeList_Result> GetAllVolumeList(string searchText, int pageSize, int pageIndex)
        {
            using (var db = new NHSTEntities())
            {
                return db.GetVolumeList( searchText, pageSize, pageIndex).ToList();
            }
        }

        public static List<tbl_Volume> GetAllByFromWareHouseToWareHouse(int fromWareHouse, int toWareHouse, int shippingType, bool orderType)
        {
            using (var db = new NHSTEntities())
            {
                return db.tbl_Volume.Where(x => x.WarehouseFromID== fromWareHouse && x.WarehouseToID == toWareHouse && x.ShippingTypeToWareHouseID== shippingType && x.IsHelpMoving == orderType).ToList();
            }
        }

        public static string InsertVolume(tbl_Volume model)
        {
            using (var db = new NHSTEntities())
            {
                db.tbl_Volume.Add(model);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                return "1";
            }
        }

        public static string DeleteVolume(int ID)
        {
            using (var db = new NHSTEntities())
            {
                var entity= db.tbl_Volume.Where(x => x.ID == ID).FirstOrDefault();
                db.tbl_Volume.Remove(entity);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                return "1";
            }
        }

        public static tbl_Volume GetByID(int ID)
        {
            using (var db = new NHSTEntities())
            {
                return db.tbl_Volume.Where(x => x.ID == ID).FirstOrDefault();
            }
        }

        public static string UpdateVolume(tbl_Volume model)
        {
            using (var db = new NHSTEntities())
            {
                db.tbl_Volume.AddOrUpdate(model);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                return "1";
            }
        }

    }
}