using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialApp2.Data;
using SocialApp2.Models;

namespace SocialApp2
{
    public class InvitationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _user;

        public InvitationsController(ApplicationDbContext context, UserManager<IdentityUser> user)
        {
            _context = context;
            _user = user;
        }

        // GET: Invitations
        public async Task<IActionResult> Index()
        {
            string userID = _user.GetUserId(HttpContext.User);
            // retrieve received nivitations
            var invitations = _context.Invitation.Where(i => i.ReceiverId == userID);

            return View(await invitations.ToListAsync());
        }

        public async Task<IActionResult> Search()
        {
            var invitations = _context.Invitation.Include(i => i.Receiver);
            string userID = _user.GetUserId(HttpContext.User);

            var users = _context.Users.Where(m => m.Id != userID);

            return View(await users.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept(int id)
        {
            string loggedUserID = _user.GetUserId(HttpContext.User);
            var invitation = _context.Invitation.Single(m => m.Id == id);
            string senderID =  _context.Users.Single(u => u.Id == invitation.SenderId).Id;

            Friend friend = new Friend
            {
                UserReceiverId = loggedUserID,
                UserSenderId = senderID
            };

            _context.Friends.Add(friend);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendInvitation(string id)
        {
            string senderID = _user.GetUserId(HttpContext.User);
            var sender = _context.Users.Single(m => m.Id == senderID);
            string senderEmail = sender.Email;
            var receiver = _context.Users.Single(m => m.Id == id);

            Invitation invitation = new Invitation
            {
                ReceiverId = id,
                SenderId = senderID,
                SenderEmail = senderEmail,
                ReleaseDate = DateTime.Now
            }; 
            
            _context.Invitation.Add(invitation);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Invitations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invitation = await _context.Invitation
                .Include(i => i.Receiver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invitation == null)
            {
                return NotFound();
            }

            return View(invitation);
        }

        // GET: Invitations/Create
        public IActionResult Create()
        {
            ViewData["SenderId"] = new SelectList(_context.Set<User>(), "Id", "Id");
            return View();
        }

        // POST: Invitations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SenderId")] Invitation invitation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invitation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SenderId"] = new SelectList(_context.Set<User>(), "Id", "Id", invitation.SenderId);
            return View(invitation);
        }

        // GET: Invitations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invitation = await _context.Invitation.FindAsync(id);
            if (invitation == null)
            {
                return NotFound();
            }
            ViewData["SenderId"] = new SelectList(_context.Set<User>(), "Id", "Id", invitation.SenderId);
            return View(invitation);
        }

        // POST: Invitations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SenderId")] Invitation invitation)
        {
            if (id != invitation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invitation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvitationExists(invitation.Id))
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
            ViewData["SenderId"] = new SelectList(_context.Set<User>(), "Id", "Id", invitation.SenderId);
            return View(invitation);
        }

        // GET: Invitations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invitation = await _context.Invitation
                .Include(i => i.Receiver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invitation == null)
            {
                return NotFound();
            }

            return View(invitation);
        }

        // POST: Invitations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invitation = await _context.Invitation.FindAsync(id);
            _context.Invitation.Remove(invitation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvitationExists(int id)
        {
            return _context.Invitation.Any(e => e.Id == id);
        }
    }
}
