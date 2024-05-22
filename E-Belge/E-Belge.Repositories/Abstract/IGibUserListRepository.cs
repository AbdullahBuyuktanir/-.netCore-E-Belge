using Core.DataAccess.Abstract;
using E_Belge.Model.DataTransferObjects;
using E_Belge.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Belge.Repositories.Abstract;

public interface IGibUserListRepository
{
  GibUserList? GetGibUserList(string query, object? param = null);
  Task<IEnumerable<GibUserList>> GetGibUserListAllAsync(string query, object? param = null);
  int ExecuteGibUserList(string query, GibUserList model);
  int GetCountGibUserList(string query);
}