bindVariablesIn: aDictionary

	statements _ statements collect: [ :s | s bindVariablesIn: aDictionary ].