keysAndValuesDo: aBlock 
	"Enumerate the receiver with all the keys and values passed to the block"
	| key |
	tally = 0 ifTrue: [^ self].
	1 to: self basicSize do:
		[:i | (key := self basicAt: i) == nil ifFalse:
			[aBlock value: key value: (array at: i)]
		]