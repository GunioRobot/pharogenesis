morphsInWordDo: aBlock 
	aBlock value: self.
	(successor isNil or: [successor isBlank]) ifTrue: [^self].
	successor morphsInWordDo: aBlock