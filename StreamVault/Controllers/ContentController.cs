using Microsoft.AspNetCore.Mvc;
using StreamVaultAdmin.Mapping;
using StreamVaultAdmin.Models;
using StreamVaultAdmin.Services;
using StreamVaultAdmin.ViewModels;
using System.Web.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace StreamVaultAdmin.Controllers;

public class ContentController : Controller
{
    private readonly IContentService _service;

    public ContentController(IContentService service)
    {
        _service = service;
    }
}