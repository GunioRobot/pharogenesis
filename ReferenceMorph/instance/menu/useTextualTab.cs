useTextualTab
	"Use a textually-emblazoned tab"

	| aLabel stringToUse font aColor |
	self preserveDetails.
	stringToUse _ self valueOfProperty: #priorWording ifAbsent: [self externalName].
	font _ self valueOfProperty: #priorFont ifAbsent: [Preferences standardButtonFont].
	aColor _ self valueOfProperty: #priorColor ifAbsent: [Color green darker].
	aLabel _ StringMorph contents: stringToUse font: font.
	self replaceSubmorph: submorphs first by: aLabel.
	aLabel position: self position.
	self color: aColor.
	aLabel highlightColor: self highlightColor; regularColor: self regularColor.
	aLabel lock.
	self fitContents.
	self layoutChanged.
	(owner isKindOf: IndexTabs) ifTrue:
		[self borderWidth: 0.
		owner laySubpartsOutInOneRow.
		isHighlighted ifTrue:
			[self highlight]]