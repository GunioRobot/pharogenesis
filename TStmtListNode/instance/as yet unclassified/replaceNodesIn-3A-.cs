replaceNodesIn: aDictionary

	^aDictionary at: self ifAbsent: [
		statements _ statements collect: [ :s | s replaceNodesIn: aDictionary ].
		self]