using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;


namespace MvcApplication1.Models
{
    public class OfficialLanguages
    {
        public List<OfficialLanguage> OfficialLanguageList { get; set; }

        public OfficialLanguages()
        {

            try
            {
                OfficialLanguageList = new List<OfficialLanguage>();
                string connstring = "SERVER=ec2-54-225-101-124.compute-1.amazonaws.com;Database=ddehqcgsacci3g;User name=mmmwsvrkwfstit;Password=vlliFqilBOUVyWVY-FZfV50Wa3;SSL=true";

                using (NpgsqlConnection conn = new NpgsqlConnection(connstring))
                {
                    conn.Open();
                    string sql = "SELECT c.code, c.continent, c.name, cl.language, c.population, floor(cl.percentage) as percentage, round(cast(cl.percentage as numeric), 2) as roundedPercentage " +
                            "FROM country c INNER JOIN countryLanguage cl ON (cl.countryCode=c.code) " +
                            "WHERE isofficial = true " +
                            "ORDER BY c.continent ASC, c.name ASC, cl.percentage DESC";

                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    ds.Reset();
                    da.Fill(ds);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        OfficialLanguage ol = new OfficialLanguage();
                        ol.Code = dr["code"].ToString();
                        ol.Continent = dr["continent"].ToString();
                        ol.Name = dr["name"].ToString();
                        ol.Language = dr["language"].ToString();
                        ol.Population = (int)dr["population"];
                        // ol.Percentage = (int)dr["percentage"];
                        ol.Percentage = int.Parse(dr["percentage"].ToString());
                        ol.RoundedPercentage = double.Parse(dr["roundedPercentage"].ToString());
                        OfficialLanguageList.Add(ol);
                    }
                }


            }
            catch (Exception msg)
            {

            }
        }
    }
}