using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using CS322_DZ13;
using MySqlConnector;

namespace God_of_War_Sa_Wish_a
{
    public class Querie
    {
        static MySqlConnection connect = new MySqlConnection("SERVER=localhost; user id=root; password=P@ssw0rd; database=god_of_war_wish");

        public String Upit { get; set; }
        public Object o { get; set; }

        public Querie()
        {
        }

        public Querie(string upit, object o)
        {
            Upit = upit;
            this.o = o;
        }

        public ArrayList Queries(String upit, Object o)
        {
            var lista = new ArrayList();
            MySqlCommand cmd = new MySqlCommand(upit);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connect;
            connect.Open();
            try
            {
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    switch (o.GetType().Name)
                    {
                        case "Stats":
                            lista.Add(new Stats(dr.GetInt32("StatId"),dr.GetString("CharacterName"), dr.GetInt32("EnchantmentId"), dr.GetInt32("ArmorId"), dr.GetInt32("AbilityId")));
                            break;
                        case "Enchantment":
                            lista.Add(new Enchantment(dr.GetInt32("EnchantmentId"), dr.GetString("EnchantmentName"), dr.GetInt32("Damage"), dr.GetInt32("Defense"), dr.GetInt32("Luck")));
                            break;
                        case "Armor":
                            lista.Add(new Armor(dr.GetInt32("ArmorId"), dr.GetString("ArmorName"), dr.GetInt32("Health"), dr.GetInt32("Shield"), dr.GetInt32("Defense")));
                            break;
                        case "Player":
                            lista.Add(new Player(dr.GetString("CharacterName"), dr.GetInt32("Health"), dr.GetInt32("Shield"), dr.GetInt32("Damage"), dr.GetInt32("Defense"), dr.GetInt32("Luck"), dr.GetInt32("Energy")));
                            break;
                        case "Ability":
                            lista.Add(new Ability(dr.GetInt32("AbilityId"), dr.GetString("AbilityName"), dr.GetInt32("Damage"), dr.GetInt32("EnergyReq")));
                            break;
                        default:
                            Console.WriteLine("Pogresan tip");
                            break;
                    }
                }
        
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        
            return lista;
        }
        
        public void UpdateStats(String newStatName, int newStatValue)
        {
            try
            {
                string Query = $"update god_of_war_wish.stats set {newStatName}={newStatValue} where statId = 1";
                MySqlCommand cmd = new MySqlCommand(Query, connect);
                MySqlDataReader dr;
                connect.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}