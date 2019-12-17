using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProvaC.Data;
using ProvaC.Models;

namespace ProvaC.Controllers
{
    public class PlacarsController : Controller
    {
        private readonly ContextDb _context;

        public PlacarsController(ContextDb context)
        {
            _context = context;
        }

        // GET: Placars
        public async Task<IActionResult> Index()
        {
            var context = _context.Placares.Include(p => p.Jogador).OrderByDescending(p => p.Pontos).Take(10);
            return View(await _context.Placares.ToListAsync());
        }

        // GET: Placars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placar = await _context.Placares
                .FirstOrDefaultAsync(m => m.PlacarId == id);
            if (placar == null)
            {
                return NotFound();
            }

            return View(placar);
        }

        // GET: Placars/Create
        public IActionResult Create()
        {
            ViewData["IdJogador"] = new SelectList(_context.Jogadores, "JogadorId", "Nome");
            return View();
        }

        // POST: Placars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlacarId,IdJogador,Pontos,Data")] Placar placar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            ViewData["IdJogador"] = new SelectList(_context.Jogadores, "JogadorId", "Nome", placar.IdJogador);
            return View(placar);
        }



        // GET: Placars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placar = await _context.Placares.FindAsync(id);
            if (placar == null)
            {
                return NotFound();
            }

            ViewData["IdJogador"] = new SelectList(_context.Jogadores, "JogadorId", "Nome", placar.IdJogador);
            return View(placar);
        }

        // POST: Placars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlacarId,IdJogador,Pontos,Data")] Placar placar)
        {
            if (id != placar.PlacarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacarExists(placar.PlacarId))
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
            ViewData["IdJogador"] = new SelectList(_context.Jogadores, "JogadorId", "Nome", placar.IdJogador);
            return View(placar);
        }

        // GET: Placars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placar = await _context.Placares
                .FirstOrDefaultAsync(m => m.PlacarId == id);
            if (placar == null)
            {
                return NotFound();
            }

            return View(placar);
        }

        // POST: Placars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placar = await _context.Placares.FindAsync(id);
            _context.Placares.Remove(placar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacarExists(int id)
        {
            return _context.Placares.Any(e => e.PlacarId == id);
        }
    }
}
