using Acme.BookStore.DTOs;
using Acme.BookStore.Entities;
using Acme.BookStore.Interfaces;
using System;
using System.Drawing;
using System.IO;
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

        private SideDTO GiveSide()
        {
            SideDTO model = new SideDTO();
            string number = RandomCaptcha();
            Image image = DrawText(number, new Font(FontFamily.GenericSansSerif, 15), Color.DarkBlue, Color.Cornsilk);
            model.Side = ImageToByteArray(image);
            model.SideNumber = int.Parse(number);
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
            model.Side1 = GiveSide();
            model.Side2 = GiveSide();
            CaptchaForUser newCap = new CaptchaForUser();
            newCap.Answer = (model.Side1.SideNumber + model.Side2.SideNumber).ToString();
            await _repository.InsertAsync(newCap, true);
            model.CaptchaId = newCap.Id;
            return model;
        }

        public async Task<CaptchaResult> CaptchaCheck(Guid id, string answer)
        {
            CaptchaResult result = new CaptchaResult();
            var cap = await _repository.GetAsync(x => x.Id == id);
            if (cap == null || DateTime.Now > cap.ExpireDate || cap.IsUsed || cap.Answer != answer)
            {
                result.result = false;
                result.Side1 = GiveSide();
                result.Side2 = GiveSide();
                CaptchaForUser newCap = new CaptchaForUser();
                newCap.Answer = (result.Side1.SideNumber + result.Side2.SideNumber).ToString();
                await _repository.InsertAsync(newCap, true);
                result.CaptchaId = newCap.Id;
                
                //cap.IsUsed = true;
                //await _repository.UpdateAsync(cap);

                //U can swap this line with upper lines:
                await _repository.DeleteAsync(x => x.Id == id);

                return result;
            }
            result.result = true;

            //Again u can swap this !
            await _repository.DeleteAsync(x => x.Id == id);

            return result;
        }

    }
}
