using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCBoard.Models;
using Microsoft.AspNet.Identity;
using PagedList;

namespace MVCBoard
{
    public class BoardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Boards
        public ActionResult Index()
        {
            var vm = new BoardKeyModel();     
            var newListCategoryVm = new List<BoardKeyModel>() { vm };
            return View(newListCategoryVm);
        }

        // GET: Boards by key
        public ActionResult ViewIndex(string boardKey, int? page)

        {
            int pageSize = 6;
            int pageNumber = page ?? 1;

            var BKM = new BoardKeyModel()
            {
                Boards = db.Boards.Where(c => c.BoardKey == boardKey).ToList().ToPagedList(pageNumber, pageSize),
                Board = new Board()
            };

            ViewBag.BoardKey = boardKey;



            return View("Index", BKM.Boards);
        }

        // GET: Boards/Details/5
        public ActionResult Details(int? id)
        {
          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = db.Boards.Find(id);
         
            if (board == null)
            {
                return HttpNotFound();
            }

            var detailViewModel = new BoardViewModel()
            {
                Board = board,
                Replies = db.Replies.Where(s => s.BoardId == board.ID).ToList(),
                Reply = new Reply()
                {
                     BoardId = board.ID,
                     BoardKey = board.BoardKey
                }
            };
            return View(detailViewModel);
        }

        // GET: Boards/Create
        public ActionResult Create(string id)
        {
            var b = new Board()
            {
                BoardKey = id

            };
            return View(b);
        }

        // POST: Boards/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post),ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Title,Content,CreatedTime,BoardKey")] Board board)
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);


            if (ModelState.IsValid)
            {
                board.Creater = currentUser;
                db.Boards.Add(board);
                db.SaveChanges();

              
                return RedirectToAction("ViewIndex","Boards", new { boardKey = board.BoardKey });
            }

         

            return View(new BoardViewModel() {
                 Board = board
            });
        }

        // POST: Boards/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post), ValidateInput(false)]
        public ActionResult Details([Bind(Include = "Board,Replies,Reply")] BoardViewModel board)
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            if (ModelState.IsValid)
            {
                board.Reply.Replier = currentUser;
                db.Replies.Add(board.Reply);
                
                db.SaveChanges();
                return RedirectToAction("ViewIndex", "Boards", new { boardKey  = board.Reply.BoardKey });
            }

            return View(board);
        }

        // GET: Boards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        // POST: Boards/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post), ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,Title,Content,CreatedTime,BoardKey")] Board board)
        {
            if (ModelState.IsValid)
            {
                db.Entry(board).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewIndex", "Boards", new { boardKey = board.BoardKey });
            }
            return View(board);
        }

        // GET: Boards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        // POST: Boards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Board board = db.Boards.Find(id);
            db.Boards.Remove(board);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
