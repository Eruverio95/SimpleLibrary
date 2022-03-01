using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.Logic.Interfaces;
using Library.Models;
using Library.Repository.Interfaces;
using Library.ViewModels;

namespace Library.Logic
{
  public class BookLogic : IBookLogic
  {
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;
    private readonly IBookingRepository _bookingRepository;

    public BookLogic(IMapper mapper, IBookRepository bookRepository, IBookingRepository bookingRepository)
    {
      _mapper = mapper;
      _bookRepository = bookRepository;
      _bookingRepository = bookingRepository;
    }

    public async Task<BookQueryDto> CreateBook(BookCommandDto viewModel)
    {
      var model = _mapper.Map<Book>(viewModel);
      var query = await _bookRepository.CreateBook(model);
      var result = _mapper.Map<BookQueryDto>(query);

      return result;
    }

    public async Task<BookQueryDto> ReadBook(int bookId)
    {
      var query = await _bookRepository.ReadBook(bookId);
      var result = _mapper.Map<BookQueryDto>(query);

      return result;
    }

    public async Task<IList<BookQueryDto>> ReadBooks()
    {
      var query = await _bookRepository.ReadBooks();
      var result = _mapper.Map<IList<BookQueryDto>>(query);

      return result;
    }

    public async Task<BookQueryDto> UpdateBook(int bookId, BookCommandDto viewModel)
    {
      var bookExists = await _bookRepository.ReadBook(bookId);
      _mapper.Map(viewModel, bookExists);
      await _bookRepository.UpdateBook();
      var result = _mapper.Map<BookQueryDto>(bookExists);

      return result;
    }

    public async Task<BookingQueryDto> ToBookABook(BookingCommandDto viewModel)
    {
      var model = _mapper.Map<Booking>(viewModel);
      var query = await _bookingRepository.ToBookABook(model);
      var result = _mapper.Map<BookingQueryDto>(query);

      return result;
    }

    public async Task<IList<BookingQueryDto>> BookingOfUser(string userId)
    {
      var query = await _bookingRepository.BookingOfUser(userId);
      var result = _mapper.Map<IList<BookingQueryDto>>(query);

      return result;
    }

    public async Task<IList<BookingQueryDto>> BookingOfBook(int bookId)
    {
      var query = await _bookingRepository.BookingOfBook(bookId);
      var result = _mapper.Map<IList<BookingQueryDto>>(query);

      return result;
    }

    public async Task<IList<BookingQueryDto>> BookingOfAll()
    {
      var query = await _bookingRepository.BookingOfAll();
      var result = _mapper.Map<IList<BookingQueryDto>>(query);

      return result;
    }
  }
}
