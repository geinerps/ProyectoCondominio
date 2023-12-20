using Firebase.Storage;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoCondominio.Models;
using System.Data.SqlClient;
using System.Data;
using ProyectoCondominio.FirebaseAuth;

namespace ProyectoCondominio.Controllers
{
    public class CondominiosController : Controller
    {
        // GET: CondominiosController
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("userSession")))
                return RedirectToAction("Index", "Error");

            return await getCondominios();
        }

        private async Task<IActionResult> getCondominios()
        {
            List<Condominio> condominiosList = new List<Condominio>();
            Query query = FirestoreDb.Create(FirebaseAuthHelper.firebaseAppId).Collection("Condominios");
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            foreach (var item in querySnapshot)
            {
                Dictionary<string, object> data = item.ToDictionary();

                condominiosList.Add(new Condominio
                {
                    idProyectoHabitacional = Convert.ToInt32(data["idProyectoHabitacional"]),
                    logo = data["logo"].ToString(),
                    codigo = data["codigo"].ToString(),
                    nombre = data["nombre"].ToString(),
                    direccion = data["direccion"].ToString(),
                    telefonoOficina = data["telefonoOficina"].ToString()
                });
            }

            ViewBag.Condominios = condominiosList;

            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int idProyectoHabitacional, string logo, string codigo, string nombre, string direccion, string telefonoOficina)
        {
            try
            {
                DocumentReference addedDocRef =
                    await FirestoreDb.Create(FirebaseAuthHelper.firebaseAppId)
                        .Collection("Condominios").AddAsync(new Dictionary<string, object>
                            {
                                { "idProyectoHabitacional",idProyectoHabitacional },
                                { "logo", logo },
                                { "codigo", codigo },
                                { "nombre",nombre },
                                { "direccion", direccion },
                                { "telefonoOficina", telefonoOficina },
                            });

                return await getCondominios();
            }
            catch (FirebaseStorageException ex)
            {
                ViewBag.Error = new ErrorHandler()
                {
                    Title = ex.Message,
                    ErrorMessage = ex.InnerException?.Message,
                    ActionMessage = "Go to Condominios",
                    Path = "/Condominios"
                };

                return View("ErrorHandler");
            }
        }
    }
}


//*************************************************
//        public ActionResult Editar(int idProyectoHabitacional)
//        {
//            if (String.IsNullOrEmpty(HttpContext.Session.GetString("userSession")))
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                ViewBag.userSession = JsonConvert.DeserializeObject<userSession>(HttpContext.Session.GetString("userSession"));
//                ViewBag.condominio = CargarCondominio(idProyectoHabitacional);
//                ViewBag.viviendas = ViviendasController.CargarViviendas(
//                .
//
//
//
//
//                );
//                return View();
//            }
//        }

//        private Condominio CargarCondominio(int idProyectoHabitacional)
//        {
//            List<SqlParameter> param = new List<SqlParameter>()
//            {
//                new SqlParameter("@idProyectoHabitacional", idProyectoHabitacional)
//            };

//            DataTable ds = FirebaseAuthHelper.ExecuteNonQuery("SP_ObtenerCondominio", param);

//            Condominio condomi = new Condominio()
//            {
//                idProyectoHabitacional = Convert.ToInt32(ds.Rows[0]["idProyectoHabitacional"]),
//                logo = ds.Rows[0]["logo"].ToString(),
//                codigo = ds.Rows[0]["codigo"].ToString(),
//                nombre = ds.Rows[0]["nombre"].ToString(),
//                direccion = ds.Rows[0]["direccion"].ToString(),
//                telefonoOficina = ds.Rows[0]["telefonoOficina"].ToString(),
//            };

//            return condomi;
//        }

//        public ActionResult UpdateCondominio(IFormFile inputPhoto, int idProyectoHabitacional, string nombre, string direccion, string telefonoOficina)
//        {

//            string? photoPath = null;

//            if (inputPhoto != null)
//            {
//                photoPath =
//                    "/images/fotos_condominios/"
//                    + Guid.NewGuid().ToString()
//                    + new FileInfo(inputPhoto.FileName).Extension;

//                using (
//                    var stream = new FileStream(
//                        Directory.GetCurrentDirectory() + "/wwwroot/" + photoPath,
//                        FileMode.Create
//                    )
//                )
//                {
//                    inputPhoto.CopyTo(stream);
//                }
//            }

//            List<SqlParameter> param = new List<SqlParameter>()
//            {
//                new SqlParameter("@idProyectoHabitacional", idProyectoHabitacional),
//                new SqlParameter("@logo", photoPath),
//                new SqlParameter("@nombre", nombre),
//                new SqlParameter("@direccion", direccion),
//                new SqlParameter("@telefonoOficina", telefonoOficina)
//            };

//            Database.DatabaseHelper.ExecuteQuery("SP_UpdateCondominio", param);

//            return RedirectToAction("Index", "Condominios");
//        }

//        public ActionResult EliminarCondominio(int idProyectoHabitacional)
//        {
//            List<SqlParameter> param = new List<SqlParameter>()
//            {
//                new SqlParameter("@idProyectoHabitacional", idProyectoHabitacional)
//            };

//            Database.DatabaseHelper.ExecuteQuery("SP_EliminarCondominio", param);

//            return RedirectToAction("Index", "Condominios");
//        }

//        public ActionResult Agregar()
//        {
//            if (String.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                ViewBag.usuario = JsonConvert.DeserializeObject<userSession>(HttpContext.Session.GetString("userSession"));
//                return View();
//            }
//        }

//        public ActionResult AgregarCondominio(IFormFile inputPhoto, string codigo, string nombre, string direccion, string telefonoOficina, string selectNumViviendas)
//        {
//            string photoPath;

//            if (inputPhoto != null)
//            {
//                photoPath =
//                    "/images/fotos_condominios/"
//                    + Guid.NewGuid().ToString()
//                    + new FileInfo(inputPhoto.FileName).Extension;

//                using (
//                    var stream = new FileStream(
//                        Directory.GetCurrentDirectory() + "/wwwroot/" + photoPath,
//                        FileMode.Create
//                    )
//                )
//                {
//                    inputPhoto.CopyTo(stream);
//                }
//            }
//            else
//            {
//                photoPath = "/images/fotos_condominios/defaultCondominio.png";
//            }

//            List<SqlParameter> param = new List<SqlParameter>()
//            {
//                new SqlParameter("@logo", photoPath),
//                new SqlParameter("@codigo", codigo),
//                new SqlParameter("@nombre", nombre),
//                new SqlParameter("@direccion", direccion),
//                new SqlParameter("@telefonoOficina", telefonoOficina),
//                new SqlParameter("@numeroViviendas", selectNumViviendas),
//            };

//            Database.DatabaseHelper.ExecuteQuery("SP_AgregarCondominio", param);


//            return RedirectToAction("Index", "Condominios");
//        }
//    }
//}