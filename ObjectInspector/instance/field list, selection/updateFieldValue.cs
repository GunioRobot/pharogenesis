updateFieldValue
	fieldIndex = 0 ifTrue: [^ self].
	valuePane scroller firstSubmorph contents: self fieldValue printString asText