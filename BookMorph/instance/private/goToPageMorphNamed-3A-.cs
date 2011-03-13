goToPageMorphNamed: aName
	| aMorph |
	aMorph _ pages detect: [:p | p externalName = aName] ifNone: [^ self beep].
	self goToPageMorph: aMorph