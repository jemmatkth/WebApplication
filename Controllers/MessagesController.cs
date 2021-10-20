using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;
using WebApplication.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using WebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{
	[Authorize]
	public class MessagesController : Controller
	{
		private readonly DbContect _context;
		private readonly UserManager<WebApplicationUser> _userManager;


		public MessagesController(DbContect context, UserManager<WebApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;

		}

		// GET: Messages
		public async Task<IActionResult> Index(int? selectedMessage)
		{
			var userId = _userManager.GetUserId(User);
			var viewModel = new MessageViewModel();			
			viewModel.Messages = await _context.Message.Where(i => i.SentToId == userId).OrderBy(i => i.CreatedByUsername).ToListAsync();
			
			viewModel.numberOfTotalMessages = viewModel.Messages.Count();
			if (viewModel.Messages != null)
			{
				if (selectedMessage != null)
				{
					viewModel.Message = viewModel.Messages.Where(i => i.Id == selectedMessage.Value).Single();
					var message = _context.Message.Where(i => i.Id == viewModel.Message.Id).Single();
					message.Status = true;
					_context.Update(message);
					await _context.SaveChangesAsync();
				}
			}
			else
			{
				viewModel.Messages = null;
			}

			return View(viewModel);
		}

	

		// POST: Messages/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(string SendToUserId, string SendToUserUsername, [Bind("Title,Content")] Message message)
		{
			if (ModelState.IsValid)
			{
				var userId = _userManager.GetUserId(User);
				var username = await _userManager.FindByIdAsync(userId);

				message.CreatedById = userId;
				message.CreatedByUsername = username.UserName;

				message.SentToId = SendToUserId.ToString();
				message.SentToUsername = SendToUserUsername;
				message.Status = false;
				message.Created = DateTime.Now;
				_context.Add(message);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Edit));
			}
			return View(message);
		}

		// GET: Messages/Edit/5
		public async Task<IActionResult> Edit(string? userId)
		{
			var viewModel = new CreateMessageViewModel();
			var users = await _userManager.Users.ToListAsync();
			viewModel.Users = users;

			if (userId != null || !String.IsNullOrEmpty(userId))
			{
				viewModel.SendToUser = await _userManager.FindByIdAsync(userId);
			}

			return View(viewModel);
		}



		// POST: Messages/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			Console.WriteLine("delete post " + id);

			var message = await _context.Message.FindAsync(id);
			if (message != null)
			{
				_context.Message.Remove(message);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			else
			{
				return NotFound();
			}
			
		}

		private bool MessageExists(int id)
		{
			return _context.Message.Any(e => e.Id == id);
		}
	}
}
