reverseDo: aBlock 
	"Evaluate aBlock for each element of my interval, in reverse order."
	| aValue |
	aValue := self last.
	step < 0
		ifTrue: [[start >= aValue]
				whileTrue: [aBlock value: aValue.
					aValue := aValue - step]]
		ifFalse: [[start <= aValue]
				whileTrue: [aBlock value: aValue.
					aValue := aValue - step]]