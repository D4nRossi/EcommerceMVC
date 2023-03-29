using EcommerceMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EcommerceMVC.Areas.Admin.Controllers {
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagensController : Controller {

        //Obter o nome da pasta onde salvar os arquivos
        private readonly ConfigurationImagens _myConfig;
        //Info do ambiente onde a aplicação esta rodando
        private readonly IWebHostEnvironment _hostingEnvironment;

        //CTT injetando as duas instancias
        public AdminImagensController(IWebHostEnvironment hostEnvironment, IOptions<ConfigurationImagens> myConfiguration) {
            _hostingEnvironment = hostEnvironment;
            _myConfig = myConfiguration.Value;
        }

        //Upload de arquivos
        public async Task<IActionResult> UploadFiles(List<IFormFile> files) { 
            //Verificar se tem algum arquivo a ser enviado
            if(files == null || files.Count == 0) {
                ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
            }
            //Verificar limite de arquivos
            if(files.Count > 10) {
                ViewData["Erro"] = "Error: Quantidade de arquivos excedeu o limite";
            }

            //Calcular bytes dos arquivos
            long size = files.Sum(f => f.Length);
            //Armazenar os nomes dos arquivos
            var filePathsName = new List<string>();
            //Armazenar onde os arquivos ficarão alocados
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            foreach(var formFile in files) {
                //Verificar se é imagem
                if(formFile.FileName.Contains(".jpg") || formFile.Name.Contains(".gif") || formFile.FileName.Contains(".jpeg") || formFile.FileName.Contains(".png")) {
                    //Concatenando o path do arquivo + o nome
                    var fileNameWithPath = string.Concat(filePath,"\\", formFile.FileName);
                    filePathsName.Add(fileNameWithPath);
                    //Se não existir ele cria, ou subscreve
                    using(var stream = new FileStream(fileNameWithPath, FileMode.Create)) {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            ViewData["Resultado"] = $"{files.Count} arquivos foram enviados ao servidor, " + $"com tamanho total de : {size} bytes";
            ViewBag.Arquivos = filePathsName;
            return View(ViewData);
        }

        public IActionResult Index() {
            return View();
        }
    }
}
