dragPassengerFor: item inMorph: dragSource 
	| transferType smn |
	(dragSource isKindOf: PluggableListMorph)
		ifFalse: [^nil].
	transferType _ self dragTransferTypeForMorph: dragSource.
	transferType == #classList
		ifTrue: [^self selectedClass].
	transferType == #messageList
		ifFalse: [ ^nil ].
	smn _ self selectedMessageName ifNil: [ ^nil ].
	(MessageSet isPseudoSelector: smn) ifTrue: [ ^nil ].

	^ self selectedClassOrMetaClass -> smn.
