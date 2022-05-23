using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXC_Assigment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new ApplicationDbContext();

            Console.WriteLine(GetRegularsProjectsDetails(dbContext));
            Console.WriteLine(GetStageDAta(dbContext, "си плюс плюс"));
            Console.WriteLine(GetRegularsNames(1, dbContext));
            Console.WriteLine(GetRegularData(1, dbContext));
        }

        // За всички изпълнители извеждане на: името на изпълнителя, общ обем на изходния код и общ обем на документацията на всички модули, разработвани от този изпълнител 
        private static string GetRegularsProjectsDetails(ApplicationDbContext dbContext)
        {
            var sb = new StringBuilder();
            var regulars = dbContext.Regulars.ToList();
            var IdList = new List<int>();
            foreach (var reg in regulars)
            {
                IdList.Add(reg.Id);
            }

            for (int i = 0; i < IdList.Count; i++)
            {
                var regular = dbContext.Regulars.Where(x => x.Id == IdList[i]).FirstOrDefault();
                var regularModules = dbContext.Modules.Where(x => x.RegularId == regular.Id);

                string name = string.Empty;
                decimal codeVolume = 0;
                decimal documentationVolume = 0;

                foreach (var module in regularModules)
                {
                    name = module.Regular.Name;
                    codeVolume += module.ExitCodeVolume;
                    documentationVolume += module.DocumentationVolume;
                }
                sb.AppendLine($"Regular name: {name}");
                sb.AppendLine($"Total code volume: {codeVolume}");
                sb.AppendLine($"Total documentation volume: {documentationVolume}");
            }
            return sb.ToString();
        }

        // Извеждане на крайната дата за завършване и името на ръководител на етапа, в който се разработва модула с име „си плюс плюс“
        private static string GetStageDAta(ApplicationDbContext dbContext, string moduleName)
        {
            var sb = new StringBuilder();
            var module = dbContext.Modules.Where(m => m.Name == moduleName).ToList().FirstOrDefault();
            var stages = dbContext.Stages.ToList();
            for (int i = 0; i < stages.Count; i++)
            {
                var currentStage = stages[i];

                if (currentStage.Modules.Contains(module))
                {
                    var supervisorId = module.Stage.SupervisorId;
                    var supervisorName = dbContext.Supervisors.Where(x => x.Id == supervisorId).FirstOrDefault().Name;
                    sb.AppendLine($"Supervisor name: {supervisorName}");

                    var deadEnd = (currentStage.Deadend.ToString());
                    sb.AppendLine($"Deadend: {deadEnd}");
                }
            }
            return sb.ToString();
        }

        //Извеждане на имената на изпълнителите, които работят по модули включени в етапи ръководени от изпълнителя номер 1000
        public static string GetRegularsNames(int supervisorId, ApplicationDbContext dbContext)
        {
            var sb = new StringBuilder();
            var modules = dbContext
                .Modules
                .Where(m => m.Stage.Supervisor.Id == supervisorId);

            var regulars = dbContext
                .Regulars.ToList();

            for (int i = 0; i < regulars.Count; i++)
            {
                var currentRegular = regulars[i];
                foreach (var item in modules)
                {
                    if (currentRegular.Modules.Contains(item))
                    {
                        sb.AppendLine($"Regular name: {currentRegular.Name}");
                    }
                }
            }

            return sb.ToString();
        }

        // Извеждане на името на модула, планираният и действителният срок за завършване на модулите, които се разработват от изпълнител с номер 1000.
        private static string GetRegularData(int regularId, ApplicationDbContext dbContext)
        {
            var sb = new StringBuilder();

            var modules = dbContext.Modules
                .Where(m => m.RegularId == regularId)
                .ToList();

            foreach (var module in modules)
            {
                sb.AppendLine($"Module name: {module.Name}");
                sb.AppendLine($"Planed deadend: {module.PlanedDeadend}");
                sb.AppendLine($"True deadend date: {module.TrueDeadend}");
            }

            return sb.ToString();
        }
    }
}
