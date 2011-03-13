assertAListMatches: strings
	| listMorphs list |
	listMorphs := self listMorphs.
	listMorphs 
		detect: [:m | list := m getList. (list size = strings size) and: [list includesAllOf: strings]]
		ifNone: [self assert: false].