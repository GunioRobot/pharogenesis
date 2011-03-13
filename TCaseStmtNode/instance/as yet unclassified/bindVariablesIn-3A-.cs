bindVariablesIn: aDictionary

	expression _ expression bindVariablesIn: aDictionary.
	cases _ cases collect: [ :c | c bindVariablesIn: aDictionary ].