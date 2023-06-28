using AgenciaViajes.DbContexts;
using AgenciaViajes.Exceptions;
using AgenciaViajes.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenciaViajes.Repository
{
    public class HotelSQLRepository : IHotelRepository
    {
        private AppDbContext dbContext;
        public HotelSQLRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //////////////////////LISTAR//////////////////////
        public async Task<IEnumerable<Hotel>> GetHoteles()
        {
            return await dbContext.hoteles.ToListAsync();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            var hotel = await dbContext.hoteles.Where(c => c.idHot == id)
                .FirstOrDefaultAsync();

            if (hotel == null)
            {
                throw new NotFoundException("Hotel not found with id: " + id.ToString());
            }
            return hotel;
        }

        //////////////////////AGREGAR//////////////////////
        public async Task<bool> placeHotel(Hotel hotel)
        {
            dbContext.hoteles.Add(hotel);
            await dbContext.SaveChangesAsync();
            return true;
        }

        //////////////////////ACTUALIZAR//////////////////////
        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            dbContext.hoteles.Update(hotel);
            await dbContext.SaveChangesAsync();
            return hotel;
        }

        //////////////////////ELIMINAR//////////////////////
        public async Task<bool> DeleteHotel(int id)
        {
            var hotel = await dbContext.hoteles.FirstOrDefaultAsync(c => c.idHot == id);
            if (hotel == null)
            {
                return false;
            }
            dbContext.Remove(hotel);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
