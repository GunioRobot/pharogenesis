replaceNodesIn: aDictionary

	^aDictionary at: self ifAbsent: [
		expression _ expression replaceNodesIn: aDictionary.
		self]