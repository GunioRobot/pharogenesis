useStringTab: aString
	| aLabel |
	aLabel _ StringMorph  new contents: aString asString.
	self addMorph: aLabel.
	aLabel position: self position.
	aLabel highlightColor: self highlightColor; regularColor: self regularColor.
	aLabel lock.
	self fitContents.
	self layoutChanged