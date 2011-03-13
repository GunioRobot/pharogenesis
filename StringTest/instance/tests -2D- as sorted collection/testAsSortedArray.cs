testAsSortedArray
	| result collection |
	collection := self collectionWithSortableElements .
	result := collection  asSortedArray.
	self assert: (result class includesBehavior: Array).
	self assert: result isSorted.
	self assert: result size = collection size