bindVariableUsesIn: aDictionary

	expression _ expression bindVariableUsesIn: aDictionary.
	cases _ cases collect: [ :c | c bindVariableUsesIn: aDictionary ].