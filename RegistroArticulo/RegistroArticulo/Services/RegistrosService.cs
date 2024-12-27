using Microsoft.EntityFrameworkCore;
using RegistroArticulo.DAL;
using RegistroArticulo.Models;
using System.Linq.Expressions;

namespace RegistroArticulo.Services;

public class RegistrosService(Contexto _contexto)
{
    public async Task<bool> Guardar(Articulos articulo)
    {
        if(! await Existe(articulo.ArticuloId))
            return await Insertar(articulo);
        else 
            return await Modificar(articulo);
    }

    private async Task<bool> Existe(int articuloId)
    {
        return await _contexto.Articulos
            .AnyAsync(e => e.ArticuloId == articuloId);
    }
    
    private async Task<bool> Insertar(Articulos articulo)
    {
        _contexto.Articulos .Add(articulo);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Articulos articulo)
    {
        _contexto.Articulos.Update(articulo);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<Articulos?> Buscar(int articuloId)
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.ArticuloId == articuloId);
    }

    public async Task<bool> Eliminar(int articuloId)
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .Where(e => e.ArticuloId == articuloId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
