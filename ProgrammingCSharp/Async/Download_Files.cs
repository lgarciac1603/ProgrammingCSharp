namespace ProgrammingCSharp.Async
{
    public class Download_Files
    {
        public async Task DownloadFilesAsync()
        {
            // Start downloading "File1.txt" and "File2.txt" concurrently
            var downloadTask1 = DownloadFileAsync("File1.txt");
            var downloadTask2 = DownloadFileAsync("File2.txt");

            // Wait for both downloads to complete
            await Task.WhenAll(downloadTask1, downloadTask2);

            Console.WriteLine("All downloads completed.");
        }

        public static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.DownloadFilesAsync();
        }

        public async Task ProcessLargeDatasetAsync(int numberOfChunks)
        {
            var tasks = new List<Task>();

            // Start processing each chunk concurrently
            for (int i = 1; i <= numberOfChunks; i++)
            {
                tasks.Add(ProcessDataChunkAsync(i));
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);

            Console.WriteLine("All data chunks processed.");
        }
    }
}
