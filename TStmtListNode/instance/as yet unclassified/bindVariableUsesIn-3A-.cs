bindVariableUsesIn: aDictionary

	statements _ statements collect: [ :s | s bindVariableUsesIn: aDictionary ].