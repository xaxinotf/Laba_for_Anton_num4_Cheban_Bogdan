using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using static Laba_for_Anton_num4_Cheban_Bogdan.Constants;

namespace Laba_for_Anton_num4_Cheban_Bogdan
{
    internal class Helper
    {
        public List<StudentInfo> AddStudent(AddStudent form, List<StudentInfo> lst)
        {
            form.info.Name = form.textName.Text;
            form.info.MiddleName = form.textMiddle.Text;
            form.info.LastName = form.textLast.Text;
            form.info.Cafedra = form.textCafedra.Text;
            form.info.Specialty = form.textSpeciality.Text;
            form.info.StartTime = form.timeStart.Text;
            form.info.EndTime = form.timeFinish.Text;
            form.facultet.FacultetName = form.textFacultet.Text;
            form.facultet.DepartamentId = form.textFacultet.Text;
            form.facultet.SectionId = form.textSectionId.Text;
            form.info.Facultet.Add(form.facultet);
            lst.Add(form.info);
            return lst;
        }

        public void serializeAndWriteToJSON(List<StudentInfo> lst, string path)
        {
            var JSONQuery = JsonSerializer.Serialize(lst, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(path, JSONQuery);
        }

        public List<StudentInfo> deserializeJSON(string path)
        {
            if (new FileInfo("Data.json").Length == 0)
            {
                return new List<StudentInfo>();
            }
            var data = File.ReadAllText(path);
            var content = JsonSerializer.Deserialize<List<StudentInfo>>(data);
            return content;
        }

        public List<StudentInfo> orderBy(List<StudentInfo> list, string s)
        {
            if (s == Choice.name)
                return list.OrderBy(x => x.Name).ToList();
            if (s == Choice.middle)
                return list.OrderBy(x => x.MiddleName).ToList();
            if (s == Choice.last)
                return list.OrderBy(x => x.LastName).ToList();
            if (s == Choice.cafedra)
                return list.OrderBy(x => x.Cafedra).ToList();
            if (s == Choice.speciality)
                return list.OrderBy(x => x.Specialty).ToList();
            return list;
        }

        public List<StudentInfo> wipeAllData(Helper helper, string path)
        {
            List<StudentInfo> res = helper.deserializeJSON(path);
            res.Clear();
            helper.serializeAndWriteToJSON(res, path);
            return res;
        }


    }
}
