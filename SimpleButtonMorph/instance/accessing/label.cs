label

	| s |
	s _ ''.
	self allMorphsDo: [:m | (m isKindOf: StringMorph) ifTrue: [s _ m contents]].
	^ s