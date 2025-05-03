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
            // 日期預設顯示現在
            var newItem = new AccountBook
            {
                CreateDate = DateTime.Now
            };

            // 取得所有記帳資料並按日期排序
            // 取得最新10顯示，之後再做分頁
            var items = await _context.AccountBook
                .OrderByDescending(i => i.CreateDate)
                .Take(10)
                .ToListAsync();

            // 建立視圖模型
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
            else
                return View(nameof(Index), model);
        }

    }
}
