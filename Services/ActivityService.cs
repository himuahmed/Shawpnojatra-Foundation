using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Shawpnojatra_Foundation.Models;
using Shawpnojatra_Foundation.View_Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shawpnojatra_Foundation.Services
{
	public class ActivityService :IActivityService
	{
		public ApplicationContext _db { get; set; }
		private IWebHostEnvironment Environment;


		public ActivityService(ApplicationContext db, IWebHostEnvironment _environment)
		{
			_db = db;
			Environment = _environment;
		}

		public IEnumerable<Post> GetPost()
		{
			return _db.Posts.ToList();
		}

		public Post GetPostsByID(int ID)
		{
			return _db.Posts.Find(ID);
		}

		public int AddPost(VMPost post)
		{
			int result = -1;
			if (post != null)
			{
				Post vPost = new Post
				{
					Image = post.Image,
					TypeID = post.TypeID,
					PostDetail = post.PostDetail,
					Title=post.Title,
					CD = DateTime.Now,
					UD = DateTime.Now,
				};
				_db.Posts.Add(vPost);
				if (_db.SaveChanges() > 0)
				{
					result = vPost.ID;
				}
				string fileName = UploadImage(post.ImageFile, result);
				post.Image = fileName;
				post.ID = result;
				UpdatePost(post);
			}

			return result;
		}

		public int UpdatePost(VMPost post)
		{
			int result = -1;
			//_db.Entry(post).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			var updatePost = _db.Posts.Where(x => x.Active == true && x.ID == post.ID).FirstOrDefault();
			if (updatePost != null) {
				updatePost.PostDetail = post.PostDetail;
				updatePost.Image = post.Image;
				updatePost.UD = DateTime.Now;
				updatePost.Title = post.Title;

			}
			if (_db.SaveChanges() > 0)
			{
				result = post.ID;
			}
			return result;
		}

		public int DeletePost(int ID)
		{
			int result = -1;
			var post = _db.Posts.Find(ID);
			post.Active = false;
			if (_db.SaveChanges() > 0)
			{
				result = post.ID;
			}

			return result;
		}

		public string UploadImage(IFormFile file,int ID)
		{
			string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "uploads");

         
            var dir = new DirectoryInfo(path);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

			string fileName = "";
			if (file.Length > 0)
			{
				//var filePath = Path.GetTempFileName();

				//using (var stream = System.IO.File.Create(filePath))
				//{
				//	await file.CopyToAsync(stream);
				//}
				 fileName = Path.GetFileName(file.FileName);
				string strpath = System.IO.Path.GetExtension(file.FileName);
				string File_Path_Text = Path.GetTempFileName();
				fileName = "Post" + "-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ID+"."+strpath;

				using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
				{
					file.CopyTo(stream);
					//uploadedFiles.Add(fileName);
					//ViewBag.Message += fileName + ",";
				}

			}

			return fileName;
		}
	}
}
