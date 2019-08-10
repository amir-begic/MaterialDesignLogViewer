using System;
using System.Linq;
using System.Linq.Expressions;

namespace MonitoringClient.Services.RepositoryServices
{
    public interface IRepositoryBase<M>
    {
        /// <summary>
        /// Liefert ein einzelnes Model-Objekt vom Typ M zurück,
        /// welches anhand dem übergebenen PrimaryKey geladen wird.
        /// </summary>
        /// <typeparam name="P">Type des PrimaryKey</typeparam>
        /// <param name="pkValue">Wert des PrimaryKey</param>
        /// <returns>gefundenes Model-Objekt, ansonsten null</returns>
        M GetSingle<P>(P pkValue);

        /// <summary>
        /// Fügt das Model-Objekt zur Datenbank hinzu (Insert)
        /// </summary>
        /// <param name="entity">zu speicherndes Model-Object</param>
        void Add(M entity);

        /// <summary>
        /// Löscht das Model-Objekt aus der Datenbank (Delete)
        /// </summary>
        /// <param name="entity">zu löschendes Model-Object</param>
        void Delete(M entity);

        /// <summary>
        /// Aktualisiert das Model-Objekt in der Datenbank hinzu (Update)
        /// </summary>
        /// <param name="entity">zu aktualisierendes Model-Object</param>
        void Update(M entity);

        /// <summary>
        /// Gibt eine Liste von Model-Objekten vom Typ M zurück,
        /// die gemäss der WhereBedingung geladen wurden. Die Werte der
        /// Where-Bedingung können als separat übergeben werden,
        /// damit diese für PreparedStatements verwendet werden können.
        /// (Verhinderung von SQL-Injection)
        /// </summary>
        /// <param name="whereCondition">WhereBedingung als string
        /// z.B. "NetPrice > @netPrice and Active = @active and Description like @desc</param>
        /// <param name="parameterValues">Parameter-Werte für die Wherebedingung
        /// bspw: {{"netPrice", 10.5}, {"active", true}, {"desc", "Wolle%"}}</param>
        /// <returns></returns>
        IQueryable<M> GetAll(Expression<Func<M, bool>> whereCondition);

        /// <summary>
        /// Gibt eine Liste aller in der DB vorhandenen Model-Objekte vom Typ M zurück
        /// </summary>
        /// <returns></returns>
        IQueryable<M> GetAll();

        IQueryable<M> Query(Expression<Func<M, bool>> whereCondition);

        /// <summary>
        /// Zählt in der Datenbank die Anzahl Model-Objekte vom Typ M, die der
        /// Where-Bedingung entsprechen
        /// </summary>
        /// <param name="whereCondition">WhereBedingung als string
        /// z.B. "NetPrice > @netPrice and Active = @active and Description like @desc</param>
        /// <param name="parameterValues">Parameter-Werte für die Wherebedingung
        /// bspw: {{"netPrice", 10.5}, {"active", true}, {"desc", "Wolle%"}}</param>
        /// <returns></returns>
        long Count(Expression<Func<M, bool>> whereCondition);

        /// <summary>
        /// Zählt alle Model-Objekte vom Typ M
        /// </summary>
        /// <returns></returns>
        long Count();

        void AddByProcedure(M entity);
        void ClearByProcedure<P>(P pkValue);
        IQueryable<M> GetDuplicateLogEntries();
        /// <summary>
        /// Gibt den Tabellennamen zurück, auf die sich das Repository bezieht
        /// </summary>
        string TableName { get; }
    }
}
