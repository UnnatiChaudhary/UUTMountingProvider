using IO.Swagger.Models;
using Microsoft.AspNetCore.Mvc;
using SpikeDemo.EFCore;
using SpikeDemo.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UUTMounting.Controllers
{
    [ApiController]
    public class UutController : ControllerBase
    {
        private readonly DbHelper _db;
       
        public UutController(UutMountingContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetUut")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<UutMountingInformation> data = _db.GetUutData();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetMeasurementConfig")]
        public IActionResult GetMeasurementData()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<MeasurementConfiguration> data = _db.GetMeasurementData();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetUutById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                UutMountingInformation data = _db.GetUutById(id);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        [Route("api/[controller]/SaveUut")]
        public IActionResult Post([FromBody] UutMountingInformation model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveUut(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        [Route("api/[controller]/SaveMeasurement")]
        public IActionResult PostMeasurement([FromBody] MeasurementConfiguration model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.saveMeasurementData(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut]
        [Route("api/[controller]/UpdateUut")]
        public IActionResult Put([FromBody] UutMountingInformation model)
        {

            try
            {
                ResponseType type = ResponseType.Success;
                _db.UpdateUut(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteUut/{id}")]
        public IActionResult DeleteUut(string id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteUut(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteMeasurementConfig/{id}")]
        public IActionResult DeleteMeasurement(string id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteMeasurementConfig(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
