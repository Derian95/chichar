using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

using pry01.Data.Idiomas_v2.Conexto;
using pry100.Utilitario.Idiomas_v2.Enumerables;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace pry01.Data.Idiomas_v2.Repositorio
{
    public class rep_Matrix<TEntity> where TEntity : class
    {
        public DbSet<TEntity> entidades;
        private readonly Matrix _contextoMatrix = new Matrix();
        public rep_Matrix() { entidades = _contextoMatrix.Set<TEntity>(); }

        #region OBTENER
        public TEntity Obtener()
        {
            return entidades.FirstOrDefault();
        }

        public TEntity Obtener(Expression<Func<TEntity, bool>> where)
        {
            IQueryable<TEntity> query = entidades;
            return BaseWhere(query, where).FirstOrDefault();
        }

        public TEntity Obtener(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> query = entidades;
            return BaseInclude(query, navigationProperties).FirstOrDefault();
        }

        public TEntity Obtener(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> query = entidades;
            return BaseObtener(query, where, navigationProperties).FirstOrDefault();
        }

        public TEntity Obtener(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> orderBy, enm_G_OrdenarModelo ordenarModelo, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> query = entidades;
            return BaseObtenerConOrderBy(query, where, orderBy, ordenarModelo, navigationProperties).FirstOrDefault();
        }
        #endregion



        #region OBTENER LISTA
        public IList<TEntity> ObtenerListado()
        {
            return entidades.ToList();
        }

        public IList<TEntity> ObtenerListado(Expression<Func<TEntity, bool>> where)
        {
            IQueryable<TEntity> query = entidades;
            return BaseWhere(query, where).ToList();
        }

        public IList<TEntity> ObtenerListado(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> query = entidades;
            return BaseInclude(query, navigationProperties).ToList();
        }

        public IList<TEntity> ObtenerListado(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> query = entidades;
            return BaseObtener(query, where, navigationProperties).ToList();
        }

        public IList<TEntity> ObtenerListado(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> orderBy, enm_G_OrdenarModelo ordenarModelo, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> query = entidades;
            return BaseObtenerConOrderBy(query, where, orderBy, ordenarModelo, navigationProperties).ToList();
        }
        #endregion



        #region CRUD
        public void Agregar(TEntity entity) { _contextoMatrix.Set<TEntity>().Add(entity); }
        public void AgregarVarios(List<TEntity> entity) { _contextoMatrix.Set<TEntity>().AddRange(entity); }

        public void Modificar(TEntity entity) { _contextoMatrix.Set<TEntity>().Update(entity); }

        public void ModificarVarios(List<TEntity> entity) { _contextoMatrix.Set<TEntity>().UpdateRange(entity); }

        public void GuardarCambios() { _contextoMatrix.SaveChanges(); }
        #endregion



        #region INSTRUCCIONES
        private IQueryable<TEntity> BaseObtener(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            query = BaseWhere(query, where);
            query = BaseInclude(query, navigationProperties);

            return query;
        }
        private IQueryable<TEntity> BaseWhere(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where)
        {
            if (where != null)
            {
                query = query.Where(where);
            }
            return query;
        }
        private IQueryable<TEntity> BaseInclude(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            if (navigationProperties != null)
            {
                if (navigationProperties.Count() > 0)
                {
                    foreach (Expression<Func<TEntity, object>> item in navigationProperties)
                    {
                        query = query.Include(item);
                    }
                }
            }
            return query;
        }
        private IQueryable<TEntity> BaseObtenerConOrderBy(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> orderBy, enm_G_OrdenarModelo ordenarModelo, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            //https://stackoverflow.com/questions/45773050/including-children-of-children-in-c-sharp-generic-repository-ef

            query = BaseWhere(query, where);
            query = BaseInclude(query, navigationProperties);
            query = BaseOrderBy(query, orderBy, ordenarModelo);

            return query;
        }
        private IQueryable<TEntity> BaseOrderBy(IQueryable<TEntity> query, Expression<Func<TEntity, object>> orderBy, enm_G_OrdenarModelo ordenar)
        {
            if (orderBy != null)
            {
                if (ordenar == enm_G_OrdenarModelo.Ascendente)
                {
                    query = query.OrderBy(orderBy);
                }
                else if (ordenar == enm_G_OrdenarModelo.Descendente)
                {
                    query = query.OrderByDescending(orderBy);
                }
            }
            return query;
        }
        #endregion



        #region MANIPULACION DE LISTAS
        public bool ExecuteStoredProcedureVoid(string storedProcedure,
              List<SqlParameter> parameters)
        {
            DbConnection connection = _contextoMatrix.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
                connection.Open();
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = storedProcedure;
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                }
            }
            connection.Close();
            return true;
        }
        public TEntity ExecuteStoredProcedureObject<TEntity>(string storedProcedure,
              List<SqlParameter> parameters) where TEntity : new()
        {
            List<TEntity> objetos = new List<TEntity>();
            DbConnection connection = _contextoMatrix.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
                connection.Open();
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = storedProcedure;
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    if (IsSimple(typeof(TEntity)))
                    {
                        objetos = DataReaderMapToList<TEntity>(dataReader, false, true);
                    }
                    else
                    {
                        objetos = DataReaderMapToList<TEntity>(dataReader, false, false);
                    }
                }
            }
            connection.Close();
            return objetos.FirstOrDefault();
        }
        public List<TEntity> ExecuteStoredProcedureList<TEntity>(string storedProcedure,
              List<SqlParameter> parameters) where TEntity : new()
        {
            List<TEntity> objetos;
            DbConnection connection = _contextoMatrix.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
                connection.Open();
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = storedProcedure;
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    objetos = DataReaderMapToList<TEntity>(dataReader, true, false);
                }
            }
            connection.Close();
            return objetos;
        }

        private static List<TEntity> DataReaderMapToList<TEntity>(DbDataReader dr, bool multiple, bool simpleType)
        {
            List<TEntity> list = new List<TEntity>();
            bool auxiliar = true;
            while (dr.Read() && auxiliar)
            {
                if (simpleType)
                {
                    object val = dr[0];
                    object valor = Convert.ChangeType(val, typeof(TEntity));
                    list.Add((TEntity)valor);
                    auxiliar = false;
                }
                else
                {
                    TEntity obj = Activator.CreateInstance<TEntity>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        if (!Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                    list.Add(obj);
                    if (!multiple)
                    {
                        auxiliar = false;
                    }
                }
            }
            return list;
        }
        #endregion



        #region OTROS
        private bool IsSimple(Type type)
        {
            return type.IsPrimitive
              || type.IsEnum
              || type.Equals(typeof(string))
              || type.Equals(typeof(decimal));
        }

        public virtual IDbContextTransaction _repositorio_getBT() { return _contextoMatrix._contexto_getBT(); }
        #endregion
    }
}
