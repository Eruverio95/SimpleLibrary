using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Helper;
using Library.Logic.Interfaces;
using Library.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : CustomApiController
    {
      private readonly IAuthorizationService _authorizationService;
      private readonly IBookLogic _bookLogic;
      private readonly IUserLogic _userLogic;

      public BooksController(IAuthorizationService authorizationService, IBookLogic bookLogic, IUserLogic userLogic)
      {
        _authorizationService = authorizationService;
        _bookLogic = bookLogic;
        _userLogic = userLogic;
      }

      [HttpGet("/user/current")]
      public async Task<IActionResult> ReadCurrentUser()
      {
        try
        {
          return Ok(UserName);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("user/{userId}")]
      public async Task<IActionResult> ReadUser([FromRoute] string userId)
      {
        try
        {
          var access = await _authorizationService.HaveAdministratorRights(UserName);
          if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

          var result = await _userLogic.ReadUser(userId);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpPost("new")]
      public async Task<IActionResult> CreateBook([FromBody] BookCommandDto viewModel)
      {
        try
        {
          var access = await _authorizationService.HaveAdministratorRights(UserName);
          if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

          var result = await _bookLogic.CreateBook(viewModel);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("{bookId}")]
      public async Task<IActionResult> ReadBook([FromRoute] int bookId)
      {
        try
        {
          var result = await _bookLogic.ReadBook(bookId);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("")]
      public async Task<IActionResult> ReadBooks()
      {
        try
        {
          var result = await _bookLogic.ReadBooks();

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpPut("{bookId}")]
      public async Task<IActionResult> UpdateBook([FromRoute] int bookId, [FromBody] BookCommandDto viewModel)
      {
        try
        {
          var access = await _authorizationService.HaveAdministratorRights(UserName);
          if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

          var result = await _bookLogic.UpdateBook(bookId, viewModel);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpPost("toBook")]
      public async Task<IActionResult> ToBookABook([FromRoute] BookingCommandDto viewModel)
      {
        try
        {
          var result = await _bookLogic.ToBookABook(viewModel);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("booking/{bookId}")]
      public async Task<IActionResult> BookingOfBook([FromRoute] int bookId)
      {
        try
        {
          var access = await _authorizationService.HaveAdministratorRights(UserName);
          if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        var result = await _bookLogic.BookingOfBook(bookId);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("booking/all")]
      public async Task<IActionResult> BookingOfAll()
      {
        try
        {
          var access = await _authorizationService.HaveAdministratorRights(UserName);
          if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

          var result = await _bookLogic.BookingOfAll();

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("booking")]
      public async Task<IActionResult> BookingOfUser()
      {
        try
        {
          var result = await _bookLogic.BookingOfUser(UserName);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }
  }
}