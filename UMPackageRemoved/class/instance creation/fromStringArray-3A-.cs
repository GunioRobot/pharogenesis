fromStringArray: array
	^self packageName: array second version: (UVersion readFromString: array third)