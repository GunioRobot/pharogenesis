newFrom: aCollection
	| newCollection |
	newCollection := self new.
	newCollection addAll: aCollection.
	^newCollection