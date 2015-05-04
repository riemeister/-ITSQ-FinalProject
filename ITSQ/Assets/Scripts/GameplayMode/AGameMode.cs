using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AGameMode {
	protected ModeManager.ModeType modeType;
	protected Dictionary<string, object> modeValues = new Dictionary<string, object>();

	public ModeManager.ModeType GetModeType() {
		return this.modeType;
	}
	
	public object GetModeValue(string key) {
		if (this.modeValues.ContainsKey (key)) {
			return this.modeValues [key];
		} else {
			Debug.LogError(key + "does not exist in configuration settings!");
			return null;
		}
	}

	public abstract void Configure();
}
