wantsDroppedMorph: transferMorph event: evt inMorph: listMorph
	| node |
	(transferMorph isKindOf: TransferMorph) ifFalse: [^ false].
	transferMorph dragTransferType == self dragTransferType ifFalse: [^ false].
	node _ self nodeForDroppedMorph: transferMorph event: evt inMorph: listMorph.
	^ node notNil and: [node wantsDroppedNode: transferMorph passenger]