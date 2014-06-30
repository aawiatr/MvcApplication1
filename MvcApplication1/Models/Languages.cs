using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;

namespace MvcApplication1.Models
{
    public class Languages
    {
        public String CountryName { get; set; }
        public List<Language> LanguageList { get; set; }

        public Languages(String code)
        {
            try
            {
                LanguageList = new List<Language>();
                string connstring = "SERVER=ec2-54-225-101-124.compute-1.amazonaws.com;Database=ddehqcgsacci3g;User name=mmmwsvrkwfstit;Password=vlliFqilBOUVyWVY-FZfV50Wa3;SSL=true";

                using(NpgsqlConnection conn = new NpgsqlConnection(connstring))
                {
                    conn.Open();
                    string sql = "SELECT c.name, cl.language, cl.percentage FROM country c INNER JOIN countryLanguage cl ON (cl.countryCode=c.code) WHERE c.code  = '" + code + "'";

                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    ds.Reset();
                    da.Fill(ds);
                    
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (string.IsNullOrEmpty(CountryName))
                            CountryName = dr["name"].ToString();
                        Language l = new Language();
                        l.LanguageName = dr["language"].ToString();
                        l.LanguagePercentage = double.Parse(dr["percentage"].ToString());
                        l.Color = GenerateColor();
                        LanguageList.Add(l);
                    }

                }
            }
            catch (Exception msg)
            {

            }
        }

        private string GenerateColor()
        {
            Random random = new Random();
            return String.Format("#{0:X6}", random.Next(0x1000000));
        }
    }
}