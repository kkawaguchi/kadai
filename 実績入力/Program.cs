using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 勉強会実績入力
{
    class Program
    {
        static void Main(string[] args)
        {
            string descripshon;　　　　　　　　　　　　　　　　　　　　　　　　　　//内容
            string dayDuty;                            　　　　　　　　　　　　　　//日直
            string date;
            string InParticipant;                                                    //参加者
            string time;
            string meetingID;
            string pass;

            Console.Write("パス：");　　　　　　　　　 　　　　　　　　　　　　　　//内容入力
            pass = Console.ReadLine();
            Console.WriteLine("");

            Console.Write("内容：");　　　　　　　　　 　　　　　　　　　　　　　　//内容入力
            descripshon = Console.ReadLine();
            Console.WriteLine("");

            Console.Write("日直：");　　　　　　　　　 　　　　　　　　　　　　　　//日直入力
            dayDuty = Console.ReadLine();
            Console.WriteLine("");

            Console.Write("日付：");
            date = Console.ReadLine();
            Console.WriteLine("");

            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pass;

            if (descripshon != "" || dayDuty != "")
            {
                Meeting meeting = new Meeting();
                meeting.SetDate(DateTime.Parse(date));
                meeting.SetDescripshon(descripshon);
                meeting.SetDayDuty(long.Parse(dayDuty));

                conn.Open();

                MeetingRepository meetingRepository = new MeetingRepository(conn);
                meetingRepository.Insert(meeting);

                meetingID = meetingRepository.GetNotID(meeting).ToString();

                conn.Close();
            }
            else
            {
                conn.Open();

                MeetingRepository meetingRepository = new MeetingRepository(conn);
                IEnumerable<Meeting> meeting = meetingRepository.GetAll();

                foreach (Meeting m in meeting)
                {
                    
                    Console.WriteLine(m.GetMeetingID() + "-" + m.GetDate().ToString() + "-" + m.GetDescripshon() + "-" + m.GetDayDuty());
                }

                conn.Close();

                Console.Write("会ID：");
                meetingID = Console.ReadLine();
                Console.WriteLine("");
            }

            conn.Open();

            PeopleRepository peopleRepository = new PeopleRepository(conn);
            IEnumerable<Person> people = peopleRepository.GetAll();

            foreach (Person p in people)
            {
                Console.WriteLine(p.personID + "-" + p.name + "-" + p.kana);
            }

            conn.Close();

            Console.Write("参加者(カンマ区切り)：");
            InParticipant = Console.ReadLine();
            Console.WriteLine("");

            Console.Write("実績時間(分)：");
            time = Console.ReadLine();
            Console.WriteLine("");

            Participant participant = new Participant(InParticipant);
            List<long> particiantList = participant.CreateParticiantList();
            Achievement achivement = null;

            foreach(long l in particiantList)
            {
                achivement = new Achievement();
                achivement.personID = l;
                achivement.date = DateTime.Parse(date);
                achivement.meetingID = long.Parse(meetingID);
                achivement.time = long.Parse(time);

                AchievementRepository achivementRepository = new AchievementRepository(conn);
                achivementRepository.Insert(achivement);
            }
        }

        class PeopleRepository
        {
            private IDbConnection conn;
            
            public PeopleRepository(IDbConnection conn)
            {
                this.conn = conn;
            }

            public List<Person> GetAll()
            {
                string sql;

                sql = "";
                sql = "SELECT * FROM 人 ;";

                IDbCommand command = this.conn.CreateCommand();
                command.CommandText = sql;
                IDataReader reader = command.ExecuteReader();
                List<Person> people = new List<Person>();

                while (reader.Read())
                {
                    Person person = new Person();
                    person.personID = reader.GetInt64(0);
                    person.name = reader.GetString(1);
                    person.kana = reader.GetString(2);

                    people.Add(person);
                }

                return people;
            }
        }

        class MeetingRepository
        {
            private IDbConnection conn;
            public MeetingRepository(IDbConnection conn) 
            {
                this.conn = conn;
            }

            public void Insert(Meeting meeting)
            {
                String sql;
                sql = "";
                sql = "INSERT INTO 会 VALUSE(null,'"+ meeting.GetDate() + "','" + meeting.GetDescripshon() + "'," + meeting.GetDayDuty() + ");";

                IDbCommand command = this.conn.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }

            public Meeting Get(long id)
            {
                string sql;

                sql = "";
                sql = "SELECT 日付,内容,日直 FROM 会 WHERE 会ID = " + id  + ";";

                IDbCommand command = this.conn.CreateCommand();
                command.CommandText = sql;
                IDataReader reader = command.ExecuteReader();
                Meeting meeting = null;

                if (reader.Read())
                {
                    meeting = new Meeting();
                    meeting.SetDate(reader.GetDateTime(0));
                    meeting.SetDescripshon(reader.GetString(1));
                    meeting.SetDayDuty(reader.GetInt64(2));
                }

                return meeting;
            }

            public Meeting GetNotID(Meeting m)
            {
                string sql;

                sql = "";
                sql = "SELECT 日付,内容,日直 FROM 会 WHERE 内容 = " + m.GetDescripshon() + "AND 日直 = " + m.GetDayDuty() + "AND 日付 = " + m.GetDate() +";";

                IDbCommand command = this.conn.CreateCommand();
                command.CommandText = sql;
                IDataReader reader = command.ExecuteReader();
                Meeting meeting = null;

                if (reader.Read())
                {
                    meeting = new Meeting();
                    meeting.SetDate(reader.GetDateTime(0));
                    meeting.SetDescripshon(reader.GetString(1));
                    meeting.SetDayDuty(reader.GetInt64(2));
                }

                return meeting;
            }

            public List<Meeting> GetAll()
            {
                string sql;

                sql = "";
                sql = "SELECT * FROM 会 ;";

                IDbCommand command = this.conn.CreateCommand();
                command.CommandText = sql;
                IDataReader reader = command.ExecuteReader();
                List<Meeting> meeting = new List<Meeting>();

                while (reader.Read())
                {
                    Meeting m = new Meeting();
                    m.SetDate(reader.GetDateTime(0));
                    m.SetDescripshon(reader.GetString(1));
                    m.SetDayDuty(reader.GetInt64(2));

                    meeting.Add(m);
                }

                return meeting;
            }
        }

        class AchievementRepository
        {
            private IDbConnection conn;
            public AchievementRepository(IDbConnection conn) 
            {
                this.conn = conn;
            }

            public void Insert(Achievement achievement)
            {
                String sql;
                sql = "";
                sql = "INSERT INTO 実績 VALUSE(null,'" + achievement.date + "','" + achievement.meetingID + "'," + achievement.personID + "'," + achievement.time + ");";

                IDbCommand command = this.conn.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }

        class Person
        {
            public string name{ get; set; }
            public string kana{ get; set; }
            public long personID{ get; set; }
        }

        class Meeting
        {
            private string descripshon;　　　//内容
            private long dayDuty;        　　//日直
            private DateTime date;
            private long meetingID;

            public string GetDescripshon()
            {
                return this.descripshon;
            }

            public long GetDayDuty()
            {
                return this.dayDuty;
            }

            public DateTime GetDate()
            {
                return this.date;
            }

            public void SetDescripshon(string descripshon)
            {
                this.descripshon = descripshon;
            }

            public void SetDayDuty(long dayDuty)
            {
                this.dayDuty = dayDuty;
            }

            public void SetDate(DateTime date)
            {
                this.date = date;
            }

            public long GetMeetingID()
            {
                return this.meetingID;
            }

            public void SetMeetingID(long meetingID)
            {
                this.meetingID = meetingID;
            }
        }

        class Achievement
        {
            public long achievementID { get; set; }
            public long personID { get; set; }
            public long meetingID { get; set; }
            public DateTime date { get; set; }
            public long time { get; set; }
        }

        //人IDの文字列をもらい、リストにして返す。
        class Participant
        {
            private string participant;

            public Participant(string participant)
            {
                this.participant = participant;
            }

            public List<long> CreateParticiantList()
            {
                string[] p = this.participant.Split(',');
                List<long> particiantList = new List<long>();

                foreach (string personID in p)
                {
                    particiantList.Add(long.Parse(personID));
                }

                return particiantList;
            }
        }
    }
}
