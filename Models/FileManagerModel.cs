namespace EcommerceMVC.Models {
    public class FileManagerModel {
        public FileInfo[] Files { get; set; }//Tratar os arquivos
        public IFormFile IFormFile { get; set; }//Enviar os arquivos
        public List<IFormFile> iFormFiles { get; set; }
        public string PathImagesProduto { get; set; }
    }
}
