wantsDroppedMorph: aTransferMorph event: evt inMorph: dest
	| retval |
	retval _ (aTransferMorph isKindOf: TransferMorph)
		and: [ aTransferMorph dragTransferType == #file ]
		and: [ self isDirectoryList: dest ].
	"retval ifFalse: [ Transcript nextPutAll: 'drop not wanted'; cr ]."
	^retval