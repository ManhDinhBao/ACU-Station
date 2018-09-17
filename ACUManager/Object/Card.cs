using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ACUManager
{
    class Card
    {
        public Card() { }

        public Card(string cardId, string cardNo)
        {
            CardId = cardId;
            CardNo = cardNo;
        }

        private string cardId;

        public string CardId
        {
            get { return cardId; }
            set { cardId = value; }
        }

        private string cardNo;

        public string CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        public static List<Card> LoadCardByUserId(string userId)
        {
            List<Card> cards = new List<Card>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.CardDetailQuery("Q", userId, "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string cardNo = dr["cardNo"].ToString();
                    string cardId = dr["cardId"].ToString();

                    Card c = new Card(cardId, cardNo);
                    cards.Add(c);
                }
                return cards;
            }
            catch (Exception ex)
            {
                return cards;
            }
            return cards;
        }

        public static List<Card> LoadAllCard()
        {
            List<Card> cards = new List<Card>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.CardDetailQuery("Q", "", "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string cardNo = dr["cardNo"].ToString();
                    string cardId = dr["cardId"].ToString();

                    Card c = new Card(cardId, cardNo);
                    cards.Add(c);
                }
                return cards;
            }
            catch (Exception ex)
            {
                return cards;
            }
            return cards;
        }

        public string Add(string creator)
        {
            string result = "OK";
            DataTable dt = null;
            DataTable dt1 = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.CardSave("A",cardId, cardNo, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
                return result;
            }
            catch
            {
                return "ERROR";
            }

        }

        public string AddUser(string userId,string creator)
        {
            string result = "OK";
            DataTable dt = null;
            DataTable dt1 = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.CardDetailSave("A", cardNo, userId, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
                return result;
            }
            catch
            {
                return "ERROR";
            }

        }

        public string Delete( string creator)
        {
            string result = "OK";
            DataTable dt = null;
            DataTable dt1 = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.CardSave("D", cardId, cardNo, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
                return result;
            }
            catch
            {
                return "ERROR";
            }

        }
        public static string DeleteAllUser(string userId,string creator)
        {
            string result = "OK";
            DataTable dt = null;
            DataTable dt1 = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.CardDetailSave("D", "", userId, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
                return result;
            }
            catch
            {
                return "ERROR";
            }

        }
    }
}
