dragPassengerFor: item inMorph: dragSource 
	| transferType |
	transferType _ self dragTransferTypeForMorph: dragSource.
	transferType == #messageList
		ifTrue: [^self selectedClassOrMetaClass->(item contents findTokens: ' ') second asSymbol].
	transferType == #classList
		ifTrue: [^self selectedClass].
	^nil