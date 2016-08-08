using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Printing;
using System.IO;

namespace PrintServiceHost
{
    [ServiceBehavior(Name = "PrintService", Namespace = "urn:ps")]
    public class PrintService : IPrintContract
    {
        /// <summary>
        /// gets the print info from the request , downloads the document and sends it to print queue.
        /// </summary>
        /// <param name="printInfo"></param>
        /// <returns>status string</returns>
        public string SendToPrintQueue(PrintInfo printInfo)
        {
            try
            {
                DownloadDocumentfromCloudStorage(printInfo);
                return "success";
            }
            catch (Exception exp)
	        {
                return "failure :"+exp.Message;
            }
           
        }

        private void DownloadDocumentfromCloudStorage(PrintInfo printInfo)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
    CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference(printInfo.ContainerName);
            CloudBlockBlob blockBlob2 = container.GetBlockBlobReference(printInfo.DocumentName);

            
            using (var memoryStream = new MemoryStream())
            {
                blockBlob2.DownloadToStream(memoryStream);
                

                // Create the printer server and print queue objects
                LocalPrintServer localPrintServer2 = new LocalPrintServer();
                PrintQueue defaultPrintQueue2 = LocalPrintServer.GetDefaultPrintQueue();

                // Call AddJob 
                PrintSystemJobInfo anotherPrintJob = defaultPrintQueue2.AddJob("MyJob");

                // Write a Byte buffer to the JobStream and close the stream
                Stream anotherStream = anotherPrintJob.JobStream;
                Byte[] anotherByteBuffer = memoryStream.ToArray();
                anotherStream.Write(anotherByteBuffer, 0, anotherByteBuffer.Length);
                anotherStream.Close();
            }
        }
    }
}
