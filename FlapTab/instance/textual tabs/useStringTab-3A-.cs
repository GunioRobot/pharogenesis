useStringTab: aString
	| aLabel |
	labelString _ aString asString.
	aLabel _ StringMorph  new contents: labelString.
	self addMorph: aLabel.
	aLabel position: self position.
	aLabel highlightColor: self highlightColor; regularColor: self regularColor.
	aLabel lock.
	self fitContents.
	self layoutChanged