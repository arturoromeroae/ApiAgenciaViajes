﻿using AgenciaViajes.Models;

namespace AgenciaViajes.Repository
{
    public interface IActividadRepository
    {
        //AGREGAR
        public Task<bool> placeActividad(Actividad actividad);

        //LISTAR
        Task<IEnumerable<Actividad>> GetActividades();
        Task<Actividad> GetActividadById(int id);

        //ACTUALIZAR
        Task<Actividad> UpdateActividad(Actividad actividad);

        //ELIMINAR
        Task<bool> DeleteActividad(int id);
    }
}
