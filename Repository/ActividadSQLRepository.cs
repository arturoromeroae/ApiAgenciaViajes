﻿using AgenciaViajes.DbContexts;
using AgenciaViajes.Exceptions;
using AgenciaViajes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AgenciaViajes.Repository
{
    public class ActividadSQLRepository:IActividadRepository
    {
        private AppDbContext dbContext;
        public ActividadSQLRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //////////////////////LISTAR//////////////////////
        public async Task<IEnumerable<Actividad>> GetActividades()
        {
            return await dbContext.actividades.ToListAsync();
        }

        public async Task<Actividad> GetActividadById(int id)
        {
            var actividad = await dbContext.actividades.Where(c => c.idAct == id)
                .FirstOrDefaultAsync();

            if (actividad == null)
            {
                throw new NotFoundException("Customer not found with id: " + id.ToString());
            }
            return actividad;
        }

        //////////////////////AGREGAR//////////////////////
        public async Task<bool> placeActividad(Actividad actividad)
        {
            dbContext.actividades.Add(actividad);
            await dbContext.SaveChangesAsync();
            return true;
        }

        //////////////////////ACTUALIZAR//////////////////////
        public async Task<Actividad> UpdateActividad(Actividad actividad)
        {
            dbContext.actividades.Update(actividad);
            await dbContext.SaveChangesAsync();
            return actividad;
        }

        //////////////////////ELIMINAR//////////////////////
        public async Task<bool> DeleteActividad(int id)
        {
            var actividad = await dbContext.actividades.FirstOrDefaultAsync(c => c.idAct == id);
            if (actividad == null)
            {
                return false;
            }
            dbContext.Remove(actividad);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
