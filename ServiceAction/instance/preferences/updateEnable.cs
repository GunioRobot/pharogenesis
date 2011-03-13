updateEnable
	enabled := ServicePreferences
				valueOfPreference: self id
				ifAbsent: [true]