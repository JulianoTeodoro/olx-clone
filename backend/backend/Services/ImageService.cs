namespace backend.Services
{
    public class ImageService
    {

        public byte[] AdicionarImage(IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    return fileBytes;
                }
            }
            else
            {
                throw new Exception("Erro");
            }

        }

        public byte[] GetImage(string base64String)
        {
            byte[] image = null;
            if(!string.IsNullOrEmpty(base64String))
            {
                image = Convert.FromBase64String(base64String);
            }
            return image;
        }
    }
}
