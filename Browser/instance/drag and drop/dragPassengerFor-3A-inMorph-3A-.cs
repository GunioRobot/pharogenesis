dragPassengerFor: item inMorph: dragSource 
	| transferType |
	(dragSource isKindOf: PluggableListMorph)
		ifFalse: [^item].
	transferType _ self dragTransferTypeForMorph: dragSource.
	transferType == #messageList
		ifTrue: [^self selectedClassOrMetaClass->item contents].
	transferType == #classList
		ifTrue: [^self selectedClass].
	^item contents