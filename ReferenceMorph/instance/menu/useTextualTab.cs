useTextualTab
	| aLabel stringToUse |
	self preserveDetails.
	stringToUse _ self valueOfProperty: #priorWording ifAbsent: [self externalName].
	aLabel _ StringMorph  new contents: stringToUse.
	self replaceSubmorph: submorphs first by: aLabel.
	aLabel position: self position.
	aLabel highlightColor: self highlightColor; regularColor: self regularColor.
	aLabel lock.
	self fitContents.
	self layoutChanged.
	(owner isKindOf: IndexTabs) ifTrue:
		[self borderWidth: 0.
		owner laySubpartsOutInOneRow.
		isHighlighted ifTrue:
			[self highlight]]