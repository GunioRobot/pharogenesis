storeCodeOn: aStream
	aStream nextPutAll: ' assign', (assignmentSuffix copyWithout: $:), 'Getter: #'.
	aStream nextPutAll: (Utilities getterSelectorFor: assignmentRoot).
	aStream nextPutAll: ' setter: #'.
	aStream nextPutAll: (Utilities setterSelectorFor: assignmentRoot).
	aStream nextPutAll: ' amt: '