using Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileParser.Exceptions;
using Common.Mappers;

namespace FileParser.Utilities
{
    public class FileReader
    {
        /// <summary>
        /// Reads all the files at the filepaths 
        /// </summary>
        /// <param name="filePaths">list of file paths</param>
        /// <returns>all the read lines from the input files</returns>
        public static List<string> ReadFiles(List<string> filePaths)
        {
            var fileContents = new List<string>();
            if (filePaths == null || !filePaths.Any()) return fileContents;
           // Parallel.ForEach(filePaths, filePath => fileContents.AddRange(ReadFile(filePath)));
            foreach (var filePath in filePaths)
            {
                fileContents.AddRange(ReadFile(filePath));
            }
            return fileContents;
        }

        /// <summary>
        /// Read the file at the provided path
        /// </summary>
        /// <param name="filePath">input file path</param>
        /// <returns>lines from the input file</returns>
        public static List<string> ReadFile(string filePath)
        {
            int lineCounter = 0;
            try
            {
                var fileRecords = new List<string>();
                string lineContent;
                StreamReader reader = new StreamReader(filePath);
                while ((lineContent = reader.ReadLine()) != null)
                {
                    lineCounter = lineCounter + 1;
                    fileRecords.Add(lineContent);
                }
                return fileRecords;
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new FileReadException("Unable to read the file; FileName : {0}, LineNumber : {1}", filePath, lineCounter);
            }
        }




    }
}
