using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

// DEBUG: remove the inheritance MonoBehavior and the Start method if you want to not test the class
// Don't forget that Unity's working directory is Asset-Library-obj… folder when you try to parse a file
public class CSVParser : MonoBehaviour {
	public static int[,] ParseCSVtoArray (string csvFileName) {
		// Width and Height of the CSV file
		int countLine = 0;
		int countColumn = 0;
		string line;
		TextReader reader = new StreamReader(csvFileName);

		line = reader.ReadLine();
		while (line != null) {
			line = reader.ReadLine();
			countLine++;
		}


		reader.Close();

		reader = new StreamReader(csvFileName);
		line = reader.ReadLine();

		// +1 because there is ;-1 char
		countColumn = line.Length+1;
		// Because we added a line to know the countColumn
		countLine--;
		Debug.Log (line);
		Debug.Log("countLine = " + countLine);
		Debug.Log("countColumn = " + countColumn);

		int[,] arrayParsed = new int[countLine,countColumn];

		for (int i = 0; i < countLine; ++i) {
			int j = 0;
			int columnIndex = 0;
			line = reader.ReadLine();
			int lineLength = line.Length;

			while (j < lineLength) {
				if (line[j] != ';') {
					// -48 becasse 0
					arrayParsed[i, columnIndex] = (int) line[j] - 48;
					// Skip the next ';'
					j++;
				}
				else {
					arrayParsed[i, columnIndex] = 0;
				}
				columnIndex++;
				j++;
			}

		}
		for (int i =0; i<countLine; ++i) {
		Debug.Log(arrayParsed[i,0]);
		}

		return arrayParsed;
	}

	void Start () {
		ParseCSVtoArray("./Assets/Scripts/CSV/CSV-test.csv");
	}
}
