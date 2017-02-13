**Sample C# application that demonstrates how to submit a JAMS job with a parameter using the JAMS .NET SDK**

In order to use the SDK the JAMSShr.dll library must be imported into your project references. 

The namespace must also include "Using MVPSI.JAMS" in order to expose the SDK library. 

In this example: 

-We create a new parameter object.

-We create a new job (**Note: The ParentFolderName property should be changed to match where you would like this job to be saved**). 

-We assign the parameter to the job (**The parameter we created is of DataType.'Text'.  Parameters can also be set to other data types**).

-We then create the job by calling sampleJob.Update(server)

-Then we create a JAMS Submit Info object that will define the properties of the job and parameter that we are going to submit. 

-We load the job into the submit info object

-We add the parameter to the submit info object

-We submit the job with the parameter by calling si.Submit()




