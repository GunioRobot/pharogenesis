computeCopiedValues: rootNode
	| referencedValues |
	referencedValues := rootNode referencedValuesWithinBlockExtent: blockExtent.
	^((referencedValues reject: [:temp| temp isDefinedWithinBlockExtent: blockExtent])
		asSortedCollection: ParseNode tempSortBlock)
			asArray