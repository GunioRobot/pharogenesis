upToAll: aCollection
	"Answer a subcollection from the current access position to the occurrence (if any, but not inclusive) of aCollection. If aCollection is not in the stream, answer the entire rest of the stream."

	| startPos endMatch result |
	startPos _ self position.
	(self match: aCollection) 
		ifTrue: [endMatch _ self position.
			self position: startPos.
			result _ self next: endMatch - startPos - aCollection size.
			self position: endMatch.
			^ result]
		ifFalse: [self position: startPos.
			^ self upToEnd]