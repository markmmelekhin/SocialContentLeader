using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using VkPostsCollector.BusinessLayer;

namespace VkPostsCollector.ApplicationLayer
{
    public static class Configs
    {
        public static string AccessToken { get; set; } = "44d77fd344d77fd344d77fd30644a69363444d744d77fd31b1035924bb1683e0a9f68e5"; // Тут можно например ключ приложения вк, которое тоже надо создать: https://vk.com/apps?act=manage
        public static string TelegramToken { get; set; } = "1234245036:AAG7KU0QvRCWMSW-YfjNa7o_lqwifVYAZWI"; // Токен бота в телеге
        public static string AdLink { get; set; } = "https://alitems.com/g/1e8d114494713ce4258416525dc3e8/";
        public static string TelegramChannel { get; set; } = "@yafilantrop";
        
        public static List<GroupDTO> Groups = new List<GroupDTO>();
        public static PublicationFilters PublicationFilters = new PublicationFilters();

        private static XmlSerializer GroupsSerializer = new XmlSerializer(typeof(List<GroupDTO>));
        private static string GroupsFileName = "Groups.exml";

        private static XmlSerializer FiltersSerializer = new XmlSerializer(typeof(PublicationFilters));
        private static string FiltersFileName = "Filters.exml";

        public static void GroupsLoad()
        {
            if (File.Exists(GroupsFileName) == false) return;

            using (FileStream fs = new FileStream(GroupsFileName, FileMode.OpenOrCreate))
            {
                Groups = (List<GroupDTO>)GroupsSerializer.Deserialize(fs);
            }
        }
        public static void GroupsSave()
        {
            using (FileStream fs = new FileStream(GroupsFileName, FileMode.OpenOrCreate))
            {
                GroupsSerializer.Serialize(fs, Groups);
            }
        }

        public static void FiltersLoad()
        {
            if (File.Exists(FiltersFileName) == false) return;

            using (FileStream fs = new FileStream(FiltersFileName, FileMode.OpenOrCreate))
            {
                PublicationFilters = (PublicationFilters)FiltersSerializer.Deserialize(fs);
            }
        }
        public static void FiltersSave()
        {
            using (FileStream fs = new FileStream(FiltersFileName, FileMode.OpenOrCreate))
            {
                FiltersSerializer.Serialize(fs, PublicationFilters);
            }
        }

        internal class PublicationFilters
        {
        }
    }
}
