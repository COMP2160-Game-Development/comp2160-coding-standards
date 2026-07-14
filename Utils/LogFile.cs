using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LogFile : MonoBehaviour {

	// find the path to the log folder (this should work cross platform)
	private string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Logs");

	[SerializeField] private string fileName;

	// the format for the filename. 
	// The {0} is filled with the path above
	// the {1:yyyy-MM-dd-HH-mm-ss} is filled with the current data/time in a sortable format.
	[SerializeField] private string nameFormat = "{0}/{1}-{2:yyyy-MM-dd-HH-mm-ss}.txt";

	// an array of headers describing the contents of a row of the log (one per column)
	[SerializeField] private string[] headers = {};

	private string lineFormat;

    // the StreamWriter representing the open log file
    private StreamWriter log = null;

	void Start () {
		// create and open the log file

		// create the directory if necessary
		if (!Directory.Exists(path)) {
			Directory.CreateDirectory(path);					
		}

		// create the filename from the current time
		string filename = string.Format(nameFormat, path, fileName, System.DateTime.Now);

		// open the stream
		log = new StreamWriter (filename);

		// write a header for all the columns we will logging

		log.WriteLine(string.Join("\t", headers));
		log.Flush();	// flush after every write, to make sure the buffer is written to disk

		// construct a line format string

		lineFormat = "";
		for (int i = 0; i < headers.Length; i++) {
			if (i > 0) {
				lineFormat += "\t";
			}
			lineFormat += string.Format("{{{0}}}", i);
		}

	}

	void OnDestroy() {
		// close the logfile with this object is destroyed
		if (log != null) {
			log.Close();
		}
	}

	public void WriteLine(params object[] args) {
		if (args.Length != headers.Length) {
			Debug.LogError("Unexpected number of arguments to LogFile.WriteLine");
		}
		log.WriteLine(lineFormat, args);
		log.Flush();
	}
}
