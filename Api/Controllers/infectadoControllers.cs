namespace api.Controllers
{
    public class infectadoControllers
    {
        [ApiController]
        [Route("[controller]")]
        public class infectadoController : ControllerBase
        {
            Data.MongoDB _mongoDB;
            IMongoCollection<infectado> _infectadosCollection;

            public infectadoController(Data.MongoDB mongoDB)
            {
                _mongoDB = mongoDB;
                _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
            }

            [HttpPost]
            public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
            {
                var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

                _infectadosCollection.InsertOne(infectado);

                return StatusCode(201, "Infectado adicionado com sucesso");
            }

            [HttpGet]
            public ActionResult ObterInfectados()
            {
                var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();

                return Ok(infectados);
            }

            [HttpPut]
            public ActionResult AtualizarInfectado()
            {
                _infectadosCollection.UpdateOne()

                var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();

                return OK(infectados);
            }
        }
    }
}