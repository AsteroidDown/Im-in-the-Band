using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem {

	// ------------------------------ Player Preferences ------------------------------ //
	public static void SavePlayerPrefs() {
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/PlayerPrefs.iitb";
		FileStream stream = new FileStream(path, FileMode.Create);

		PlayerPrefs data = new PlayerPrefs();

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static PlayerPrefs LoadPlayerPrefs() {
		string path = Application.persistentDataPath + "/PlayerPrefs.iitb";

		if (File.Exists(path)) {
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			PlayerPrefs data = formatter.Deserialize(stream) as PlayerPrefs;

			stream.Close();

			return data;

		} else {

			Debug.Log("Player Preferences file not found in " + path);
			return null;
		}
	}
}
