bindVariableUsesIn: aDictionary

	^ (aDictionary at: name ifAbsent: [^ self]) copyTree