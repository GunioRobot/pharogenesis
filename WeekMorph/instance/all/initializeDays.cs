initializeDays
	| extent days |
	self removeAllMorphs.
	days _ OrderedCollection new: 7.
	extent _ self tile extent.
	week do:
		[:each |
		days add:
			(each month = month
				ifTrue:
					[(self tileLabeled: each dayOfMonth printString)
						extent: extent;
						setBalloonText: each printString]
				ifFalse:
					[Morph new
						color: Color transparent;
						extent: extent])].
	days reverseDo: [:each | self addMorph: each]