using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;
using SpikeDemo.EFCore;

namespace SpikeDemo.Model
{
    public class DbHelper
    {
 
            private UutMountingContext _context;
       
        public DbHelper(UutMountingContext context)
            {
                _context = context;
            }

        //GET UUT DATA
            public List<UutMountingInformation> GetUutData()
            {
                List<UutMountingInformation> response = new List<UutMountingInformation>();
                var dataList = _context.UutMountingData.ToList();
                dataList.ForEach(row => response.Add(new UutMountingInformation()
                {
                   UutId  = row.UutId,
                   SlotId = row.SlotId,
                   ChamberId = row.ChamberId,   
                   //MeasurementConfigurations = row.MeasurementConfigurations,
                   NumberOfMeasurementPoints = row.NumberOfMeasurementPoints,
                }));
                return response;
            }

        //GET MEASUREMENT DATA
            public List<MeasurementConfiguration> GetMeasurementData()
             {
            List<MeasurementConfiguration> response = new List<MeasurementConfiguration>();
            var dataList = _context.MeasurementConfigurationData.ToList();
            dataList.ForEach(row => response.Add(new MeasurementConfiguration()
            {
              MeasurementId = row.MeasurementId,    
              MappedResource = row.MappedResource,
              MeasurementPoint= row.MeasurementPoint
            }));
            return response;
        }

        //GET UUT BY ID
        public UutMountingInformation GetUutById(int id)
            {
            UutMountingInformation response = new UutMountingInformation();
                var row = _context.UutMountingData.Where(d => d.UutId.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return new UutMountingInformation()
                {
                    UutId = row.UutId,
                    SlotId = row.SlotId,
                    ChamberId = row.ChamberId,
                    //MeasurementConfigurations = row.MeasurementConfigurations,
                    NumberOfMeasurementPoints = row.NumberOfMeasurementPoints
                };
            }
            else
                return null;
        }
        //POST UUT
        public void SaveUut(UutMountingInformation orderModel)
            {
            UutMountingInformation dbTable = new UutMountingInformation();
            dbTable.UutId = orderModel.UutId;
            dbTable.SlotId= orderModel.SlotId;
                    dbTable.ChamberId = orderModel.ChamberId;
                    //dbTable.MeasurementConfigurations = orderModel.MeasurementConfigurations;
                    dbTable.NumberOfMeasurementPoints = orderModel.NumberOfMeasurementPoints;
                    _context.UutMountingData.Add(dbTable);
                
                _context.SaveChanges();
            }

        //UPDATE UUT
        public void UpdateUut(UutMountingInformation orderModel)
        {
            UutMountingInformation dbTable = new UutMountingInformation();
            dbTable = _context.UutMountingData.Where(d => d.UutId.Equals(orderModel.UutId)).FirstOrDefault();
            if (dbTable != null)
            {
                dbTable.SlotId=orderModel.SlotId;
                dbTable.ChamberId = orderModel.ChamberId;
                dbTable.NumberOfMeasurementPoints = orderModel.NumberOfMeasurementPoints;
            }
            _context.SaveChanges();
        }
        //POST MEASUREMENT DATA
        public void saveMeasurementData(MeasurementConfiguration productModel)
        {
            MeasurementConfiguration dbTable =new MeasurementConfiguration();
            dbTable.MeasurementId = productModel.MeasurementId;
            dbTable.MeasurementPoint = productModel.MeasurementPoint;
            dbTable.MappedResource = productModel.MappedResource;
           
            _context.MeasurementConfigurationData.Add(dbTable);
            _context.SaveChanges();
        }
          
        // DELETE UUT
       
            public void DeleteUut(string id)
            {
                var order = _context.UutMountingData.Where(d => d.UutId.Equals(id)).FirstOrDefault();
                if (order != null)
                {
                    _context.UutMountingData.Remove(order);
                    _context.SaveChanges();
                }
            }

        //DELETE MEASUREMENT CONFIGURATIONS
           public void DeleteMeasurementConfig(string id)
        {
            var measurement=_context.MeasurementConfigurationData.Where(d=>d.MeasurementId.Equals(id)).FirstOrDefault();
            if (measurement != null)
            {
                _context.MeasurementConfigurationData.Remove(measurement);
                _context.SaveChanges();
            }
        }
      }
    }
