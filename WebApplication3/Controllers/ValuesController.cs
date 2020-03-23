using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Formatters.Json;


namespace Darwin.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            Classes.Log.Infolog("Test");
            return new JsonResult(Models.Connexion.UserConnexion.GetAll());
        }

        // GET api/values/5
        [HttpGet("{mail}")]
        public ActionResult<string> Get(string Mail)
        {
            return new JsonResult(Models.Connexion.UserConnexion.GetOne(Mail));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Params param)
        {
            Classes.Log.Infolog("User " + param.pseudo + " Created");
            Models.Connexion.UserConnexion.Insert(param.pseudo, param.mail, param.motpasse);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Params param)
        {
            Classes.Log.Infolog("Updated User " + id);
            Models.Connexion.UserConnexion.Update(id, param.pseudo, param.mail, param.motpasse);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Classes.Log.Warnlog("Deleted User " + id);
            Models.Connexion.UserConnexion.Delete(id);
        }
    }

    public class Params
    {
        public string pseudo { get; set; }
        public string mail { get; set; }
        public string motpasse { get; set; }
    }
}
