using Homework_SkillTree.Data;
using Homework_SkillTree.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Homework_SkillTree.Service;
using X.PagedList.Extensions;
using X.PagedList.EF;


namespace Homework_SkillTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            Configuration = configuration;
        }

        public PaginatedList<AccountBook> AccountBooks { get; set; }
        public async Task<IActionResult> Index(int? page)
        {
            // ����w�]��ܲ{�b
            var newItem = new AccountBook
            {
                CreateDate = DateTime.Now
            };

            // ���o�Ҧ��O�b��ƨë�����Ƨ�
            var pageSize = Configuration.GetValue("PageSize", 4);
            var pageNumber = page ?? 1;
            ViewBag.nowPage = pageNumber;
            ViewBag.pageSize = pageSize;
            var onePageOfItems = await _context.AccountBook
                .OrderByDescending(i => i.CreateDate).ToPagedListAsync(pageNumber, pageSize);
            ViewBag.OnePageOfItems = onePageOfItems;

            // �إߵ��ϼҫ�
            var viewModel = new AccountingViewModel
            {
                NewItem = newItem
            };

            return View(viewModel);
        }

        // POST: /Accounting/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountingViewModel model)
        {
            if (model != null)
            {
                await _context.AddAsync(model.NewItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
                return View(nameof(Index), model);
        }

    }
}
