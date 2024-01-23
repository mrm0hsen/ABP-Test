using Acme.BookStore.DTOs;
using Acme.BookStore.Entities;
using Acme.BookStore.Interfaces;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Services
{

    public class CaptchaService : ICaptcha
    {
        private readonly IRepository<CaptchaForUser> _repository;
        public CaptchaService(IRepository<CaptchaForUser> repository)
        {
            _repository = repository;
        }

        private SideDTO CreateCaptcha()
        {
            SideDTO model = new SideDTO();
            string num1 = RandomCaptcha();
            string num2 = RandomCaptcha();
            string cap = num1 + " + " + num2 + " = ";
            Image image = DrawText(cap, new Font(FontFamily.GenericSansSerif, 15), Color.DarkBlue, Color.Cornsilk);
            model.Captcha = ImageToByteArray(image);
            model.SideNumber1 = int.Parse(num1);
            model.SideNumber2 = int.Parse(num2);
            return model;
        }
        private Image DrawText(string text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object  
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be  
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object  
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size  
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);

            //paint the background  
            drawing.Clear(backColor);

            //create a brush for the text  
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, 0, 0);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;
        }
        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        private string RandomCaptcha()
        {
            Random random = new Random();
            int captcha = random.Next(10, 99);
            return captcha.ToString();
        }


        public async Task<CaptchaToViewDTO> SendCaptcha()
        {
            CaptchaToViewDTO model = new CaptchaToViewDTO();
            model.Captcha = CreateCaptcha();
            CaptchaForUser newCap = new CaptchaForUser();
            newCap.Answer = (model.Captcha.SideNumber1 + model.Captcha.SideNumber2).ToString();
            await _repository.InsertAsync(newCap, true);
            model.CaptchaId = newCap.Id;
            return model;
        }

        public async Task<CaptchaResult> CaptchaCheck(string id, string answer)
        {

            try
            {
                //var clientHttp = new HttpClient();
                //clientHttp.Timeout = TimeSpan.FromMinutes(30);
                CaptchaResult result = new CaptchaResult();
                var captchaId = new Guid(id);
                var cap = await _repository.GetAsync(x => x.Id == captchaId);
                if (cap == null || DateTime.Now > cap.ExpireDate || cap.IsUsed || cap.Answer != answer)
                {
                    var clientHttp = new HttpClient();
                    clientHttp.Timeout = TimeSpan.FromMinutes(30);
                    result.result = false;
                    result.Captcha = CreateCaptcha();
                    CaptchaForUser newCap = new CaptchaForUser();
                    newCap.Answer = (result.Captcha.SideNumber1 + result.Captcha.SideNumber2).ToString();
                    await _repository.InsertAsync(newCap, true);
                    result.CaptchaId = newCap.Id;

                    //cap.IsUsed = true;
                    //await _repository.UpdateAsync(cap);

                    //U can swap this line with upper lines:
                    await _repository.DeleteAsync(x => x.Id == captchaId);

                    return result;
                }
                result.result = true;

                //Again u can swap this !
                await _repository.DeleteAsync(x => x.Id == captchaId);

                return result;
            }
            catch (TaskCanceledException ex)
            {

                throw;
            }

        }

    }
}
