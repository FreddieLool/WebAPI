using MySql.Data.MySqlClient;
using System;


namespace WebAPITest.Controllers
{
    public class DatabaseManager
    {
        string con_str = "Server=localhost; database=game; UID=root; password=071201DaniK;";
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;

        private void Disconnect()
        {
            con.Close();
        }
        private void Connect()
        {
            con = new MySqlConnection(con_str);
            try
            {
                con.Open();
            }
            catch
            {
                con.Close();
            }
        }

        internal string SetPlayer(string name, int ID)
        {
            string result;
            try
            {
                Connect();
                ;
                string query = "UPDATE `triviagame`.`isplayerconnected` SET `WhichPlayer` = ('" + name + "') WHERE(`PlayerID` = '" + ID +"')";
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                result = "Success";

            }
            catch
            {
                Disconnect();
                return "Failure";
            }
            return result;
        }

        internal int SetScore(int score)
        {
            int result;
            try
            {
                Connect();
                string query = "INSERT INTO triviagame.playerscore(PlayerScore) values(" + score + ")";
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                result = score;

            }
            catch
            {
                Disconnect();
                return 0;
            }
            return result;
        }

        public int GetPlayerScore(int whichPlayerID)
        {
            try
            {
                Connect();
                string query = "SELECT PlayerScore FROM triviagame.playerscore WHERE WhichPlayerID =" + whichPlayerID;
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int score = reader.GetInt32("PlayerScore");
                    Disconnect();
                    return score;
                }
                else
                {
                    Disconnect();
                    return 0;
                }
            }
            catch
            {
                Disconnect();
                return 0;
            }

        }
        public string GetPlayerName(int playerId)
        {
            try
            {
                Connect();
                string query = "SELECT WhichPlayer FROM triviagame.isplayerconnected WHERE PlayerID =" + playerId;
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string name = reader.GetString("WhichPlayer");
                    Disconnect();
                    return name;
                }
                else
                {
                    Disconnect();
                    return null;
                }
            }
            catch
            {
                Disconnect();
                return null;
            }

        }

        public Question GetQuestion(int QuestionID)
        {
            try
            {
                Connect();
                string query = "SELECT QuestionText,ans1,ans2,ans3,ans4,correctID FROM triviagame.questions WHERE ID =" + QuestionID;
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Question question = new Question();
                    //string result = reader.GetString("Question") + "*" + reader.GetString("ans1")+ reader.GetString("ans2") + "*" + reader.GetString("ans3") + "*" + reader.GetString("ans4") + "*" + reader.GetString("correctID");
                    question.text = reader.GetString("QuestionText");
                    question.ans1 = reader.GetString("ans1");
                    question.ans2 = reader.GetString("ans2");
                    question.ans3 = reader.GetString("ans3");
                    question.ans4 = reader.GetString("ans4");
                    question.correctID = reader.GetInt32("correctID");

                    Disconnect();
                    return question;
                }
                else
                {
                    Disconnect();
                    return null;
                }
            }
            catch
            {
                Disconnect();
                return null;
            }

        }
    }
}