using Newtonsoft.Json;
using Registration.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Registration
{
    public class DataSeed
    {
        private DirectoryInfo SolutionDirectory;
        private string MockLocation;
        private string CombinedMockPath;
        public DataSeed()
        {
            SolutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory());
            MockLocation = "/Registration/MockData/";
            CombinedMockPath = SolutionDirectory + MockLocation;
        }

        public PostModel[] Getpost()
        {
            return JsonConvert.DeserializeObject<PostModel[]>(File.ReadAllText(CombinedMockPath + "Post.json"));
        }   
        
    }
}
