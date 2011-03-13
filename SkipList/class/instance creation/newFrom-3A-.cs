newFrom: aCollection 
	| skipList |
	skipList := self new: aCollection size.
	skipList addAll: aCollection.
	^ skipList