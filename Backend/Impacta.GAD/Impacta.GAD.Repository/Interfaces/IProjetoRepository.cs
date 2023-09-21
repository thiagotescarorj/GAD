using Impacta.GAD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Repository.Interfaces {
    public interface IProjetoRepository: IGADRepository {
        Task<Projeto> GetProjetoChamadoByIdsAsync(long chamadoId, long id);
        Task<Projeto> GetProjetoUsuarioByIdsAsync(long usuarioId, long id);
        Task<Projeto[]> GetAllByChamadoIdAsync(long chamadoId);
        Task<Projeto[]> GetAllByUsuarioIdAsync(long usuarioId);
    }
}
