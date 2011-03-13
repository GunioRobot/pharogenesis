replaceNodesIn: aDictionary

	^aDictionary at: self ifAbsent: [
		variable _ variable replaceNodesIn: aDictionary.
		expression _ expression replaceNodesIn: aDictionary.
		self]