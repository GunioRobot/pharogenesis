scrapsBook
	^ pages detect: [:p | p hasProperty: #scraps] ifNone: [nil]