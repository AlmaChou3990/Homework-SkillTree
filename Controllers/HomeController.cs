using Homework_SkillTree.Data;
using Homework_SkillTree.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_SkillTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> index()
        {
            // �إ߷s���ťհO�b���إΩ���
            var newItem = new AccountingRecord
            {
                CreateDate = DateTime.Now
            };

            // ���o�Ҧ��O�b��ƨë�����Ƨ�
            var items = await _context.AccountingRecord
                .OrderByDescending(i => i.CreateDate)
                .ToListAsync();

            // �إߵ��ϼҫ�
            var viewModel = new AccountingViewModel
            {
                NewItem = newItem,
                Items = items
            };

            return View(viewModel);
        }

        // POST: /Accounting/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountingViewModel model)
        {
            if (model.NewItem!=null)
            {
                _context.Add(model.NewItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // �p�G�ҫ����ҥ��ѡA���s���J���زM��
            model.Items = await _context.AccountingRecord
                .OrderByDescending(i => i.CreateDate)
                .ToListAsync();

            return View("Index", model);
        }

    }
}
