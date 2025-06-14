//using Library.API.Interface;
//using Library.API.Models.DTO.Circulation;
//using Library.API.Models.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace Library.API.Data.Repository
//{
//    public class CirculationRepository : ICirculationRepository
//    {
//        private readonly LibraryDbContext _context;
//        public CirculationRepository(LibraryDbContext context)
//        {
//            _context = context;
//        }
//        public async Task<List<GetCirculationDTO>> GetAllCirculationsAsync()
//        {
//            return await _context.Circulations.Include(c => c.Book).Include(c => c.User)
//                .Select(c => new GetCirculationDTO
//                {
//                    Id = c.Id,
//                    BookId = c.BookId,
//                    BookName = c.Book.Title,
//                    UserId = c.UserId,
//                    UserName = c.User.Name,
//                    DueDate = c.DueDate.ToString("yyyy-MM-dd HH:mm:ss"),
//                    ReturnedDate = c.ReturnedDate.HasValue ? c.ReturnedDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "Not return yet",
//                    BorrowedDate = c.BorrowedDate.ToString("yyyy-MM-dd HH:mm:ss"),
//                    Status = c.Status.ToString()
//                })
//                .ToListAsync();
//        }

//        public async Task<GetCirculationDTO?> GetCirculationByIdAsync(int id)
//        {
//            try
//            {
//                var findCirculation = await _context.Circulations.Where(c => c.Id == id).Include(c => c.Book).Include(c => c.User).FirstOrDefaultAsync();
//                if (findCirculation == null)
//                {
//                    throw new Exception("The circulation does not exist or already has been deleted");  // or throw an exception based on your error handling strategy
//                }
//                var circulation = new GetCirculationDTO
//                {
//                    Id = findCirculation.Id,
//                    BookId = findCirculation.BookId,
//                    BookName = findCirculation.Book.Title,
//                    UserId = findCirculation.UserId,
//                    UserName = findCirculation.User.Name,
//                    DueDate = findCirculation.DueDate.ToString("yyyy-MM-dd HH:mm:ss"),
//                    ReturnedDate = findCirculation.ReturnedDate.HasValue ? findCirculation.ReturnedDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "Not return yet",
//                    BorrowedDate = findCirculation.BorrowedDate.ToString("yyyy-MM-dd HH:mm:ss"),
//                    Status = findCirculation.Status.ToString()
//                };
//                return circulation;
//            } catch (Exception ex)
//            {                
//                throw new Exception("An error occurred while retrieving the circulation.", ex);
//            }
//        }
//        public async Task<List<GetCirculationDTO?>> CreateCirculationAsync(CreateCirculationDTO circulationDTO)
//        {
//            try
//            {
//                if (circulationDTO == null)
//                {
//                    throw new ArgumentNullException(nameof(circulationDTO), "CreateCirculationDTO cannot be null.");
//                }
//                var findBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == circulationDTO.BookId && !b.Deleted);
//                if (findBook == null)
//                {
//                    throw new Exception("The book does not exist or has already been deleted.");
//                }
//                var findUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == circulationDTO.UserId && !u.Deleted);
//                if (findUser == null)
//                {
//                    throw new Exception("The user does not exist or has already been deleted.");
//                }
//                var validateCirculation = _context.Circulations.Any(c => c.BookId == circulationDTO.BookId && !c.ReturnedDate.HasValue);
//                if (validateCirculation)
//                {
//                    throw new Exception("A circulation for this book is already active and has not been returned yet.");
//                }
//                var newCirculation = new Circulation
//                {
//                    BookId = circulationDTO.BookId,
//                    UserId = circulationDTO.UserId,
//                    BorrowedDate = DateTime.Now,
//                    DueDate = circulationDTO.DueDate
//                };
//                await _context.Circulations.AddAsync(newCirculation);
//                await _context.SaveChangesAsync();
//                var circulationOpened = await _context.Circulations.Where(c => c.UserId == circulationDTO.UserId && !c.ReturnedDate.HasValue)
//                    .Include(c => c.Book).Include(c => c.User)
//                    .Select(c => new GetCirculationDTO
//                    {
//                        Id = c.Id,
//                        BookId = c.BookId,
//                        BookName = c.Book.Title,
//                        UserId = c.UserId,
//                        UserName = c.User.Name,
//                        DueDate = c.DueDate.ToString("yyyy-MM-dd HH:mm:ss"),
//                        ReturnedDate = c.ReturnedDate.HasValue ? c.ReturnedDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "Not return yet",
//                        BorrowedDate = c.BorrowedDate.ToString("yyyy-MM-dd HH:mm:ss"),
//                        Status = c.Status.ToString()
//                    }).ToListAsync();
//                return circulationOpened;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("An error occurred while creating the circulation.", ex);
//            }           
//        }


//        public async Task<GetCirculationDTO?> UpdateCirculationAsync(ReturnCirculationDTO returnCirculationDTO)
//        {
//            try
//            {
//                if (returnCirculationDTO == null)
//                {
//                    throw new ArgumentNullException(nameof(returnCirculationDTO), "ReturnCirculationDTO cannot be null.");
//                }

//                var findCirculation = _context.Circulations.Include(c => c.Book).Include(c => c.User).FirstOrDefault(c => c.Id == returnCirculationDTO.Id || (c.UserId == returnCirculationDTO.UserId && c.BookId == returnCirculationDTO.BookId) && !c.ReturnedDate.HasValue);

//                if (findCirculation == null)
//                {
//                    throw new Exception("The circulation does not exist or has already been returned.");
//                }

//                findCirculation.ReturnedDate = DateTime.Now;
//                _context.Circulations.Update(findCirculation);
//                await _context.SaveChangesAsync();
//                return new GetCirculationDTO
//                {
//                    Id = findCirculation.Id,
//                    BookId = findCirculation.BookId,
//                    BookName = findCirculation.Book.Title,
//                    UserId = findCirculation.UserId,
//                    UserName = findCirculation.User.Name,
//                    DueDate = findCirculation.DueDate.ToString("yyyy-MM-dd HH:mm:ss"),
//                    ReturnedDate = findCirculation.ReturnedDate.HasValue ? findCirculation.ReturnedDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "Not return yet",
//                    BorrowedDate = findCirculation.BorrowedDate.ToString("yyyy-MM-dd HH:mm:ss"),
//                    Status = findCirculation.Status.ToString()
//                };
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("An error occurred while updating the circulation.", ex);
//            }
//        }       
//    }
//}
