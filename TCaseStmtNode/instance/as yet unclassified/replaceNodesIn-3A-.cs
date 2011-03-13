replaceNodesIn: aDictionary

	^aDictionary at: self ifAbsent: [
		expression _ expression replaceNodesIn: aDictionary.
		cases _ cases collect: [ :c | c replaceNodesIn: aDictionary ].
		self]