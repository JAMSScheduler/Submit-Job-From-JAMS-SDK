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
                // Try to create/update the job that we just defined on our specified server
                sampleJob.Update(server);
            }
            catch (JAMSException jex)
            {
                Console.WriteLine(jex);
                Console.Read();
            }

            //
            // If the job has been created without any exceptions
            // we can go ahead and try to submit the job with a value for the parameter we created
            //
            Submit.Info si;
            try
            {
                Submit.Load(out si, "TestJob123", server, Submit.Type.Job);
                si.Parameters["Name_Input"].ParamValue = "SampleName";
                si.Submit();
            }
            catch (JAMSException jex)
            {
                Console.WriteLine(jex);
                Console.Read();
            }   
            
        }
    }
}
