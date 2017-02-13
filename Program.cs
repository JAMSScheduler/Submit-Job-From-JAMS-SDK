using System;
//must reference MVPSI.JAMS to access the SDK.  
//Be sure to reference JAMSShr in project references
using MVPSI.JAMS;

namespace JAMSSubmitJobSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Establish a connection to your server.
            Server server = new Server("localhost");

            //
            // Create a Parameter
            //
            Param nameParameter = new Param()
            {
                ParamName = "Name_Input",
                DataType = DataType.Text,
                Length = 15,
                Prompt = "Enter a name",
                HelpText = "Enter only the First Name",
                Required = true
            };

            //
            // Create a Job
            //
            Job sampleJob = new Job()
            {
                JobName = "TestJob123",
                Description = "Submitting a sample job from C# application using the JAMS .NET SDK.",
                ParentFolderName = @"\Samples\TestFolder",
            };

            try
            {
                // Assign Parameter to the Job
                sampleJob.Parameters.Add(nameParameter);
            }
            catch (JAMSException jex)
            {
                Console.WriteLine(jex);
                Console.Read();
            }
            try
            {
                sampleJob.Update(server);
            }
            catch (JAMSException jex)
            {
                Console.WriteLine(jex);
                Console.Read();
            }
        }
    }
}
