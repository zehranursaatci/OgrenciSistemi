using baglanti;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using ogrencibilgileri.Modullers;
using System.Threading.Tasks;

namespace ogrencibilgileri.Depo
{
    public class Ambar :IAmbar
    {
        private readonly IDbConnection _db;

        public Ambar(IOptions<ConnectionStringList> connectionStrings)
        {
            _db = new MySqlConnection(connectionStrings.Value.Baglanti1);
        }

        public void Dispose()
        {
            _db.Close();
        }

        public List<Ogrenci> SearchOgrencis(string tc)
        {
            tc = "12345678910";

            if (string.IsNullOrEmpty(tc))
                return _db.Query<Ogrenci>("SELECT * FROM ogrenci ORDER BY tc ASC LIMIT 10").ToList();

            tc = tc.Trim();

            return _db.Query<Ogrenci>("SELECT * FROM ogrenci WHERE tc LIKE @tc ORDER BY tc ASC LIMIT 10", new { tc = string.Format("%{0}%", tc) }).ToList();
        }



        public List<Okul> SearchOkuls(string tc)
        {
            if (string.IsNullOrEmpty(tc))
                return _db.Query<Okul>("SELECT * FROM okul ORDER BY tc ASC LIMIT 10").ToList();

            tc = tc.Trim();

            return _db.Query<Okul>("SELECT * FROM okul WHERE tc LIKE @tc ORDER BY tc ASC LIMIT 10", new { tc = string.Format("%{0}%", tc) }).ToList();
        }

    }
}
