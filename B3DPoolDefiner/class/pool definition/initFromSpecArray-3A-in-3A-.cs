initFromSpecArray: specArray in: aDictionary
	specArray do:[:spec|
		self initPoolVariable: spec first value: spec last in: aDictionary.
	]