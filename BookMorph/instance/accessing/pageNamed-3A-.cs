pageNamed: aName
	^ pages detect: [:p | p externalName = aName] ifNone: [nil]