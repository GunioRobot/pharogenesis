newFrom: aCollection
	| newCollection |
	newCollection _ self new.
	newCollection addAll: aCollection.
	^newCollection