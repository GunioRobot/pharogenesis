initializeDays: modelOrNil
	| extent days tile |
	self removeAllMorphs.
	days _ OrderedCollection new: 7.
	extent _ self tile extent.
	week datesDo:
		[:each |
		tile _ (self tileLabeled: each dayOfMonth printString) extent: extent.
		each month = month ifFalse:
			[tile color: Color gray; offColor: Color gray; onColor: Color veryLightGray].
		modelOrNil ifNotNil:
			[tile target: modelOrNil;
				actionSelector: #setDate:fromButton:down:;
				arguments: {each. tile}].
		days add: tile].
	days reverseDo: [:each | self addMorph: each]