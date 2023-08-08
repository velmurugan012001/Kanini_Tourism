using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Kanini_Toursim.Repositary;
using Microsoft.AspNetCore.Mvc;
using static Kanini_Toursim.Model.AdminImageGallery;



public interface IImageGallary

{
        public Task<List<AdminImageGallery>> Postall([FromForm] FileModel aiu);

        public Task<List<AdminImageGallery>> Getall();
        public Task<AdminImageGallery> Getadminid(int id);

        Task<AdminImageGallery> Update(int id, FileModel aiu);
        Task<bool> Delete(int id);
    }

