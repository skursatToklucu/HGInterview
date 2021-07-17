using HizliGeliyoEcom.Core.Entity.Concrete;
using HizliGeliyoEcom.DataAccess.Context;
using HizliGeliyoEcom.DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HizliGeliyoEcom.DataAccess.Repositories.Concrete
{
    public class CoreRepository<T> : ICoreRepository<T> where T : CoreEntity
    {

        private readonly ProjectContext _context;
        private IHttpContextAccessor _httpContext;

        public CoreRepository(ProjectContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }


        /// <summary>
        /// Gelen ID'ye ait Entity'nin  Status durumunu Active olarak değiştirir ve Update eder.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Activate(Guid id)
        {
            T activated = GetByID(id);
            activated.Status = Core.Enum.Status.Active;
            return Update(activated);
        }

        /// <summary>
        /// Gelen ID'ye ait Entity'nin  Status durumunu Deactive olarak değiştirir ve Update eder.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeActivate(Guid id)
        {
            T deactivated = GetByID(id);
            deactivated.Status = Core.Enum.Status.Deactive;
            return Update(deactivated);
        }

        /// <summary>
        /// Gelen Entity'i Database'e ekler.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Add(T item)
        {
            _context.Set<T>().Add(item);
            return Save() > 0;

        }

        /// <summary>
        /// Sorguya göre Entityi döndürür.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public T GetByDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).FirstOrDefault();

        /// <summary>
        /// Gelen ID'ye göre o ID'ye ait Entity'i döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetByID(Guid id) => _context.Set<T>().Find(id);

        /// <summary>
        /// Veritabanına kaydeder.
        /// </summary>
        /// <returns></returns>
        public int Save() => _context.SaveChanges();

        /// <summary>
        /// Gelen Entityi Günceller.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(T item)
        {
            try
            {
                _context.Set<T>().Update(item);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public List<T> GetActive() => _context.Set<T>().Where(x => x.Status == Core.Enum.Status.Active).ToList();

        public List<T> GetDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).ToList();




        /// <summary>
        /// Random güçlü şifre oluşturur
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string GenerateToken(int length)
        {
            using (RNGCryptoServiceProvider cryptRNG = new RNGCryptoServiceProvider())
            {
                byte[] tokenBuffer = new byte[length];
                cryptRNG.GetBytes(tokenBuffer);
                return Convert.ToBase64String(tokenBuffer);
            }
        }

        public string BaseUrl()
        {
            var request = _httpContext.HttpContext.Request;
            var url = string.Format($"{request.Scheme}://{request.Host}/Home/Login");
            return url;
        }


        /// <summary>
        /// Mail için using bloğu 
        /// </summary>
        /// <param name="postedBy">Kim Tarafından</param>
        /// <param name="password">Şifre</param>
        /// <param name="entity">Gönderilecek Entıty</param>
        /// <param name="subject">Konu</param>
        /// <param name="content">İçerik</param>
        public void CreateMail(string postedBy, string password, T entity, string subject, string content)
        {
            using (MailMessage mm = new MailMessage(postedBy, entity.Email))
            {

                mm.Subject = subject;
                string body = content;

                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                NetworkCredential NetworkCred = new NetworkCredential(postedBy, password);
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                mm.Dispose();

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void SendMail(T entity)
        {
            CreateMail("hginterviewproject@gmail.com", "Q3S0jftPauw=", entity,
                "Hoş Geldiniz",
                $"Merhaba { entity.FullName} " +
                $"<br/>Mail Adresiniz: {entity.Email} <br/>Parolanız: {entity.Password}<br />" +
                $"<a href = '{BaseUrl()}'>Giriş yapmak için tıklayınız.</a><br /><br />" +
                $"<br />Teşekkürler");
        }

        /// <summary>
        /// Kimlik doğrulamak için ClaimsPrincipal döndüren method.
        /// <br/>Kullanım Şekli : await HttpContext.SignInAsync(LoginClaims(entity))
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ClaimsPrincipal LoginClaims(T entity)
        {
            var claims = new List<Claim>//Kimlik doğrulama
                {
                    new Claim(ClaimTypes.Name, entity.Email)
                };
            var userIdentity = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            return principal;
        }

        /// <summary>
        /// Mail dogrulugunu kontrol eder
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool CheckEmail(T entity, string email)
        {
            if (entity.Email == email)
                return true;
            else
                return false;
        }



        /// <summary>
        /// Şifre dogrulugunu kontrol eder.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckPassword(T entity, string password)
        {
            if (entity.Password == password)
                return true;
            else
                return false;
        }

        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);
    }
}
