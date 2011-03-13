bindVariablesIn: aDictionary

	receiver _ receiver bindVariablesIn: aDictionary.
	arguments _ arguments collect: [ :a | a bindVariablesIn: aDictionary ].