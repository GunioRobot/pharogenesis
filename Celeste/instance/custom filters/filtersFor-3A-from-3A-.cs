filtersFor: msgID from: filterNames
	| currentTocEntry |
	currentTocEntry := mailDB getTOCentry: msgID.
	^filterNames select: [:e | (self customFilterNamed: e) value: currentTocEntry].