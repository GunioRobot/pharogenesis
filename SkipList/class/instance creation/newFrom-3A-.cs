newFrom: aCollection 
	| skipList |
	skipList _ self new: aCollection size.
	skipList addAll: aCollection.
	^ skipList