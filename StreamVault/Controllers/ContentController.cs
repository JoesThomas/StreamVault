using Microsoft.AspNetCore.Mvc;
using StreamVaultAdmin.Mapping;
using StreamVaultAdmin.Models;
using StreamVaultAdmin.Services;
using StreamVaultAdmin.ViewModels;

namespace StreamVaultAdmin.Controllers;

public class ContentController : Controller
{
    private readonly IContentService _service;

    public ContentController(IContentService service)
    {
        _service = service;
    }

    // GET: /Content
    public async Task<IActionResult> Index(ContentListViewModel vm)
    {
        var content = await _service.GetAllAsync(vm.SearchTerm, vm.SelectedType);

        var updatedVm = new ContentListViewModel
        {
            Contents = content,
            SearchTerm = vm.SearchTerm,
            SelectedType = vm.SelectedType
        };

        return View(updatedVm);
    }

    // GET: /Content/Create
    public IActionResult Create()
    {
        return View(new ContentViewModel
        {
            ReleaseDate = DateOnly.FromDateTime(DateTime.Today)
        });
    }

    // POST: /Content/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ContentViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        await _service.AddAsync(ContentMapper.ToEntity(vm));

        return RedirectToAction(nameof(Index));
    }

    // GET: /Content/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var content = await _service.GetByIdAsync(id);

        if (content == null)
            return NotFound();

        return View(ContentMapper.ToViewModel(content));
    }

    // POST: /Content/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ContentViewModel vm)
    {
        if (id != vm.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(vm);

        if (!await _service.ExistsAsync(id))
            return NotFound();

        await _service.UpdateAsync(ContentMapper.ToEntity(vm));

        return RedirectToAction(nameof(Index));
    }

    // GET: /Content/Delete
    public async Task<IActionResult> Delete(int id)
    {
        var content = await _service.GetByIdAsync(id);

        if (content == null)
            return NotFound();

        return View(content);
    }

    // POST: /Content/Delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}