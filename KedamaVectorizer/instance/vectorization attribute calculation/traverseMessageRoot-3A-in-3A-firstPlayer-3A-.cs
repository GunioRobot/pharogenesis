traverseMessageRoot: aMessageNode in: obj firstPlayer: firstPlayer

	| inCondition |
	inCondition _ #(ifTrue: ifFalse: ifTrue:ifFalse:) includes: aMessageNode selector key.

	root _ aMessageNode.

	self traverseMessage: aMessageNode in: obj firstPlayer: firstPlayer inCondition: inCondition.
