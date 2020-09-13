using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Whoisvisiting.Domain.Entities;
using Whoisvisiting.Infrastructure.Interfaces.CoreServices;
using Whoisvisiting.UI.Web.ServiceProviders;

namespace Whoisvisiting.UI.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ClearbitServiceProvider _clearbitServiceProvider;

        public ContactController(IContactService contactService,
            ClearbitServiceProvider clearbitServiceProvider)
        {
            _contactService = contactService;
            _clearbitServiceProvider = clearbitServiceProvider;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            return View(await _contactService.GetAll().ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _contactService.FindAsync(id.Value);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,PhoneNumber,Domain,Notes")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactService.AddAsync(contact);
                await _clearbitServiceProvider.EnrichmentContact(contact);
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _contactService.FindAsync(id.Value);
            if (contact == null)
            {
                return NotFound();
            }
            return PartialView("_Edit", contact);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Email,PhoneNumber,Domain,Notes")] Contact contact)
        {
            if (id == null || id.Value != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _contactService.UpdateAsync(contact);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _contactService.DeleteAsync(id.Value);

            if (contact == null)
            {
                return NotFound();
            }

            return PartialView("_Delete", contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _contactService.DeleteAsync(id.Value);
            return RedirectToAction(nameof(Index));
        }

        // GET: Contacts for datatable
        public async Task<IActionResult> Contacts()
        {
            return Json(new { Data = await _contactService.GetAll().ToListAsync() });
        }

        private bool ContactExists(int id)
        {
            return _contactService.GetAll().Any(e => e.Id == id);
        }
    }
}
