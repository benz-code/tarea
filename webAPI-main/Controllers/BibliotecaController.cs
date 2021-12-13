using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using webAPI.Data;
using webAPI.Models;


namespace webAPI.Controllers
{
 

 ///<summary>
    /// Wen api de gestion de Biblioteca
    ///</summary>
    [ApiController]
    [Route("[Controller]")]
   
    public class BibliotecaController:Controller
    {
        private DatabaseContext _context;

        public BibliotecaController(DatabaseContext context)
        {
            _context=context;
        }
        
         
          ///<summary>
    /// List of Registered books  
    ///</summary>
     ///<remarks>
    /// It contains the list of all the books that our library of books has. 
    ///</remarks>
     ///<response code="200">ok. Returns the objects requested(book) by the user </response> 
    ///<response code="404">Not. found. The object requested by the user was not found </response> 
        [HttpGet]
               public async Task<ActionResult<List<Biblioteca>>> GetBiblioteca()
        {
            var bibliotecas = await _context.Bibliotecas.ToListAsync();
            return bibliotecas;
        }

         
          ///<summary>
    /// List of books registered by id 
    ///</summary>
     ///<param name="id">Id (isdBiblioteca)of the object </param>
     ///<remarks>
    /// The data is entered to enter a new book to our library  
    ///</remarks>
     ///<response code="200">ok. Returns the objects(new book) requested by the user </response> 
    ///<response code="404">Not. found. The object requested by the user was not found </response> 
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Biblioteca>> GetBibliotecaByID(int id)
        {
            var bibliotecas = await _context.Bibliotecas.FindAsync();
            if(bibliotecas==null)
            {
                return NotFound();
            }
            return bibliotecas;
        }

     ///<summary>
    /// new book registration for the library 
    ///</summary>
      ///<param name="biblioteca"> </param>
     ///<remarks>
    /// It is a record of books by id as its name indicates, you should enter the id of the book to show the information of the book 
    ///</remarks>
     ///<response code="200">ok. Returns the objects requested by the user </response> 
    ///<response code="404">Not. found. The object requested by the user was not found </response> 
        [HttpPost]
        public async Task<ActionResult<Biblioteca>> PostBiblioteca(Biblioteca biblioteca)
        {
            _context.Bibliotecas.Add(biblioteca);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBibliotecaByID", new{id=biblioteca.BibliotecaID}, biblioteca);
        }



  ///<summary>
    /// Book information update according to your id 
    ///</summary>
     ///<param name="id">Id (isdBiblioteca)of the object </param>
      ///<param name="biblioteca"> </param>
     ///<remarks>
    /// As the book with its information has already been created in the other obsessions, this tab is used for its edition if we have made a mistake in something 
    ///</remarks>
     ///<response code="200">ok. Devuelve los objetos solicitados por el usuario</response> 
    ///<response code="404">Not. found. No se ha encontrado el objeto solicitado por el usuario</response> 

        [HttpPut("{id}")]
        public async Task<ActionResult<Biblioteca>> PutBiblioteca(int id, Biblioteca biblioteca)
        {
            if(id != biblioteca.BibliotecaID)
            {
                return BadRequest();
            }
            _context.Entry(biblioteca).State= EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch(DbUpdateConcurrencyException)
            {
                if(!BibliotecaExists(id))
                {
                    return NotFound();

                }
                else
                {
                    throw;
                }

            }
            return CreatedAtAction("GetBibliotecaByID", new{id=biblioteca.BibliotecaID}, biblioteca);

        }


///<summary>
    /// book deletion by id 
    ///</summary>
      ///<param name="id"> </param>
     ///<remarks>
    /// in this section the desired book is deleted by inserting its id 
    ///</remarks>
     ///<response code="200">ok. the book that the user deleted is returned  </response> 
    ///<response code="404">Not. The id of the book that the user requested for deletion was not found  </response> 


        [HttpDelete("{id}")]
        public async Task<ActionResult<Biblioteca>> DeleteBiblioteca(int id)
        {
            var bibliotecas = await _context.Bibliotecas.FindAsync(id);
            
            if(bibliotecas==null)
            {
                return NotFound();
            }
            _context.Bibliotecas.Remove(bibliotecas);
            await _context.SaveChangesAsync();
            return bibliotecas;

        }

        private bool BibliotecaExists(int id)
        {
            return _context.Bibliotecas.Any(d=>d.BibliotecaID==id);
        }
    }
}