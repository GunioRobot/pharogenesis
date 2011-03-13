valueOfFlag: aFlagName
	^ FlagDictionary at: aFlagName ifAbsent: [false]