replaceNodesIn: aDictionary

	^aDictionary at: self ifAbsent: [
		receiver _ receiver replaceNodesIn: aDictionary.
		arguments _ arguments collect: [ :a | a replaceNodesIn: aDictionary ].
		self]