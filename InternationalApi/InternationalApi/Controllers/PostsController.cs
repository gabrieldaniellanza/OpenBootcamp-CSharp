﻿using InternationalApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace InternationalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly IStringLocalizer<PostsController> _stringLocalizer;

        private readonly IStringLocalizer<SharedResource> _shareResourceLocalizer;

        public PostsController(IStringLocalizer<PostsController> stringLocalizer, IStringLocalizer<SharedResource> shareResourceLocalizer)
        {

            _stringLocalizer = stringLocalizer;
            _shareResourceLocalizer = shareResourceLocalizer;

        }

        [HttpGet]
        [Route("PostsControllerResource")]
        public IActionResult GetUsingPostControllerResource() 
        {
            var article = _stringLocalizer["Article"];

            var postName = _stringLocalizer.GetString("Welcome").Value ?? String.Empty;

            return Ok(new
                {
                    PostType = article.Value,
                    PostName = postName
                });
        }


        [HttpGet]
        [Route("SharedResource")]
        public IActionResult GetUsingSharedResource()
        {
            var article = _stringLocalizer["Article"];

            var postName = _stringLocalizer.GetString("Welcome").Value ?? String.Empty;

            var todayIs = string.Format(_shareResourceLocalizer.GetString("TodayIs"), DateTime.Now.ToLongDateString());

            return Ok(new
            {
                PostType = article.Value,
                PostName = postName,
                TodayIs = todayIs
            });
        }

    }
}
