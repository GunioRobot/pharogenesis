bindVariableUsesIn: aDictionary

	receiver _ receiver bindVariableUsesIn: aDictionary.
	arguments _ arguments collect: [ :a | a bindVariableUsesIn: aDictionary ].