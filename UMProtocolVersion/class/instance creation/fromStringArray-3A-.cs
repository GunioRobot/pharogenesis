fromStringArray: array
	^self version: (Integer readFromString: array second)