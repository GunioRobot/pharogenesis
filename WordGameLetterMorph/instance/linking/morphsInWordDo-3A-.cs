morphsInWordDo: aBlock

	aBlock value: self.
	(successor == nil or: [successor isBlank]) ifTrue: [^ self].
	successor morphsInWordDo: aBlock