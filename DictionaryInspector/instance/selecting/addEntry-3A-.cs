addEntry: aKey
	object at: aKey put: nil.
	self calculateKeyArray.
	selectionIndex _ keyArray indexOf: aKey.
	self changed: #inspectObject.
	self changed: #fieldList.
	self update