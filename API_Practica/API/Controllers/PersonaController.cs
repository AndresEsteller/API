using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Models;
using static Services.PersonaService;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        [Route("lista")]
        public List<Persona> Lista()
        {
            return ListaPersona();
        }

        [HttpGet]
        [Route("buscar")]
        public List<Persona> Buscar(string cedula)
        {
            return BuscarPersona(cedula);
        }

        [HttpPost]
        [Route("agregar")]
        public string Agregar(Persona modelo)
        {
            return AgregarPersona(modelo);
        }

        [HttpPut]
        [Route("actualizar")]
        public string Actualizar(Persona modelo, string cedula)
        {
            return ActualizarPersona(modelo, cedula);
        }

        [HttpDelete]
        [Route("eliminar")]
        public string Eliminar(string cedula)
        {
            return EliminarPersona(cedula);
        }
    }
}
